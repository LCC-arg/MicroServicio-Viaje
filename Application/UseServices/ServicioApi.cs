using Application.Interfaces.IApi;
using Newtonsoft.Json;
using System.Text;

namespace Infraestructure.UseServices
{
    public class ServicioApi : IServicioApi
    {
        private readonly HttpClient _httpClient;

        public ServicioApi()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7040");
        }

        public dynamic CreateViajeServicio(int viajeId, int servicioId)
        {
            var diccionario = new Dictionary<string, int>
            {
                {"viajeId", viajeId},
                {"servicioId" ,servicioId},
            };

            string json = JsonConvert.SerializeObject(diccionario);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = _httpClient.PostAsync($"/api/ViajeServicio", data).Result;

            if (response.IsSuccessStatusCode)
            {
                dynamic responseBody = response.Content.ReadAsStringAsync().Result;
                return responseBody;
            }
            else
            {
                throw new Exception($"Error al crear viaje servicio. Código de respuesta: {response.StatusCode}");
            }
        }
    }
}
