using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoyViajero.BBDD.Data;
using SoyViajero.BBDD.Data.Entidades;

namespace SoyViajero.Server.Controllers
{
    [ApiController]
    [Route("api/hostels")]
    public class HostelController : ControllerBase
    {
        private readonly Context context;

        public HostelController(Context context) => this.context = context;
        
        [HttpGet("{nombre}")]
        public async Task<ActionResult<List<CuentaHostel>>> Get(string nombre)
        {
            List<CuentaHostel> hostels = new List<CuentaHostel>();

            try
            {
                hostels = await context.CuentasHostel.Where(n => n.Ciudad.Contains(nombre)).ToListAsync();

                var hostPorNombre = await context.CuentasHostel.Where(n => n.Nombre.Contains(nombre)).ToListAsync(); 

                if (hostPorNombre.Count > 0)
                {
                    if (hostels.Count > 0)
                    {
                        for (int i = 0; i < hostels.Count; i++)
                        {
                            if (hostPorNombre.Contains(hostels[i]))
                            {
                                hostPorNombre.Remove(hostels[i]);
                            }
                        }
                    }
                    hostels.AddRange(hostPorNombre);
                }
                return hostels;
            }
            catch (Exception) { return NotFound(); }
        }
    }
}
