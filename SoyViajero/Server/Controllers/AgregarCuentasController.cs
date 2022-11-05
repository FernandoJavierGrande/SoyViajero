using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoyViajero.BBDD.Data;
using SoyViajero.BBDD.Data.Entidades;
using System.Security.Cryptography;
using System.Text;

using Microsoft.AspNetCore.Authorization;


namespace SoyViajero.Server.Controllers
{
    [ApiController]
    [Route("api/Cuentas")]
    //[Authorize]
    public class AgregarCuentasController : ControllerBase
    {
        private readonly Context context;
        

        public AgregarCuentasController(Context context)
            => this.context = context;
            

        #region Get
        [HttpGet]
        public async Task<ActionResult<Usuario>> Get()
        {
            
            try
            {
                // extraigo el id del usuario que inicio la sesion
                 var IdUser = int.Parse(User.Claims.Where(x => x.Type == "Id").Select(c => c.Value).First());

                

                var cuentas = await context.Usuarios
                            .Where(u => u.Id == IdUser)
                            .Include(h => h.cuentasHostel)
                            .Include(v => v.cuentaViajero)
                            .FirstOrDefaultAsync();

                //Console.WriteLine($"++++{cuentas.cuentaViajero}");
                //Console.WriteLine($"++++{cuentas.cuentasHostel.Count}");


                return cuentas;
            }
            catch (Exception )
            {

                return BadRequest();
            }

        }
        #endregion

        #region post

        #region elim


        //[HttpPost]
        //public async Task<ActionResult<bool>> Post(Usuario usuario)
        //{

        //    try
        //    {
        //        if (!UserExist(usuario.NombreUser))
        //            return BadRequest($"El usuario {usuario.NombreUser} ya existe");

        //        context.Usuarios.Add(usuario);

        //        await context.SaveChangesAsync();
        //        return Ok();
        //    }
        //    catch (Exception)
        //    {

        //        return BadRequest("Error al agregar nuevo usuario");
        //    }

        //}
        #endregion

        [HttpPost("/AgregarHostel")]
        public async Task<ActionResult<CuentaHostel>>Post(CuentaHostel hostel) // agrega una nueva cuenta de hostel
        {
            try
            {
                hostel.UsuarioId = int.Parse(User.Claims.Where(x => x.Type == "Id").Select(c => c.Value).First());
                hostel.Id = crearIdH();

                context.CuentasHostel.Add(hostel);
                
                await context.SaveChangesAsync();

                return hostel;
            }
            catch (Exception)
            {
                
                return BadRequest("no se pudo crear la nueva cuenta intente nuevamente " );
            }
        }


        [HttpPost("/AgregarViajero")]
        public async Task<ActionResult<CuentaHostel>> Post(CuentaViajero viajero)
        {

            int IdUser = int.Parse(User.Claims
                            .Where(x => x.Type == "Id")
                            .Select(c => c.Value)
                            .First());

            var cuentaV = context.CuentasViajeros
                .Where(c => c.UsuarioId == IdUser)
                .Select(x => x.Id)
                .FirstOrDefault();

            if (cuentaV != null)
                return BadRequest("No se puede agregar otra cuenta de 'Viajero'");

            try
            {
                viajero.UsuarioId = IdUser;
                viajero.Id = IdCuentaV();

                context.CuentasViajeros.Add(viajero);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Error al Guardar el nuevo viajero " + e);
            }
        }

        #endregion

        #region Delete
        [HttpDelete("/eliminarCuentaViajero")]
        public async Task<ActionResult> delete()
        {
            var CuentaViajero = User.Claims
                            .Where(x => x.Type == "cuentaV")
                            .Select(c => c.Value)
                            .FirstOrDefault();

            if (CuentaViajero == null)
                return BadRequest("No posee ninguna cuenta de viajero");

            var viajeroElim = context.CuentasViajeros
                .Where(c => c.Id.Equals(CuentaViajero))
                .FirstOrDefault();

            if (viajeroElim == null) 
                return NotFound("Cuenta incorrecta");

            try
            {
                context.CuentasViajeros.Remove(viajeroElim);

                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Ocurrio un error intente nuevamente");
            }
        }
        #endregion

        #region metodos

        private string crearIdH() // generan ids aleatorios con identificador segun el tipo de cuenta
        {
            Random random = new Random();
            int numero;
            string id;
            bool repetir = false;
            
            do
            {

                numero = random.Next(1000, 100000);

                id = "h" + numero.ToString();

                Console.WriteLine(id);
               
                var aux = context.CuentasHostel
                    .Where(c => c.Id ==id)
                    .FirstOrDefault();

                if (aux != null)
                    repetir = true;

            } while (repetir);

            return id;
        }
        private string IdCuentaV()
        {
            Random random = new Random();
            int numero;
            string id;
            bool repetir = false;

            do
            {

                numero = random.Next(1000, 100000);

                id = "v" + numero.ToString();

                Console.WriteLine(id);

                var aux = context.CuentasViajeros
                    .Where(c => c.Id == id)
                    .FirstOrDefault();

                if (aux != null)
                    repetir = true;

            } while (repetir);

            return id;
        }


        public static string ConvertirSha256(string texto)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));
                foreach (byte b in result)
                {
                    sb.Append(b.ToString("x2"));
                }
            }
            return sb.ToString();
        }
        
        
        #endregion
    }
}
