using System.Net.Http.Json;
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


        public async Task<List<PeluqueroData>> GetAll()
        {

            var resultHttp = await this.http.GetFromJsonAsync<List<PeluqueroData>>("api/Peluquero/GetAll");


            Console.WriteLine(resultHttp);

            return new List<PeluqueroData>();
        }

    }
}
