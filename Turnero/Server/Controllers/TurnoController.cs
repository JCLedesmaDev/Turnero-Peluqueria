using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Turnero.BaseDatos.Data;
using Turnero.BaseDatos.Data.Entidades;


namespace Turnero.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurnoController : ControllerBase
    {

        private readonly BDContext _context;

        public TurnoController(BDContext BDContext)
        {
            this._context = BDContext;
        }

        [HttpPost("consult")]
        public async Task<IActionResult> consultarTurno(DateTime FechaHora, Peluquero peluquero)
        {

            if (!ModelState.IsValid)
            { 
               ModelState.Values
               .SelectMany(v => v.Errors)
               .Select(e => e.ErrorMessage);                
            }

            return Ok("PUTO");
        }
    }
}
