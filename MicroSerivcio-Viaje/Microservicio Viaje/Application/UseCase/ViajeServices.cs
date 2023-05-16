using Application.Interfaces.ICommands;
using Application.Interfaces.IQuerys;
using Application.Interfaces.IServices;
using Application.Request;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class ViajeServices : IViajeServices
    {
        private readonly IViajeCommand _viajeCommand;
        private readonly IViajeQuery _viajeQuery;

        public ViajeServices(IViajeCommand viajeCommand, IViajeQuery viajeQuery)
        {
            _viajeCommand = viajeCommand;
            _viajeQuery = viajeQuery;
        }

        public ViajeResponse AddViaje(Viaje viaje)
        {
            throw new NotImplementedException();
        }

        public ViajeResponse CreateViaje(ViajeRequest viajeRequest)
        {
            var result = _viajeCommand.Create(viajeRequest);
            ViajeResponse viajeResponse = new ViajeResponse
            {
                id = result.ViajeId,
                ciudadOrigen = result.CiudadOrigen,
                ciudadDestino = result.CiudadDestino,
                transporteId = result.TransporteId,
                duracion = result.Duracion,
                horarioSalida = result.HorarioSalida,
                horarioLlegada = result.HorarioLlegada,
                fechaSalida = result.FechaSalida,
                fechaLlegada = result.FechaLlegada,
                tipoViaje = result.TipoViaje
            };
            return viajeResponse;
        }

        public ViajeResponse DeleteViaje(int viajeId)
        {
            var viaje = _viajeCommand.Delete(viajeId);

            if (viaje == null)
            {
                return null;
            }
            
            return new ViajeResponse
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
            };

        }

        public IEnumerable<ViajeResponse> GetAllViajes()
        {
            throw new NotImplementedException();
        }

        public ViajeResponse GetViajeById(int viajeId)
        {
            var viaje= _viajeQuery.GetById(viajeId);
            if (viaje != null)
            {
                ViajeResponse viajeResponse = new ViajeResponse
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
                };
                return viajeResponse;
            }
            return null;
        }

        public List<GetAllPasajerosByIdResponse> GetAllPasajerosById(int viajeId) 
        {
            var viaje = _viajeQuery.GetById(viajeId);
            if(viaje == null) 
            {
                throw new InvalidOperationException("El viaje no existe en la base de datos");
            }
            List<GetAllPasajerosByIdResponse> pasajerosResponse = new List<GetAllPasajerosByIdResponse>();    
            if(viaje != null) 
            {
                foreach(Pasajero pasajero in viaje.Pasajeros)
                {
                    GetAllPasajerosByIdResponse getAllPasajerosByIdResponse = new GetAllPasajerosByIdResponse
                    {
                        id = pasajero.PasajeroId,
                        nombre = pasajero.Nombre,
                        apellido = pasajero.Apellido,
                        dni = pasajero.Dni,
                        fechaNacimiento = pasajero.FechaNacimiento,
                        genero = pasajero.Genero,
                        numContactoEmergencia = pasajero.NumContactoEmergencia,
                    };
                    pasajerosResponse.Add(getAllPasajerosByIdResponse);
                }
                return pasajerosResponse;
            }
            return null;
        }



        public ViajeResponse UpdateViaje(int viajeId, ViajeRequest viajeRequest)
        {
            _viajeCommand.Update(viajeId, viajeRequest);
            Viaje viaje = _viajeQuery.GetById(viajeId);

            if (viaje == null) 
            { 
                return null; 
            }

            return new ViajeResponse
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
            };
        }

        public IEnumerable<ViajeResponse> GetViajes(string? tipo, DateTime? fechaSalida, DateTime? fechaLlegada)
        {
            var viajes = _viajeQuery.GetViajes(tipo, fechaSalida, fechaLlegada);
            List<ViajeResponse> viajeResponses = new List<ViajeResponse>();
            if(viajes != null)
            {
                foreach(Viaje viaje in viajes) 
                {
                    ViajeResponse viajeResponse = new ViajeResponse
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
                    };
                    viajeResponses.Add(viajeResponse);
                }
                return viajeResponses;
            }
            return null;
        }
    }
}
