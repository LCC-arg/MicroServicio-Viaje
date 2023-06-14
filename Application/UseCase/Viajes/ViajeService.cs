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

        public List<ViajeResponse> GetViajeList()
        {
            throw new NotImplementedException();
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

            _destinoApi.CreateViajeCiudad(viajeInserte.ViajeId, request.CiudadOrigen);

            foreach (var escala in request.Escalas)
            {
                _destinoApi.CreateViajeCiudad(viajeInserte.ViajeId, escala);
            }

            _destinoApi.CreateViajeCiudad(viajeInserte.ViajeId, request.CiudadOrigen);

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
            throw new NotImplementedException();
        }

        public ViajeResponse UpdateViaje(int viajeId, ViajeRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
