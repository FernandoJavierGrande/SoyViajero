using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoyViajero.BBDD.Data;
using SoyViajero.BBDD.Data.Entidades;

namespace SoyViajero.Server.Controllers
{
    [ApiController]
    [Route("api/Publicacion")]
    public class PublicacionController : ControllerBase
    {
        private readonly Context context;

        public PublicacionController(Context contexto)
        {
            this.context = contexto;
        }

        #region GET
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
        public async Task<ActionResult<int>> Post(Publicacion publica)
        {
            try
            {
                context.Publicaciones.Add(publica);
                await context.SaveChangesAsync();
                return publica.ID;
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

