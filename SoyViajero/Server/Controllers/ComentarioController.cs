using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoyViajero.BBDD.Data;
using SoyViajero.BBDD.Data.Entidades;

using Microsoft.AspNetCore.Authorization;


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
            try
            {
                var cuentaActiva = Convert.ToString(User.Claims.Where(x => x.Type == "cuentaActiva").Select(c => c.Value).First());

                var comentario = await context.Comentarios.Where(x => x.ID == id).FirstOrDefaultAsync();
                //if (comentario == null)
                //{
                //    return NotFound($"No existe un comentario de ID={id}");
                //}
                return comentario;
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }

        
        [HttpGet("/Comentarios/{id:int}")]
        public async Task<ActionResult<List<Comentario>>> GetId(int id)
        {
            try
            {

                var comentarios = await context.Comentarios
                        .Where(x => x.PublicacionId == id)
                        .ToListAsync();

                foreach (var comentario in comentarios)
                {
                    if (comentario.CuentasId.Contains("h"))
                    {
                        comentario.Nombre = await context.CuentasHostel
                                        .Where(x=>x.Id == comentario.CuentasId)
                                        .Select(x=>x.Nombre).FirstOrDefaultAsync();
                    }
                    else
                    {
                        comentario.Nombre = await context.CuentasViajeros
                                            .Where(x => x.Id == comentario.CuentasId)
                                            .Select(c => c.Nombre)
                                            .FirstOrDefaultAsync() +" ";
                        comentario.Nombre += await context.CuentasViajeros
                                            .Where(x => x.Id == comentario.CuentasId)
                                            .Select(c => c.Apellido)
                                            .FirstOrDefaultAsync();
                    }
                }

                return comentarios;
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }
        #endregion

        #region Post
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Comentario>> Post(Comentario coment)
        {
            try
            {
                coment.CuentasId = User.Claims.Where(x => x.Type == "cuentaActiva").Select(c => c.Value).First();

                context.Comentarios.Add(coment);
                await context.SaveChangesAsync();
                return Ok(); 
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        #endregion

        #region Delete
        [Authorize]
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
