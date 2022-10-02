using System.Net.Http.Json;
using Turnero.Shared.DTO_Back;
using Turnero.Shared.DTO_Front;

namespace Turnero.Client.Service
{
    public class TurnoService
    {

        private readonly HttpClient http;

        public TurnoService(HttpClient http)
        {
            this.http = http;
        }


        public async Task<(string, string)> consultarTurnoReservado(ConsultaTurnoDto Consulta)
        {

            HttpResponseMessage resultHttp = await this.http.PostAsJsonAsync("api/Turno/consultarTurnoReservado", Consulta);

            var data = await resultHttp.Content.ReadFromJsonAsync<ResponseDto<string>>();

            return (data.result, data.messageError);
        }
    }
}