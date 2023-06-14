using Application.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Infraestructure.UseServices
{
    public class DestinoApi : IDestinoApi
    {

        private readonly HttpClient _httpClient;

        public DestinoApi()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7018");
        }

        public dynamic CreateViajeCiudad(int viajeId, int ciudadId)
        {
            var diccionario = new Dictionary<string, int>
            {
                {"viajeId", viajeId},
                {"ciudadId" ,ciudadId}
            };

            string json = JsonConvert.SerializeObject(diccionario);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = _httpClient.PostAsync($"/api/ViajeCiudad", data).Result;

            if (response.IsSuccessStatusCode)
            {
                dynamic responseBody = response.Content.ReadAsStringAsync().Result;
                return responseBody;
            }
            else
            {
                throw new Exception($"Error al crear viaje ciudad. Código de respuesta: {response.StatusCode}");
            }
        }
    }
}