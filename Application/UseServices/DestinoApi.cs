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
            _httpClient.BaseAddress = new Uri("https://localhost:7018/api/");
        }

        public dynamic ObtenerViajeList()
        {
            HttpResponseMessage response = _httpClient.GetAsync($"ViajeCiudad").Result;

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

        public dynamic ObtenerViajeList(int viajeId)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"ViajeCiudad?viajeId={viajeId}").Result;

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

        public dynamic CreateViajeCiudad(int viajeId, int ciudadId, string tipo)
        {
            var diccionario = new Dictionary<string, object>
            {
                {"viajeId", viajeId},
                {"ciudadId" ,ciudadId},
                {"tipo",tipo}
            };

            string json = JsonConvert.SerializeObject(diccionario);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = _httpClient.PostAsync($"ViajeCiudad", data).Result;

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