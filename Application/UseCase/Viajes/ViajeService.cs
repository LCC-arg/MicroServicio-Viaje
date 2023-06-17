using Application.Interfaces;
using Application.Interfaces.IApi;
using Application.Request;
using Application.Response;
using Domain.Entities;
using Newtonsoft.Json.Linq;

namespace Application.UseCase.Viajes
{
    public class ViajeService : IViajeService
    {
        private readonly IViajeCommand _command;
        private readonly IViajeQuery _query;

        private readonly IDestinoApi _destinoApi;
        private readonly IServicioApi _servicioApi;

        public ViajeService(IViajeCommand command, IViajeQuery query, IDestinoApi destinoApi, IServicioApi servicioApi)
        {
            _command = command;
            _query = query;
            _destinoApi = destinoApi;
            _servicioApi = servicioApi;
        }

        public ViajeResponse GetViajeById(int viajeId)
        {
            var viaje = _query.GetViajeById(viajeId);

            if (viaje == null)
            {
                throw new ArgumentException($"No se encontró el viaje con el identificador {viajeId}.");
            }

            return MappingViaje(viaje);
        }

        public List<ViajeResponse> GetViajeListFilters(string tipo, string fechaSalida, string fechaLlegada, int empresaId, int ciudadOrigen, int ciudadDestino)
        {
            var viajeList = _query.GetViajeListFilters(tipo, fechaSalida, fechaLlegada, empresaId, ciudadOrigen, ciudadDestino);

            List<ViajeResponse> viajeResponseList = new List<ViajeResponse>();

            foreach (var viaje in viajeList)
            {
                viajeResponseList.Add(MappingViaje(viaje));
            }

            return viajeResponseList;
        }

        public ViajeResponse CreateViaje(ViajeRequest request)
        {
            var viaje = new Viaje
            {
                TransporteId = request.TransporteId,
                Duracion = request.Duracion,
                FechaLlegada = DateTime.Parse(request.FechaLlegada),
                FechaSalida = DateTime.Parse(request.FechaLlegada),
                TipoViaje = request.TipoViaje,
            };

            var viajeInserte = _command.InsertViaje(viaje);

            _destinoApi.CreateViajeCiudad(viajeInserte.ViajeId, request.CiudadOrigen, "Origen");

            foreach (var escala in request.Escalas)
            {
                _destinoApi.CreateViajeCiudad(viajeInserte.ViajeId, escala, "Escala");
            }

            _destinoApi.CreateViajeCiudad(viajeInserte.ViajeId, request.CiudadDestino, "Destino");

            foreach (var servicio in request.Servicios)
            {
                _servicioApi.CreateViajeServicio(viajeInserte.ViajeId, servicio);
            }

            return new ViajeResponse
            {
                Id = viaje.ViajeId,
                TransporteId = viaje.TransporteId,
                Duracion = viaje.Duracion,
                FechaSalida = viaje.FechaSalida,
                FechaLlegada = viaje.FechaLlegada,
                TipoViaje = viaje.TipoViaje,
                CiudadOrigen = request.CiudadOrigen,
                CiudadDestino = request.CiudadDestino,
                Escalas = request.Escalas,
                Servicios = request.Servicios,
            };
        }

        public ViajeResponse RemoveViaje(int viajeId)
        {
            if (_query.GetViajeById(viajeId) == null)
            {
                throw new ArgumentException($"No se encontró el viaje que desea eliminar con el identificador '{viajeId}'.");
            }

            var viaje = _command.RemoveViaje(viajeId);

            return MappingViaje(viaje);
        }

        public ViajeResponse UpdateViaje(int viajeId, ViajeRequest request)
        {
            var viaje = _query.GetViajeById(viajeId);

            if (viaje == null)
            {
                throw new ArgumentException($"No se encontró el viaje con el identificador {viajeId}.");
            }

            viaje.TransporteId = request.TransporteId;
            viaje.Duracion = request.Duracion;
            viaje.FechaLlegada = DateTime.Parse(request.FechaLlegada);
            viaje.FechaSalida = DateTime.Parse(request.FechaSalida);
            viaje.TipoViaje = request.TipoViaje;

            _command.UpdateViaje(viaje);

            return new ViajeResponse
            {
                Id = viaje.ViajeId,
                TransporteId = viaje.TransporteId,
                Duracion = viaje.Duracion,
                FechaSalida = viaje.FechaSalida,
                FechaLlegada = viaje.FechaLlegada,
                TipoViaje = viaje.TipoViaje
            };
        }

        private ViajeResponse MappingViaje(Viaje viaje)
        {
            var listaJsonViajes = _destinoApi.ObtenerViajeList(viaje.ViajeId);

            var listaJsonServicio = _servicioApi.ObtenerServicioList(viaje.ViajeId);

            int ciudadOrigenResponse = 0;
            int ciudadDestinoResponse = 0;

            List<int> escalas = new List<int>();
            List<int> servicios = new List<int>();

            foreach (object json in listaJsonViajes)
            {
                string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(json);
                JToken token = JToken.Parse(jsonString);

                int idCiudad = (int)token.SelectToken("ciudad.id");
                string tipoCiudad = (string)token.SelectToken("tipo");

                if (tipoCiudad == "Origen")
                {
                    ciudadOrigenResponse = idCiudad;
                }

                if (tipoCiudad == "Destino")
                {
                    ciudadDestinoResponse = idCiudad;
                }

                if (tipoCiudad == "Escala")
                {
                    escalas.Add(idCiudad);
                }
            }

            foreach (var json in listaJsonServicio)
            {
                string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(json);
                JToken token = JToken.Parse(jsonString);

                int idServicio = (int)token.SelectToken("servicioId");

                servicios.Add(idServicio);
            }

            return new ViajeResponse
            {
                Id = viaje.ViajeId,
                TransporteId = viaje.TransporteId,
                Duracion = viaje.Duracion,
                FechaSalida = viaje.FechaSalida,
                FechaLlegada = viaje.FechaLlegada,
                TipoViaje = viaje.TipoViaje,
                CiudadOrigen = ciudadOrigenResponse,
                CiudadDestino = ciudadDestinoResponse,
                Escalas = escalas,
                Servicios = servicios
            };
        }
    }
}
