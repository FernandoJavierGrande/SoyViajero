using Microsoft.AspNetCore.Mvc;
using SoyViajero.BBDD.Data.Entidades;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SoyViajero.BBDD.Data;


using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace SoyViajero.Server.Controllers
{
    [ApiController]
    [Route("api/Login")]
    public class LoginController : ControllerBase
    {
        private readonly Context context;

        //private List<Claim> claims = new List<Claim>();
        public LoginController(Context context) => this.context = context;


        [HttpGet("/Buscar/{NombreUser}")]
        public async Task<ActionResult<bool>> Disp(string NombreUser)
        {
            var resp = await context.Usuarios.AnyAsync(x => x.NombreUser == NombreUser);

            return !resp;
        }

        #region log
        [HttpGet("{usuario},{pass}")]
        public async Task<ActionResult<Usuario>> Get(string usuario, string pass)
        {
            try
            {
                pass = ConvertirSha256(pass);

                var User = context.Usuarios      // compara que las cuenta y la clave coincida
                    .Where(x => x.NombreUser == usuario && x.Pass == pass)
                    .FirstOrDefault();

                //var User = await context.Usuarios.Where(x => x.NombreUser == usuario);


                if (User == null) // si no devuelve nada es porque no coincide
                    return BadRequest("El usuario o contraseña no son correctos ");


                var cuentasH = await context.CuentasHostel // busca las cuentas de hostel que tenga registradas
                    .Where(c => c.UsuarioId==User.Id)
                    .Select(x => x.Id)
                    .ToListAsync();

                var cuentasV = await context.CuentasViajeros // selecciona si tiene la cuenta de viajero
                    .Where(c => c.UsuarioId == User.Id)
                    .Select(x => x.Id)
                    .FirstOrDefaultAsync();

                if (cuentasV == null)
                    cuentasV =String.Empty;

                bool resp = await agregarClaims(User.Id, cuentasH, cuentasV, usuario);


                #region borrar


                ////guarda los datos de la sesion 
                // var claims = new List<Claim> 
                // {
                //    new Claim(ClaimTypes.Name, usuario),
                //    new Claim("Id", IdUser.ToString()),

                // };

                //if (cuentasV != null)
                //{
                //    claims.Add(new Claim("cuentaV", cuentasV)); // guarda id de viajero
                //    //claims.Add(new Claim("cuentaActiva", cuentasV)); eliminar
                //}



                //for (int i = 0; i < cuentasH.Count; i++)       // por cada cuentaH guarda el id en un nuevo claim
                //{

                //    claims.Add(new Claim($"cuentaH{i}", cuentasH[i]));

                //}

                //

                //foreach (var item in claims)    //prueba
                //    Console.WriteLine($"+++++++{item.Type} = {item.Value}");


                //finaliza el guardado de los datos de la sesion

                //var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);


                // await HttpContext.SignInAsync
                //     (CookieAuthenticationDefaults.AuthenticationScheme,
                //     new ClaimsPrincipal(claimsIdentity));
                #endregion

                return User;


            }
            catch (Exception)
            {
                return BadRequest("El usuario o contraseña no son correctos ");
            }
        }
        #endregion

        #region cambiarCuenta
        [HttpGet("{cuentaId}")]
        public async Task<ActionResult<int>> Get(string cuentaId)
        {
            //comparar si el id de la cuenta existe entre los claims cargados
            
            bool validarCuenta = false;
            
            var claims =  User.Claims.ToList();
            
            for (int i = 0; i < claims.Count; i++)
            {
                string aux = claims[i].Value.ToString();
                
                if (aux==cuentaId)
                {
                    validarCuenta = true;
                    
                }
                if (claims[i].Type.Contains("cuentaActiva"))
                {
                    claims.Remove(claims[i]);
                    validarCuenta=true;
                }

            }

            if (!validarCuenta)
                return BadRequest("Error");

            int IdUser = int.Parse(claims.Where(x=>x.Type == "Id").Select(x=>x.Value).First());

            string usuario = claims.Where(x => x.Type == ClaimTypes.Name).Select(x => x.Value).First();

            List<string> cuentasH = new List<string>();
            string cuentaV = string.Empty;

            for(int i =0; i< claims.Count; i++)
            {
                if (claims[i].Type.Contains($"cuentaH"))
                {
                    cuentasH.Add(claims[i].Value.ToString());
                }
                if (claims[i].Type.Contains("cuentaV"))
                {
                    cuentaV = claims[i].Value.ToString();
                }
                
            }
            bool resp = await agregarClaims(IdUser,cuentasH,cuentaV,usuario,cuentaId);

            if (resp)
            {
                return 1;
            }
            return 0;
            
        }
        #endregion

        [HttpPost("/Registro")]
        public async Task<ActionResult<Usuario>> Registro(Usuario usuario)
        {
            usuario.Pass = ConvertirSha256(usuario.Pass);

            try
            {
                var UserExists = await context.Usuarios.AnyAsync(x => x.NombreUser == usuario.NombreUser);

                if (UserExists)
                {
                    return BadRequest($"El nombre de usuario '{usuario.NombreUser}' ya existe.");
                }
                context.Usuarios.Add(usuario);

                context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e )
            {
                
                return BadRequest(" +++ Error, vuelva a intentar " +e); //borrar
            }
        }
        



        public static string ConvertirSha256(string texto)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
        
        private async Task<bool> agregarClaims( int IdUser,
                                                List<string> cuentasH,
                                                string cuentasV,
                                                string usuario,
                                                string cuentaActiva="null")
        {
            try
            {
                //guarda los datos de la sesion 
                var claims = new List<Claim>
                 {
                    new Claim(ClaimTypes.Name, usuario),
                    new Claim("Id", IdUser.ToString()),

                 };

                if (cuentasV != string.Empty)
                {
                    claims.Add(new Claim("cuentaV", cuentasV)); // guarda id de viajero
                }
                if (cuentaActiva != "null")
                {
                    claims.Add(new Claim("cuentaActiva", cuentaActiva));
                }


                if (cuentasH.Count>0)
                {
                    for (int i = 0; i < cuentasH.Count; i++)       // por cada cuentaH guarda el id en un nuevo claim
                    {

                        claims.Add(new Claim($"cuentaH{i}", cuentasH[i]));

                    }
                    Console.WriteLine("cuentash es mayor a cero");
                }
                



                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);


                 await HttpContext.SignInAsync
                    (CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                foreach (var item in claims)    //prueba
                    Console.WriteLine($"+++++++{item.Type} = {item.Value} ");

                    return true;
            }
            catch (Exception e )
            {
                Console.WriteLine(e);
                return  false;
            }
        }

    }
}
