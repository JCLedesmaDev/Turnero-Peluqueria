using System.Collections.Generic;
using System.Net.Http.Json;
using Turnero.Shared.DTO_Back;
using Turnero.Shared.DTO_Back.Peluquero;

namespace Turnero.Client.Service
{
    public class PeluqueroService
    {

        private readonly HttpClient http;

        public PeluqueroService(HttpClient http)
        {
            this.http = http;
        }


        public async Task<(List<PeluqueroData>, string)> GetAll()
        {

            ResponseDto<List<PeluqueroData>> resultHttp = await this.http.GetFromJsonAsync<ResponseDto<List<PeluqueroData>>>("api/Peluquero/GetAll");

            return (resultHttp.Result, resultHttp.MessageError);
        }

    }
}
