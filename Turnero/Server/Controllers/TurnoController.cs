using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
        //public async Task<ActionResult<ResponseDto<string>>> ConsultarTurnoReservado(ConsultaTurnoDto Consulta)
        public async Task<ActionResult<ResponseDto<List<Turno>>>> ConsultarTurnoReservado(ConsultaTurnoDto Consulta)
        {
            ResponseDto<List<Turno>> Response = new ResponseDto<List<Turno>>();

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

                List<Turno> TurnosPeluquero = await this._context.TablaTurnos
                    .Where(Turno => Turno.PeluqueroId == Consulta.IdPeluquero)
                    .Include(Turno => Turno.Peluquero)
                    .Include(Turno => Turno.Cliente)
                    .ToListAsync();


                if (TurnosPeluquero == null)
                {
                    throw new Exception("No se ha encotrado a este peluquero.");
                }

                /* CONTINUA TODO LO RELACIONADO A LA LOGICA
                 -> Buscar datos peluquero ( + validaciones )
                 -> Agregar tiempo extra a la FechaHoraCorte
                 -> Buscar turnos con la fecha coincicente entre FechaHoraCorte + Extra. ( + validaciones ) 
                 
                 */

                // TODO: VER DE QUE NO ME DEVUELVE TODOS LSO DATOS SINO ALGUNOS NULL, VER QUE ESTA RELACIONADO CON EL PROGRAM.CS Linea 55
                Response.Data = TurnosPeluquero;

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
