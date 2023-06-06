using Application.Exceptions;
using Application.Interfaces.IApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Client
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
        public dynamic GetAllViajesWithLocalization(string localizacion)
        {
            string url = $"/api/ViajeCiudad?localizacion={localizacion}";
            HttpResponseMessage response = _httpClient.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                dynamic transporte = response.Content.ReadAsAsync<dynamic>().Result;
                return transporte;
            }
            else
            {
                throw new NotFoundException($"Error al obtener el Transporte. Código de respuesta: {response.StatusCode}");
            }

        }
    }
}

//HttpResponseMessage response = _httpClient.GetAsync($"/api/Destinos/ViajeCiudad").Result;

//if (response.IsSuccessStatusCode)
//{
//    dynamic destino = response.Content.ReadAsAsync<dynamic>().Result;
//    return destino;
//}
//else
//{
//    throw new NotFoundException($"Error al obtener el Destino. Código de respuesta: {response.StatusCode}");
//}
