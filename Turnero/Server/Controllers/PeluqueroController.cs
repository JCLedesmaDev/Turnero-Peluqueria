using Microsoft.AspNetCore.Mvc;
using Turnero.Shared.DTO_Back.Peluquero;

namespace Turnero.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeluqueroController : ControllerBase
    {

        private readonly BDContext _context;

        public PeluqueroController(BDContext BDContext)
        {
            this._context = BDContext;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ResponseDto<List<PeluqueroData>>>> GetAll()
        {
            ResponseDto<List<PeluqueroData>> ResponseDto = new ResponseDto<List<PeluqueroData>>();

            try
            {
                List<Peluquero>? Peluqueros = await this._context.TablaPeluqueros.ToListAsync();


                List<PeluqueroData> ListaPeluquerosMapper = new List<PeluqueroData>();

                Peluqueros.ForEach(peluquero =>
                {
                    ListaPeluquerosMapper.Add(new PeluqueroData
                    {
                        Id = peluquero.Id,
                        Apellido = peluquero.Apellido,
                        DNI = peluquero.DNI,
                        ImagenPerfil = peluquero.ImagenPerfil,
                        Nombre = peluquero.Nombre
                    });
                });


                ResponseDto.result = ListaPeluquerosMapper;

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


