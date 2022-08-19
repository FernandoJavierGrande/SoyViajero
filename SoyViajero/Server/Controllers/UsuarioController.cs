using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoyViajero.BBDD.Data;
using SoyViajero.BBDD.Data.Entidades;

namespace SoyViajero.Server.Controllers
{
    [ApiController]
    [Route("api/Usuario")]
    public class UsuarioController :ControllerBase
    {
        private readonly Context context;   

        public UsuarioController(Context context) =>this.context = context;


        #region Getsss
        [HttpGet]
        public async Task<ActionResult<List<Cuenta>>> Get(string user)
        {
            int IdUser = (from u in context.Usuarios where u.NombreUser == user /*&& u.Pass == pass*/ select u).First().Id;

            Console.WriteLine("id de user" + IdUser.ToString());

            var cuentas = await context.Cuenta.Where(c => c.UsuarioId == IdUser).Include(x => x.CuentaViajero).Include(x=>x.CuentaHotel).ToListAsync();

            return cuentas;
        }
        #endregion
    }
}
