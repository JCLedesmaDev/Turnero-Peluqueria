using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
        public async Task<ActionResult<ResponseDto<List<Peluquero>>>> GetAll ()
        {
            ResponseDto<List<Peluquero>> Response = new ResponseDto<List<Peluquero>>();

            try
            {
                List<Peluquero>? Peluqueros = await this._context.TablaPeluqueros.ToListAsync();

                Response.Result = Peluqueros;

                return Ok(Response);
            }
            catch (Exception ex)
            {
                Response.MessageError = ex.Message;
                return BadRequest(Response);
            }
            
        }
    }
}


