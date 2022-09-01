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

        [HttpPost("consultarTurnoReservado")]
        public async Task<ActionResult<ResponseDto<string>>> ConsultarTurnoReservado(ConsultaTurnoDto Consulta)
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

                Peluquero peluquero = await this._context.TablaPeluqueros
                    .FirstOrDefaultAsync( Peluquero => Peluquero.Id == Consulta.IdPeluquero);

                if (peluquero == null)
                {
                    throw new Exception("No se ha encotrado a este peluquero.");
                }

                List<Turno> TurnosReservados = await this._context.TablaTurnos
                    .Where(Turno => Turno.PeluqueroId == Consulta.IdPeluquero)
                    .Where(Turno => 
                        Consulta.FechaHoraCorte > Turno.FechaTurnoReservado.AddMinutes(MargenTurno.RestarExtraTiempo) && //Esto no esta en la entrevista...
                        Consulta.FechaHoraCorte <= Turno.FechaTurnoReservado.AddMinutes(MargenTurno.SumarExtraTiempo)
                     ) // Observar
                    .Include(Turno => Turno.Peluquero)
                    .Include(Turno => Turno.Cliente)
                    .ToListAsync();


                if (TurnosReservados.Count != 0)
                {
                    throw new Exception("La fecha ingresada no se encuentra disponible para reservar.");
                }

                Response.Data = "La fecha ingresada se encuentra disponible para reservar.¿Desea reservarlo?";

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
