using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoyViajero.BBDD.Data;
using SoyViajero.BBDD.Data.Entidades;


namespace SoyViajero.Server.Controllers
{
    [ApiController]
    [Route("api/Comentario")]
    public class ComentarioController : ControllerBase
    {
        private readonly Context context;

        public ComentarioController(Context contexto)
        {
            this.context = contexto;
        }

        #region Get

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Comentario>> Get(int id)
        {
            var comentario = await context.Comentarios.Where(x => x.ID == id).FirstOrDefaultAsync();
            if (comentario == null)
            {
                return NotFound($"No existe un comentario de ID={id}");
            }
            return comentario;
        }
        #endregion

        #region Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(Comentario coment)
        {
            try
            {
                context.Comentarios.Add(coment);
                await context.SaveChangesAsync();
                return coment.ID;
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
            var comentSeleccionado = context.Comentarios.Where(e => e.ID == id).FirstOrDefault();
            if (comentSeleccionado == null)
            {
                return NotFound($"No se encontró el comentario {id}");
            }
            try
            {
                context.Comentarios.Remove(comentSeleccionado);
                context.SaveChanges();
                return Ok($"El comentario {comentSeleccionado} se ha eliminado correctamente");
            }
            catch (Exception e)
            {
                return BadRequest($"El comentario no pudo ser eliminado. {e.Message}");

            }

        }
        #endregion

    }
}
