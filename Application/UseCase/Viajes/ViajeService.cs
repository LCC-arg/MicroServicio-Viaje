using Application.Interfaces;
using Application.Interfaces.IApi;
using Application.Request;
using Application.Response;
using Domain.Entities;

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

        public List<Viaje> GetViajeList()
        {
            return _query.GetViajeList();
        }

        public List<ViajeResponse> GetViajeListFilters(string tipo, string fechaSalida, string fechaLlegada, int empresaId)
        {
            var viajeList = _query.GetViajeListFilters(tipo, fechaSalida, fechaLlegada, empresaId);

            List<ViajeResponse> viajeResponseList = new List<ViajeResponse>();

            foreach (var viaje in viajeList)
            {
                var viajeResponse = new ViajeResponse
                {
                    Id = viaje.ViajeId,
                    TransporteId = viaje.TransporteId,
                    Duracion = viaje.Duracion,
                    FechaSalida = viaje.FechaSalida,
                    FechaLlegada = viaje.FechaLlegada,
                    TipoViaje = viaje.TipoViaje
                };
                viajeResponseList.Add(viajeResponse);
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

            _destinoApi.CreateViajeCiudad(viajeInserte.ViajeId, request.CiudadOrigen,"Origen");

            foreach (var escala in request.Escalas)
            {
                _destinoApi.CreateViajeCiudad(viajeInserte.ViajeId, escala, "Escala");
            }

            _destinoApi.CreateViajeCiudad(viajeInserte.ViajeId, request.CiudadOrigen, "Destino");

            foreach(var servicio in request.Servicios)
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
                TipoViaje = viaje.TipoViaje
            };
        }

        public ViajeResponse RemoveViaje(int viajeId)
        {
            if (_query.GetViajeById(viajeId) == null)
            {
                throw new ArgumentException($"No se encontró el viaje que desea eliminar con el identificador '{viajeId}'.");
            }

            var viaje = _command.RemoveViaje(viajeId);

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
    }
}
