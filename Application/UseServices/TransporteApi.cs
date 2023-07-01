using Application.Interfaces;

namespace Application.UseServices
{
    public class TransporteApi : ITransporteApi
    {
        private readonly HttpClient _httpClient;

        public TransporteApi()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7155/api/");
        }

        public dynamic ObtenerCaracteristicaTransporteList()
        {
            HttpResponseMessage response = _httpClient.GetAsync("CaracteristicaTransporte").Result;

            if (response.IsSuccessStatusCode)
            {

                dynamic viaje = response.Content.ReadAsAsync<dynamic>().Result;
                return viaje;
            }
            else
            {
                throw new ArgumentException($"Error al crear viajeServicio. Código de respuesta: {response.StatusCode}");
            }
        }
    }
}
