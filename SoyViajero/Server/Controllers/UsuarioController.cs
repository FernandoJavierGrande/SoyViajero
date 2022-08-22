using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoyViajero.BBDD.Data;
using SoyViajero.BBDD.Data.Entidades;

namespace SoyViajero.Server.Controllers
{
    [ApiController]
    [Route("api/Usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly Context context;

        public UsuarioController(Context context) => this.context = context;


        #region Getsss
        [HttpGet]
        public async Task<ActionResult<Usuario>> Get(string user)
        {
            int IdUser;
            try
            {
                IdUser = (from u in context.Usuarios where u.NombreUser == user /*&& u.Pass == pass*/ select u).First().Id;

            }
            catch (Exception)
            {

                return BadRequest("El usuario o contraseña no son correctos");
            }

            var cuentas = await context.Usuarios
                            .Where(u => u.Id == IdUser)
                            .Include(h => h.cuentasHostel)
                            .Include(v => v.cuentaViajero)
                            .FirstOrDefaultAsync();

            return cuentas;
        }
        #endregion

        #region post
        [HttpPost]
        public async Task<ActionResult<bool>> Post(Usuario usuario)
        {

            try
            {
                if (!UserExist(usuario.NombreUser))
                    return BadRequest($"El usuario {usuario.NombreUser} ya existe");

                context.Usuarios.Add(usuario);

                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest("Error al agregar nuevo usuario");
            }

        }

        
        [HttpPost("/AgregarHostel")]
        public async Task<ActionResult<CuentaHostel>>post(CuentaHostel hostel)
        {

            
            if (!UserExist(hostel.UsuarioId))
            {
                try
                {
                    hostel.Id = IdCuentaH();
                    context.CuentasHostel.Add(hostel);
                    await context.SaveChangesAsync();
                    return Ok();
                }
                catch (Exception e)
                {
                    return BadRequest("Error al Guardar el nuevo hostel " + e );
                }
            }
            else
                return NotFound();
        }

        

        [HttpPost("/AgregarViajero")]
        public async Task<ActionResult<CuentaHostel>> post(CuentaViajero viajero)
        {
            if (!UserExist(viajero.UsuarioId))
            {

                var cuentaV = context.CuentasViajeros.Where(c => c.UsuarioId == viajero.UsuarioId).Select
                    (x => x.Id).FirstOrDefault();

                if (cuentaV!=null)
                    return BadRequest("No se puede agregar otra cuenta de 'Viajero', pero puedes modificar los datos de la que ya tienes ");
                try
                {
                    viajero.Id = IdCuentaV();

                    context.CuentasViajeros.Add(viajero);
                    await context.SaveChangesAsync();
                    return Ok();
                }
                catch (Exception e)
                {
                    return BadRequest("Error al Guardar el nuevo hostel " + e);
                }
            }
            else
                return NotFound();
        }

        #endregion

        #region Delete
        [HttpDelete("/eliminarCuentaViajero")]
        public async Task<ActionResult> delete(int idUser)
        {
            if (UserExist(idUser))
                return  NotFound("Error, intente nuevamente");

            var viajeroElim = context.CuentasViajeros
                .Where(c => c.UsuarioId == idUser)
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

        private bool UserExist(string userName) //confirma si el usuario con nombre x existe
        {
            var user = context.Usuarios.Where(u => u.NombreUser == userName).FirstOrDefault();
            if (user != null)
                return false;
            return true;
        }
        private bool UserExist(int userId) // cpnfirma si existe un usuario por medio del id
        {
            var user = context.Usuarios.Where(u => u.Id == userId).FirstOrDefault();
            if (user != null)
                return false;
            return true;
        }
      

        private string IdCuentaH() // generan ids aleatorios con identificador segun el tipo de cuenta
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
        #endregion
    }
}
