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
    public class PasajeroServices : IPasajeroServices
    {
        private readonly IPasajeroCommand _pasajeroCommand;
        private readonly IPasajeroQuery _pasajeroQuery;
        private readonly IViajeQuery _viajeQuery;

        public PasajeroServices(IPasajeroCommand pasajeroCommand, IPasajeroQuery pasajeroQuery, IViajeQuery viajeQuery)
        {
            _pasajeroCommand = pasajeroCommand;
            _pasajeroQuery = pasajeroQuery;
            _viajeQuery = viajeQuery;
        }

        public PasajeroResponse AddPasajero(Pasajero pasajero)
        {
            throw new NotImplementedException();
        }

        public PasajeroResponse CreatePasajero(PasajeroRequest pasajeroRequest)
        {
            var result = _pasajeroCommand.Create(pasajeroRequest);
            PasajeroResponse pasajeroResponse = new PasajeroResponse
            {
                id = result.PasajeroId,
                nombre = result.Nombre,
                apellido = result.Apellido,
                dni = result.Dni,
                fechaNacimiento = result.FechaNacimiento,
                genero = result.Genero,
                numContactoEmergencia = result.NumContactoEmergencia,
                viaje = new ViajeResponse
                {
                    id = result.ViajeId,
                    ciudadOrigen = result.Viaje.CiudadOrigen,
                    ciudadDestino = result.Viaje.CiudadDestino,
                    transporteId = result.Viaje.TransporteId,
                    duracion = result.Viaje.Duracion,
                    horarioSalida = result.Viaje.HorarioSalida,
                    horarioLlegada = result.Viaje.HorarioLlegada,
                    fechaSalida = result.Viaje.FechaSalida,
                    fechaLlegada = result.Viaje.FechaLlegada,
                    tipoViaje = result.Viaje.TipoViaje
                }
            };
            return pasajeroResponse;
        }


        public PasajeroResponse DeletePasajero(int pasajeroId)
        {
            var pasajero = _pasajeroCommand.Delete(pasajeroId);

            if(pasajero == null) 
            {
                return null;
            }
            return new PasajeroResponse
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
                    id = pasajero.ViajeId,
                    ciudadOrigen = pasajero.Viaje.CiudadOrigen,
                    ciudadDestino = pasajero.Viaje.CiudadDestino,
                    transporteId = pasajero.Viaje.TransporteId,
                    duracion = pasajero.Viaje.Duracion,
                    horarioSalida = pasajero.Viaje.HorarioSalida,
                    horarioLlegada = pasajero.Viaje.HorarioLlegada,
                    fechaSalida = pasajero.Viaje.FechaSalida,
                    fechaLlegada = pasajero.Viaje.FechaLlegada,
                    tipoViaje = pasajero.Viaje.TipoViaje
                }
            };

        }

        public IEnumerable<PasajeroResponse> GetAllPasajeros()
        {
            throw new NotImplementedException();
        }

        public PasajeroResponse GetPasajeroById(int pasajeroId)
        {
            var pasajero = _pasajeroQuery.GetById(pasajeroId);
            var viaje = _viajeQuery.GetById(pasajero.ViajeId);
            if(pasajero != null) 
            {
                PasajeroResponse pasajeroResponse = new PasajeroResponse
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
                };
                return pasajeroResponse;
            }
            return null;
        }

        public IEnumerable<PasajeroResponse> GetPasajeros(string? nombre, string? apellido, DateTime? fechaNacimiento, int? dni, string? nacionalidad, string? genero)
        {
            var pasajeros = _pasajeroQuery.GetPasajeros(nombre, apellido, fechaNacimiento, dni, genero, nacionalidad);
            List<PasajeroResponse> pasajerosResponses = new List<PasajeroResponse>();    
            if (pasajeros != null) 
            {
                foreach(Pasajero pasajero in pasajeros)
                {
                    PasajeroResponse pasajeroResponse = new PasajeroResponse
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
                            id = pasajero.Viaje.ViajeId,
                            ciudadOrigen = pasajero.Viaje.CiudadOrigen,
                            ciudadDestino = pasajero.Viaje.CiudadDestino,
                            transporteId = pasajero.Viaje.TransporteId,
                            duracion = pasajero.Viaje.Duracion,
                            horarioSalida = pasajero.Viaje.HorarioSalida,
                            horarioLlegada = pasajero.Viaje.HorarioLlegada,
                            fechaSalida = pasajero.Viaje.FechaSalida,
                            fechaLlegada = pasajero.Viaje.FechaLlegada,
                            tipoViaje = pasajero.Viaje.TipoViaje
                        }
                    };
                    pasajerosResponses.Add(pasajeroResponse);  
                }
                return pasajerosResponses;
            }
            return null;
        }

        public PasajeroResponse UpdatePasajero(int pasajeroId, PasajeroRequest pasajeroRequest)
        {
            _pasajeroCommand.Update(pasajeroId, pasajeroRequest);
            Pasajero pasajero = _pasajeroQuery.GetById(pasajeroId);
            Viaje viaje = _viajeQuery.GetById(pasajeroRequest.viajeId);
            return new PasajeroResponse
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
            };



        }
    }
}
