﻿using Application.Exceptions;
using Application.Interfaces.IApi;
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
        private readonly ITransporteApi _transporteApi;

        public ViajeServices(IViajeCommand viajeCommand, IViajeQuery viajeQuery, ITransporteApi transporteApi)
        {
            _viajeCommand = viajeCommand;
            _viajeQuery = viajeQuery;
            _transporteApi = transporteApi;
        }

        public ViajeResponse AddViaje(Viaje viaje)
        {
            throw new NotImplementedException();
        }

        public ViajeResponse CreateViaje(ViajeRequest viajeRequest)
        {


            if (!int.TryParse(viajeRequest.ciudadOrigen.ToString(), out _))
            {
                throw new BadRequestException("Formato de ciudad origen ingresado incorrecto");
            }
            else if (!int.TryParse(viajeRequest.ciudadDestino.ToString(), out _))
            {
                throw new BadRequestException("Formato de ciudad destino ingresado incorrecto");
            }
            else if (!int.TryParse(viajeRequest.transporteId.ToString(), out _))
            {
                throw new BadRequestException("Formato de ciudad transporte ingresado incorrecto");
            }
            else if(!DateTime.TryParse(viajeRequest.horarioSalida.ToString(), out _))
            {
                throw new BadRequestException("Formato de horario de salida invalido");
            }
            else if (!DateTime.TryParse(viajeRequest.horarioLlegada.ToString(), out _))
            {
                throw new BadRequestException("Formato de horario de llegada invalido");
            }
            else if (!DateTime.TryParse(viajeRequest.fechaSalida.ToString(), out _))
            {
                throw new BadRequestException("Formato de fecha de salida invalido");
            }
            else if (!DateTime.TryParse(viajeRequest.fechaLlegada.ToString(), out _))
            {
                throw new BadRequestException("Formato de fecha de llegada invalido");
            }

            Viaje newViaje = new Viaje
            {
                CiudadOrigen = viajeRequest.ciudadOrigen,
                CiudadDestino = viajeRequest.ciudadDestino,
                TransporteId = viajeRequest.transporteId,
                Duracion = viajeRequest.duracion,
                HorarioSalida = viajeRequest.horarioSalida,
                HorarioLlegada = viajeRequest.horarioLlegada,
                FechaSalida = viajeRequest.fechaSalida,
                FechaLlegada = viajeRequest.fechaLlegada,
                TipoViaje = viajeRequest.tipoViaje
            };

            TransporteResponse response = Response(newViaje.TransporteId);
            var result =  _viajeCommand.Insert(newViaje);




            ViajeResponse viajeResponse = new ViajeResponse
            {
                id = result.ViajeId,
                ciudadOrigen = result.CiudadOrigen,
                ciudadDestino = result.CiudadDestino,
                transporte = response,
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
            if (!int.TryParse(viajeId.ToString(), out _))
            {
                throw new BadRequestException("Formato del Id de viaje incorrecto");
            }

            var viaje = _viajeCommand.Delete(viajeId);

            if (viaje == null)
            {
                throw new BadRequestException("No existe un viaje con ese Id");
            }
            if(viaje.Pasajeros.Count != 0)
            {
                throw new HasConflictException("No se puede eliminar el viaje ya que posee pasajeros");
            }

            TransporteResponse response = Response(viaje.TransporteId);

            return new ViajeResponse
            {
                id = viaje.ViajeId,
                ciudadOrigen = viaje.CiudadOrigen,
                ciudadDestino = viaje.CiudadDestino,
                transporte = response,
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
            if (int.TryParse(viajeId.ToString(), out _))
            {
                throw new BadRequestException("Formato de id del viaje invalido");
            }

            var viaje= _viajeQuery.GetById(viajeId);
            TransporteResponse response = Response(viaje.TransporteId);
            if (viaje != null)
            {
                ViajeResponse viajeResponse = new ViajeResponse
                {
                    id = viaje.ViajeId,
                    ciudadOrigen = viaje.CiudadOrigen,
                    ciudadDestino = viaje.CiudadDestino,
                    transporte = response,
                    duracion = viaje.Duracion,
                    horarioSalida = viaje.HorarioSalida,
                    horarioLlegada = viaje.HorarioLlegada,
                    fechaSalida = viaje.FechaSalida,
                    fechaLlegada = viaje.FechaLlegada,
                    tipoViaje = viaje.TipoViaje
                };
                return viajeResponse;
            }
            throw new NotFoundException("No existe viaje con ese Id");
        }

        public List<GetAllPasajerosByIdResponse> GetAllPasajerosById(int viajeId) 
        {
            if (int.TryParse(viajeId.ToString(), out _))
            {
                throw new BadRequestException("Formato de id del viaje invalido");
            }

            var viaje = _viajeQuery.GetById(viajeId);
            
            if(viaje != null) 
            {
                List<GetAllPasajerosByIdResponse> pasajerosResponse = new List<GetAllPasajerosByIdResponse>();
                foreach (Pasajero pasajero in viaje.Pasajeros)
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

            throw new NotFoundException("No existe un viaje con ese id");
        }



        public ViajeResponse UpdateViaje(int viajeId, ViajeRequest viajeRequest)
        {
            _viajeCommand.Update(viajeId, viajeRequest);
            Viaje viaje = _viajeQuery.GetById(viajeId);

            if (viaje == null) 
            { 
                return null; 
            }
            TransporteResponse response = Response(viaje.TransporteId);
            return new ViajeResponse
            {
                id = viaje.ViajeId,
                ciudadOrigen = viaje.CiudadOrigen,
                ciudadDestino = viaje.CiudadDestino,
                transporte = response,
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

            if (!DateTime.TryParse(fechaSalida.ToString(), out _))
            {
                throw new BadRequestException("El formato de la fecha de salida es invalido");
            }
            if (!DateTime.TryParse(fechaLlegada.ToString(), out _))
            {
                throw new BadRequestException("El formato de la fecha de llegada es invalido");
            }
            var viajes = _viajeQuery.GetViajes(tipo, fechaSalida, fechaLlegada);
            List<ViajeResponse> viajeResponses = new List<ViajeResponse>();
            if(viajes != null)
            {
                foreach(Viaje viaje in viajes) 
                {
                    TransporteResponse response = Response(viaje.TransporteId);
                    ViajeResponse viajeResponse = new ViajeResponse
                    {
                        id = viaje.ViajeId,
                        ciudadOrigen = viaje.CiudadOrigen,
                        ciudadDestino = viaje.CiudadDestino,
                        transporte = response,
                        duracion = viaje.Duracion,
                        horarioSalida = viaje.HorarioSalida,
                        horarioLlegada = viaje.HorarioLlegada,
                        fechaSalida = viaje.FechaSalida,
                        fechaLlegada = viaje.FechaLlegada,
                        tipoViaje = viaje.TipoViaje
                    };
                    viajeResponses.Add(viajeResponse);
                }
            }
            return viajeResponses;
        }
        private TransporteResponse Response(int transporteId) 
        {
            TransporteResponse response = _transporteApi.GetTransporteById(transporteId);
            return response;
        }
    }
}
