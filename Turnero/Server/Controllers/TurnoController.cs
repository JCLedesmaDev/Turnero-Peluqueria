using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Turnero.BaseDatos.Data;
using Turnero.BaseDatos.Data.Entidades;
using System.Text.Json;
using Turnero.Shared.Comun;

namespace Turnero.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurnoController : ControllerBase
    {

        private readonly BDContext _context;
        //private readonly ErrorHelper _errorHelper;

        public TurnoController(BDContext BDContext)
        {
            this._context = BDContext;
        }

        [HttpPost("consult")]
        public async Task<ActionResult<Response<string>>> ConsultarTurno(DateTime FechaHora, PeluqueroDto Peluquero)
        {

            Response<string> Response = new Response<string>();

            try
            {
                /// TODO: Agregar validacion de fecha.
                    
                if (!TryValidateModel(Peluquero))
                {
                    throw new InvalidDataException(
                        JsonSerializer.Serialize(
                             ErrorHelper.GetModelStateErrors(ModelState)
                        ).ToString()
                    );
                }

                Response.Data = "LALALLA";

            }
            catch (InvalidDataException ex) 
            {
                Response.ErrorModels = JsonSerializer.Deserialize <List<ModelErrors>>(ex.Message);
                return BadRequest(Response);
            }
            catch (Exception ex)
            {
                Response.MessageError = ex.Message;
                return BadRequest(Response);
            }
            
            return Ok(Response);
        }
    }
}
