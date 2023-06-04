using Application.Exceptions;
using Application.Interfaces.IApi;
using Application.Interfaces.ICommands;
using Application.Interfaces.IQuerys;
using Application.Interfaces.IServices;
using Application.Request;
using Application.Response;
using Application.Response.Ciudad;
using Application.Response.Pais;
using Application.Response.Provincia;
using Application.Response.ViajeCiudad;
using Domain.Entities;
using Newtonsoft.Json;
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
        private readonly IDestinoApi _destinoApi;
        private readonly IServicioApi _servicioApi;

        public ViajeServices(IViajeCommand viajeCommand, IViajeQuery viajeQuery, ITransporteApi transporteApi, IDestinoApi destinoApi, IServicioApi servicioApi)
        {
            _viajeCommand = viajeCommand;
            _viajeQuery = viajeQuery;
            _transporteApi = transporteApi;
            _destinoApi = destinoApi;
            _servicioApi = servicioApi;

        }

        public ViajeResponse AddViaje(Viaje viaje)
        {
            throw new NotImplementedException();
        }

        public ViajeResponse CreateViaje(ViajeRequest viajeRequest)
        {

            if (!int.TryParse(viajeRequest.transporteId.ToString(), out _))
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
                TransporteId = viajeRequest.transporteId,
                Duracion = viajeRequest.duracion,
                HorarioSalida = DateTime.Parse(viajeRequest.horarioSalida),
                HorarioLlegada = DateTime.Parse(viajeRequest.horarioLlegada),
                FechaSalida = DateTime.Parse(viajeRequest.fechaSalida),
                FechaLlegada = DateTime.Parse(viajeRequest.fechaLlegada),
                TipoViaje = viajeRequest.tipoViaje,
                
            };
            dynamic response = Response(newViaje.TransporteId);


            var viaje =  _viajeCommand.Insert(newViaje);
            dynamic responseOrigen = ResponseCiudades(viaje.ViajeId, viajeRequest.ciudades[0]);
            dynamic responseDestino = ResponseCiudades(viaje.ViajeId, viajeRequest.ciudades[1]);

            foreach(int servicio in viajeRequest.servicios)
            {
                dynamic responseServicio = ResponseServicios(viaje.ViajeId, servicio);
            }

            return new ViajeResponse
            {
                id = viaje.ViajeId,              
                transporte = new TransporteResponse
                {
                    id = response.id,
                    tipoTransporte = new TipoTransporteResponse
                    {
                        id = response.tipoTransporteResponse.id,
                        descripcion = response.tipoTransporteResponse.descripcion
                    },
                    companiaTransporte = new CompaniaTransporteResponse
                    {
                        id = response.companiaTransporteResponse.id,
                        razonSocial = response.companiaTransporteResponse.razonSocial,
                        cuit = response.companiaTransporteResponse.cuit
                    }
                },
                duracion = viaje.Duracion,
                horarioSalida = viaje.HorarioSalida,
                horarioLlegada = viaje.HorarioLlegada,
                fechaSalida = viaje.FechaSalida,
                fechaLlegada = viaje.FechaLlegada,
                tipoViaje = viaje.TipoViaje
            };
        }

        public ViajeResponse DeleteViaje(int viajeId)
        {
            if (!int.TryParse(viajeId.ToString(), out _))
            {
                throw new BadRequestException("Formato del Id de viaje incorrecto");
            }
            var viaje = _viajeQuery.GetById(viajeId);
            if (viaje.Pasajeros.Count != 0)
            {
                throw new HasConflictException("No se puede eliminar el viaje ya que posee pasajeros");
            }

            viaje = _viajeCommand.Delete(viajeId);

            dynamic response = Response(viaje.TransporteId);


            return new ViajeResponse
            {
                id = viaje.ViajeId,     
                transporte = new TransporteResponse
                {
                    id = response.id,
                    tipoTransporte = new TipoTransporteResponse
                    {
                        id = response.tipoTransporteResponse.id,
                        descripcion = response.tipoTransporteResponse.descripcion
                    },
                    companiaTransporte = new CompaniaTransporteResponse
                    {
                        id = response.companiaTransporteResponse.id,
                        razonSocial = response.companiaTransporteResponse.razonSocial,
                        cuit = response.companiaTransporteResponse.cuit
                    }
                },
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
            if (!int.TryParse(viajeId.ToString(), out _))
            {
                throw new BadRequestException("Formato de id del viaje invalido");
            }

            var viaje= _viajeQuery.GetById(viajeId);
            dynamic response = Response(viaje.TransporteId);

            if (viaje != null)
            {
                return new ViajeResponse
                {
                    id = viaje.ViajeId,                
                    transporte = new TransporteResponse
                    {
                        id = response.id,
                        tipoTransporte = new TipoTransporteResponse
                        {
                            id = response.tipoTransporteResponse.id,
                            descripcion = response.tipoTransporteResponse.descripcion
                        },
                        companiaTransporte = new CompaniaTransporteResponse
                        {
                            id = response.companiaTransporteResponse.id,
                            razonSocial = response.companiaTransporteResponse.razonSocial,
                            cuit = response.companiaTransporteResponse.cuit
                        }
                    },
                    duracion = viaje.Duracion,
                    horarioSalida = viaje.HorarioSalida,
                    horarioLlegada = viaje.HorarioLlegada,
                    fechaSalida = viaje.FechaSalida,
                    fechaLlegada = viaje.FechaLlegada,
                    tipoViaje = viaje.TipoViaje
                };
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

            dynamic responseTransporte = Response(viaje.TransporteId);


            return new ViajeResponse
            {
                id = viaje.ViajeId,
               
                transporte = new TransporteResponse
                {
                    id = responseTransporte.id,
                    tipoTransporte = new TipoTransporteResponse
                    {
                        id = responseTransporte.tipoTransporteResponse.id,
                        descripcion = responseTransporte.tipoTransporteResponse.descripcion
                    },
                    companiaTransporte = new CompaniaTransporteResponse
                    {
                        id = responseTransporte.companiaTransporteResponse.id,
                        razonSocial = responseTransporte.companiaTransporteResponse.razonSocial,
                        cuit = responseTransporte.companiaTransporteResponse.cuit
                    }
                },
                duracion = viaje.Duracion,
                horarioSalida = viaje.HorarioSalida,
                horarioLlegada = viaje.HorarioLlegada,
                fechaSalida = viaje.FechaSalida,
                fechaLlegada = viaje.FechaLlegada,
                tipoViaje = viaje.TipoViaje
            };
        }

        public IEnumerable<ViajeResponse> GetViajes(string? tipo, string? fechaSalida, string? fechaLlegada)
        {


            var viajes = _viajeQuery.GetViajes(tipo, fechaSalida, fechaLlegada);
            List<ViajeResponse> viajeResponses = new List<ViajeResponse>();
            if(viajes != null)
            {
                foreach(Viaje viaje in viajes) 
                {
                    dynamic response = Response(viaje.TransporteId);



                    ViajeResponse viajeResponse = new ViajeResponse
                    {
                        id = viaje.ViajeId,                   
                        transporte = new TransporteResponse
                        {
                            id = response.id,
                            tipoTransporte = new TipoTransporteResponse
                            {
                                id = response.tipoTransporteResponse.id,
                                descripcion = response.tipoTransporteResponse.descripcion
                            },
                            companiaTransporte = new CompaniaTransporteResponse
                            {
                                id = response.companiaTransporteResponse.id,
                                razonSocial = response.companiaTransporteResponse.razonSocial,
                                cuit = response.companiaTransporteResponse.cuit
                            }
                        },
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


        private dynamic Response(int transporteId) 
        {
            dynamic response = _transporteApi.GetTransporteById(transporteId);
            return response;
        }
        private dynamic ResponseCiudades(int viajeId, int ciudadId)
        {
            dynamic response = _destinoApi.CreateViajeCiudad(viajeId, ciudadId);
            return response;

        }
        private dynamic ResponseServicios(int viajeId, int servicioId)
        {
            dynamic response = _servicioApi.CreateViajeServicio(viajeId, servicioId);
            return response;
        }

        private dynamic ResponseViajeWithLocation(string localizacion)
        {
            dynamic response = _destinoApi.GetAllViajesWithLocalization(localizacion);
            return response;
        }

        public IEnumerable<ViajeResponse> viajesWithLocation(string? localizacion)
        {
            dynamic response = ResponseViajeWithLocation(localizacion);
            List<int> viajesIds = new List<int>();

            if (response != null)
            {
                string jsonString = response.ToString(); 
                List<dynamic> viajesJson = JsonConvert.DeserializeObject<List<dynamic>>(jsonString);

                foreach (dynamic viajeJson in viajesJson)
                {
                    int viajeId = viajeJson.viajeId;
                    viajesIds.Add(viajeId);
                }
            }
            var viajes = _viajeQuery.GetViajesWithLocation(viajesIds);
            List<ViajeResponse> viajeResponses = new List<ViajeResponse>();

            if (viajes != null)
            {
                foreach (Viaje viaje in viajes)
                {
                    dynamic responseTransporte = Response(viaje.TransporteId);

                    ViajeResponse viajeResponse = new ViajeResponse
                    {
                        id = viaje.ViajeId,
                        transporte = new TransporteResponse
                        {
                            id = responseTransporte.id,
                            tipoTransporte = new TipoTransporteResponse
                            {
                                id = responseTransporte.tipoTransporteResponse.id,
                                descripcion = responseTransporte.tipoTransporteResponse.descripcion
                            },
                            companiaTransporte = new CompaniaTransporteResponse
                            {
                                id = responseTransporte.companiaTransporteResponse.id,
                                razonSocial = responseTransporte.companiaTransporteResponse.razonSocial,
                                cuit = responseTransporte.companiaTransporteResponse.cuit
                            }
                        },
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


    }
    
}
