using Microsoft.AspNetCore.Mvc;
using SoyViajero.BBDD.Data.Entidades;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SoyViajero.BBDD.Data;


using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace SoyViajero.Server.Controllers
{
    [ApiController]
    [Route("api/Login")]
    public class LoginController : ControllerBase
    {
        private readonly Context context;

        public  LoginController(Context context) => this.context = context;


        #region post
        [HttpPost("{usuario},{pass}")]
        public async Task<ActionResult> postLog(string usuario,string pass)
        {
            try
            {
                pass = ConvertirSha256(pass);

                var IdUser = context.Usuarios      // compara que las cuenta y la clave coincida
                    .Where(x => x.NombreUser == usuario && x.Pass == pass)
                    .Select(u => u.Id)
                    .FirstOrDefault();

                if (IdUser == 0) // si no devuelve nada es porque no coincide
                    return BadRequest("El usuario o contraseña no son correctos " );

                var cuentasH = await context.CuentasHostel // busca las cuentas de hostel que tenga registradas
                    .Where(c => c.UsuarioId == IdUser)
                    .Select(x =>x.Id)
                    .ToListAsync();
                
                var cuentasV = context.CuentasViajeros // selecciona si tiene la cuenta de viajero
                    .Where(c=>c.UsuarioId==IdUser)
                    .Select(x =>x.Id)
                    .FirstOrDefault();

                var claims = new List<Claim> //guarda los datos de la sesion 
                {
                    new Claim(ClaimTypes.Name, usuario),
                    new Claim("Id", IdUser.ToString()),
                };

                if (cuentasV!=null)
                    claims.Add(new Claim("cuentaV", cuentasV)); // guarda id de viajero


                for (int i = 0; i < cuentasH.Count; i++)       // por cada cuentaH guarda el id en un nuevo claim
                {

                    claims.Add(new Claim($"cuentaH{i}", cuentasH[i]));
                    if (i==0) // asigna automaticamente la primer cuenta
                    {
                        claims.Add(new Claim("cuentaActiva",cuentasH[i]));
                    }
                }

                foreach (var item in claims)    //prueba
                    Console.WriteLine($"+++++++{item.Type} = {item.Value}");
                

                // finaliza el guardado de los datos de la sesion

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);


                await HttpContext.SignInAsync
                    (CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                return Ok($"id user {IdUser}");
            }
            catch (Exception )
            {
                return BadRequest("El usuario o contraseña no son correctos ");
            }
        }
        

        
        [HttpPost("/Registro")]
        public ActionResult Registro(Usuario usuario)
        {
            usuario.Pass = ConvertirSha256(usuario.Pass);

            try
            {
                var UserExists = context.Usuarios.Any(x => x.NombreUser == usuario.NombreUser);
                if (UserExists)
                {
                    return BadRequest($"El nombre de usuario '{usuario.NombreUser}' ya existe.");
                }
                context.Usuarios.Add(usuario);

                context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error, vuelva a intentar");
            }
        }
        #endregion



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
        //private bool UserExist(string userName) //confirma si el usuario con nombre x existe
        //{
        //    var user = context.Usuarios
        //        .Where(u => u.NombreUser == userName)
        //        .FirstOrDefault();
        //    if (user != null)
        //        return false;
        //    return true;
        //}
    }
}
