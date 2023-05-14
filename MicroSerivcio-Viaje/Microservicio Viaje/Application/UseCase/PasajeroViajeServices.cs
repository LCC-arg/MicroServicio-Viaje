using Application.Interfaces.ICommands;
using Application.Interfaces.IQuerys;
using Application.Interfaces.IServices;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class PasajeroViajeServices : IPasajeroViajeServices
    {
        private readonly IPasajeroViajeCommand _pasajeroViajeCommand;
        private readonly IPasajeroViajeQuery _pasajeroViajeQuery;
        private readonly IPasajeroQuery _pasajeroQuery;
        private readonly IViajeQuery _viajeQuery;

        public PasajeroViajeServices(IPasajeroViajeCommand pasajeroViajeCommand, IPasajeroViajeQuery pasajeroViajeQuery, IPasajeroQuery pasajeroQuery, IViajeQuery viajeQuery)
        {
            _pasajeroViajeCommand = pasajeroViajeCommand;
            _pasajeroViajeQuery = pasajeroViajeQuery;
            _pasajeroQuery = pasajeroQuery;
            _viajeQuery = viajeQuery;
        }

        public IEnumerable<PasajeroViaje> GetAllPasajeroViajes()
        {
            throw new NotImplementedException();
        }

        public PasajeroViajeResponse GetPasajeroViajeById(int pasajeroViajeId)
        {
            var pasajeroViaje = _pasajeroViajeQuery.GetById(pasajeroViajeId);
            var viaje = _viajeQuery.GetById(pasajeroViaje.ViajeId);
            var pasajero = _pasajeroQuery.GetById(pasajeroViaje.PasajeroId);
            if(pasajeroViaje != null)
            {
                PasajeroViajeResponse pasajeroViajeResponse = new PasajeroViajeResponse
                {
                    pasajero = new PasajeroResponse
                    {
                        id = pasajero.PasajeroId,
                        nombre = pasajero.Nombre,
                        apellido = pasajero.Apellido,
                        dni = pasajero.Dni,
                        fechaNacimiento = pasajero.FechaNacimiento,
                        genero = pasajero.Genero,
                        numContactoEmergencia = pasajero.NumContactoEmergencia,
                        viaje = new ViajeResponse
                        {
                            id = viaje.ViajeId,
                            ciudadOrigen = viaje.CiudadOrigen,
                            ciudadDestino = viaje.CiudadDestino,
                            transporteId = viaje.TransporteId,
                            duracion = viaje.Duracion,
                            horarioSalida = viaje.HorarioSalida,
                            horarioLlegada = viaje.HorarioLlegada,
                            fechaSalida = viaje.FechaSalida,
                            fechaLlegada = viaje.FechaLlegada,
                            tipoViaje = viaje.TipoViaje
                        }
                    }
                };
                return pasajeroViajeResponse;
            }
            return null;
        }
    }
}
