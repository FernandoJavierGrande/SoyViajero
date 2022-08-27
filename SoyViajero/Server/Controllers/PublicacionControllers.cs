using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoyViajero.BBDD.Data;
using SoyViajero.BBDD.Data.Entidades;

using Microsoft.AspNetCore.Authorization;


namespace SoyViajero.Server.Controllers
{
    [ApiController]
    [Route("api/Publicacion")]
    [Authorize]
    public class PublicacionController : ControllerBase
    {
        private readonly Context context;

        public PublicacionController(Context contexto)
        {
            this.context = contexto;
        }


        #region GET
        [HttpGet("/Publicaciones")]
        public async Task<ActionResult<List<Publicacion>>> Get()
        {
            var CuentaActivaId = User.Claims.Where(c => c.Type == "cuentaActiva").Select(x => x.Value).FirstOrDefault();
            if (CuentaActivaId == null)
                return NotFound();

            var publicaciones = await context.Publicaciones
                                .Where(p => p.CuentasId == CuentaActivaId)
                                .ToListAsync();
            
            if (publicaciones == null)
            {
                return NotFound($"No hay publicaciones para mostrar");
            }
            return publicaciones;
        }


        [HttpGet("{id:int}")] //METODO HTTP GET. ASICRONA. 
        public async Task<ActionResult<Publicacion>> Get(int id)
        {
            var publicacion = await context.Publicaciones.Where
                                (p => p.ID == id).FirstOrDefaultAsync();
            if (publicacion == null)
            {
                return NotFound($"No existe una publicacion de Id= {id}");
            }
            return publicacion;
        }
        #endregion

        #region post
        [HttpPost]
        public async Task<ActionResult<int>> Post(Publicacion publicacion)
        {
            try
            {   /*obtiene id de la cuenta que se encuentra activa/en uso */
                var cuentaActivaId = User.Claims.Where(c => c.Type == "cuentaActiva").Select(x => x.Value).FirstOrDefault();

                if (cuentaActivaId == null)
                    return NotFound("No se puede realizar la publicacion");

                /*usa la cuenta h o v activa para realizar la publicacion bajo esa cuenta*/
                publicacion.CuentasId = cuentaActivaId;


                context.Publicaciones.Add(publicacion);
                await context.SaveChangesAsync();
                return publicacion.ID;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region Delete
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var publicaSeleccionado = context.Publicaciones.Where
                              (p => p.ID == id).FirstOrDefault();
            if (publicaSeleccionado == null)
            {
                return NotFound($"No se encontró el comentario {id}");
            }
            try
            {
                context.Publicaciones.Remove(publicaSeleccionado);
                context.SaveChanges();
                return Ok($"La publicacion {publicaSeleccionado} se ha eliminado correctamente");
            }
            catch (Exception e)
            {
                return BadRequest($"La publicacion no pudo ser eliminada. {e.Message}");
            }
        }
        #endregion
    }
}

