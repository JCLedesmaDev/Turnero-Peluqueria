﻿using Microsoft.AspNetCore.Mvc;

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
            ResponseDto<string> ResponseDto = new ResponseDto<string>();

            try
            {

                if (Consulta?.IdPeluquero == null || Consulta?.IdPeluquero == 0)
                {
                    throw new Exception("debe seleccionar un peluquero.");
                }

                if (Consulta?.FechaHoraCorte == null)
                {
                    throw new Exception("la fecha debe ser mayor o igual a la fecha actual");
                }

                Peluquero? peluquero = await this._context.TablaPeluqueros
                    .FirstOrDefaultAsync(Peluquero => Peluquero.Id == Consulta.IdPeluquero);

                if (peluquero == null)
                {
                    throw new Exception("No se ha encontrado a este peluquero.");
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

                //ResponseDto.result = "La fecha ingresada se encuentra disponible para reservar.¿Desea reservarlo?";
                ResponseDto.result = "La fecha ingresada se encuentra disponible para reservar.";

                return Ok(ResponseDto);
            }
            catch (Exception ex)
            {
                ResponseDto.messageError = $"Ha ocurrido un error, {ex.Message}";
                return BadRequest(ResponseDto);
            }

        }
    }
}




//               | -----------------[  ]---------------- |
//             17.15                 17:30                 18:00


//             Agregar a 17.30, margen de 15 min antes y depues del horario de corte.

//              {
//                "idPeluquero": 11,
//                "fechaHoraCorte": "2022-09-23T16:30:00.444Z"
//              }