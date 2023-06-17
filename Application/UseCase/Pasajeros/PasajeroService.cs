using Application.Interfaces;
using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.UseCase.Pasajeros
{
    public class PasajeroService : IPasajeroService
    {
        private readonly IPasajeroCommand _command;
        private readonly IPasajeroQuery _query;

        private readonly IViajeQuery _viajeQuery;

        public PasajeroService(IPasajeroCommand command, IPasajeroQuery query, IViajeQuery viajeQuery)
        {
            _command = command;
            _query = query;
            _viajeQuery = viajeQuery;
        }

        public PasajeroResponse GetPasajeroById(int pasajeroId)
        {
            var pasajero = _query.GetPasajeroById(pasajeroId);

            if (pasajero == null)
            {
                throw new ArgumentException($"No se encontró el pasajero con el identificador {pasajeroId}.");
            }

            return MappingPasajero(pasajero);
        }

        public List<PasajeroResponse> GetPasajeroList()
        {
            var pasajeroList = _query.GetPasajeroList();

            List<PasajeroResponse> pasajeroResponseList = new List<PasajeroResponse>();

            foreach(var pasajero in pasajeroList) 
            {
                pasajeroResponseList.Add(MappingPasajero(pasajero));
            }

            return pasajeroResponseList;
        }

        public PasajeroResponse CreatePasajero(PasajeroRequest request)
        {
            if (_viajeQuery.GetViajeById(request.ViajeId) == null)
            {
                throw new ArgumentException($"No se encontró el viaje con el identificador {request.ViajeId}.");
            }

            var pasajero = new Pasajero
            {
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                Dni = request.Dni,
                FechaNacimiento = request.FechaNacimiento,
                Genero = request.Genero,
                NumContactoEmergencia = request.NumContactoEmergencia,
                Nacionalidad = request.Nacionalidad,
                ViajeId = request.ViajeId,
                Viaje = _viajeQuery.GetViajeById(request.ViajeId),
            };

            _command.InsertPasajero(pasajero);

            return MappingPasajero(pasajero);
        }

        public PasajeroResponse RemovePasajero(int pasajeroId)
        {
            if (_query.GetPasajeroById(pasajeroId) == null)
            {
                throw new ArgumentException($"No se encontro el pasajero que desea eliminar con el identificador '{pasajeroId}'.");
            }

            var pasajero = _command.RemovePasajero(pasajeroId);

            return MappingPasajero(pasajero);
        }

        public PasajeroResponse UpdatePasajero(int pasajeroId, PasajeroRequest request)
        {
            var pasajero = _query.GetPasajeroById(pasajeroId);

            if (pasajero == null)
            {
                throw new ArgumentException($"No se encontró el pasajero con el identificador {pasajeroId}.");
            }

            if (_viajeQuery.GetViajeById(request.ViajeId) == null)
            {
                throw new Exception($"No se encontró el viaje con el identificador {request.ViajeId}.");
            }

            pasajero.Nombre = request.Nombre;
            pasajero.Apellido = request.Apellido;
            pasajero.Dni = request.Dni;
            pasajero.FechaNacimiento = request.FechaNacimiento;
            pasajero.Genero = request.Genero;
            pasajero.NumContactoEmergencia = request.NumContactoEmergencia;
            pasajero.Nacionalidad = request.Nacionalidad;
            pasajero.ViajeId = request.ViajeId;
            pasajero.Viaje = _viajeQuery.GetViajeById(request.ViajeId);

            _command.InsertPasajero(pasajero);

            return MappingPasajero(pasajero);
        }

        private static PasajeroResponse MappingPasajero(Pasajero pasajero)
        {
            return new PasajeroResponse
            {
                Nombre = pasajero.Nombre,
                Apellido = pasajero.Apellido,
                Dni = pasajero.Dni,
                FechaNacimiento = pasajero.FechaNacimiento,
                Genero = pasajero.Genero,
                NumContactoEmergencia = pasajero.NumContactoEmergencia,
                Nacionalidad = pasajero.Nacionalidad,

                Viaje = new ViajeGetResponse
                {
                    Id = pasajero.Viaje.ViajeId,
                    TransporteId = pasajero.Viaje.TransporteId,
                    Duracion = pasajero.Viaje.Duracion,
                    FechaSalida = pasajero.Viaje.FechaSalida,
                    FechaLlegada = pasajero.Viaje.FechaLlegada,
                    TipoViaje = pasajero.Viaje.TipoViaje,
                }
            };
        }
    }
}
