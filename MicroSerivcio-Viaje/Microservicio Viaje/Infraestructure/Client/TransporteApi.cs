using Application.Exceptions;
using Application.Interfaces.IApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Infraestructure.Client.TransporteApi;

namespace Infraestructure.Client
{
    public class TransporteApi : ITransporteApi
    {

        private readonly HttpClient _httpClient;

        public TransporteApi()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7155/api/");
         }

        public dynamic GetTransporteById(int transporteId)
        {
           HttpResponseMessage response = _httpClient.GetAsync($"v1/Transporte/{transporteId}").Result;

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
