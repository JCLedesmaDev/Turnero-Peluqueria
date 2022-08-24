using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Turnero.BaseDatos.Data;
using Turnero.BaseDatos.Data.Entidades;
using System.Text.Json;

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
        public async Task<ActionResult<ResponseDto<string>>> ConsultarTurno(ConsultaTurnoDto Consulta)
        {
            ResponseDto<string> Response = new ResponseDto<string>();

            try
            {
                bool FechaValidate = Consulta?.FechaHoraCorte == null || Consulta.FechaHoraCorte <= DateTime.Now;
                bool IdPeluqueroValidate = Consulta?.IdPeluquero == null || Consulta?.IdPeluquero == 0;

                if (!TryValidateModel(Consulta) || FechaValidate || IdPeluqueroValidate)
                {
                    if (FechaValidate)
                    {
                        ModelState.AddModelError(
                            "Fecha Hora Corte", "La fecha debe ser mayor o igual a la fecha actual"
                        );
                    }

                    if (IdPeluqueroValidate)
                    {
                        ModelState.AddModelError(
                            "Peluquero", "Debe ingresar el Id del peluquero."
                        );
                    }

                    throw new InvalidDataException(
                        JsonSerializer.Serialize(
                             ErrorHelper.GetModelStateErrors(ModelState)
                        ).ToString()
                    );
                }

                /* CONTINUA TODO LO RELACIONADO A LA LOGICA
                 -> Buscar datos peluquero ( + validaciones )
                 -> Agregar tiempo extra a la FechaHoraCorte
                 -> Buscar turnos con la fecha coincicente entre FechaHoraCorte + Extra. ( + validaciones ) 
                 
                 */


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
