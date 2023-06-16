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
            _httpClient.BaseAddress = new Uri("https://localhost:7040/api/");
        }

        public dynamic ObtenerServicioList(int viajeId)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"ViajeServicio?viajeId={viajeId}").Result;

            if (response.IsSuccessStatusCode)
            {

                dynamic viaje = response.Content.ReadAsAsync<dynamic>().Result;
                return viaje;
            }
            else
            {
                throw new Exception($"Error al crear viaje ciudad. Código de respuesta: {response.StatusCode}");
            }
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

            HttpResponseMessage response = _httpClient.PostAsync($"ViajeServicio", data).Result;

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
