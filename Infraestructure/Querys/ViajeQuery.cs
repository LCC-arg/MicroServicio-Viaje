using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Newtonsoft.Json.Linq;

namespace Infraestructure.Querys
{
    public class ViajeQuery : IViajeQuery
    {
        private readonly ViajeContext _context;
        private readonly IDestinoApi _destinoApi;
        private readonly ITransporteApi _transporteApi;

        public ViajeQuery(ViajeContext context, IDestinoApi destinoApi, ITransporteApi transporteApi)
        {
            _context = context;
            _destinoApi = destinoApi;
            _transporteApi = transporteApi;
        }

        public Viaje GetViajeById(int viajeId)
        {
            var viaje = _context.Viajes.FirstOrDefault(x => x.ViajeId == viajeId);

            return viaje;
        }

        public Viaje GetViajeList(int transporteId)
        {
            var viajeList = _context.Viajes.FirstOrDefault(p => p.TransporteId == transporteId);

            return viajeList;
        }

        public List<Viaje> GetViajeListFilters(string tipo, string fechaSalida, string fechaLlegada, string empresa, string compania, int ciudadOrigen, int ciudadDestino, int pasajesDisponibles, string orden)
        {
            var viajeList = _context.Viajes.ToList();

            if (ciudadOrigen != 0)
            {
                var listaJson = _destinoApi.ObtenerViajeList();
                var viajesCiudadOrigen = new List<Viaje>();

                foreach (object json in listaJson)
                {
                    string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(json);
                    JToken token = JToken.Parse(jsonString);

                    int idCiudad = (int)token.SelectToken("ciudad.id");
                    string tipoCiudad = (string)token.SelectToken("tipo");
                    int idViaje = (int)token.SelectToken("viajeId");

                    if (idCiudad == ciudadOrigen && tipoCiudad == "Origen")
                    {
                        var viajeCiudadOrigen = GetViajeById(idViaje);
                        viajesCiudadOrigen.Add(viajeCiudadOrigen);
                    }
                }

                if (viajeList.Count != 0)
                {
                    viajeList = viajeList.Intersect(viajesCiudadOrigen).ToList();
                }
            }

            if (ciudadDestino != 0)
            {
                var listaJson = _destinoApi.ObtenerViajeList();
                var viajesCiudadDestino = new List<Viaje>();

                foreach (object json in listaJson)
                {
                    string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(json);
                    JToken token = JToken.Parse(jsonString);

                    int idCiudad = (int)token.SelectToken("ciudad.id");
                    string tipoCiudad = (string)token.SelectToken("tipo");
                    int idViaje = (int)token.SelectToken("viajeId");


                    if (idCiudad == ciudadDestino)
                    {
                        if (tipoCiudad == "Destino" || tipoCiudad == "Escala")
                        {
                            var viajeCiudadDestino = GetViajeById(idViaje);
                            viajesCiudadDestino.Add(viajeCiudadDestino);
                        }
                    }
                }

                if (viajeList.Count != 0)
                {
                    viajeList = viajeList.Intersect(viajesCiudadDestino).ToList();
                }
            }

            if (empresa != null)
            {
                viajeList = viajeList.Where(viaje =>
                {
                    var transporte = _transporteApi.ObtenerTransporte(viaje.TransporteId);
                    string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(transporte);
                    JToken token = JToken.Parse(jsonString);
                    string empresaRazonSocial = (string)token.SelectToken("companiaTransporteResponse.razonSocial");
                    return empresa.ToLower() == empresaRazonSocial.ToLower();
                }).ToList();
            }

            if (compania != null)
            {
                viajeList = viajeList.Where(viaje =>
                {
                    var transporte = _transporteApi.ObtenerTransporte(viaje.TransporteId);
                    string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(transporte);
                    JToken token = JToken.Parse(jsonString);
                    string empresaRazonSocial = (string)token.SelectToken("tipoTransporteResponse.descripcion");
                    return compania.ToLower() == empresaRazonSocial.ToLower();
                }).ToList();
            }

            if (fechaSalida != null)
            {
                DateTime dateTime = DateTime.Parse(fechaSalida);
                dateTime = dateTime.Date;
                viajeList = viajeList.Where(p => p.FechaSalida.Date == dateTime).ToList();
            }

            if (fechaLlegada != null)
            {
                DateTime dateTime = DateTime.Parse(fechaLlegada);
                dateTime = dateTime.Date;
                viajeList = viajeList.Where(p => p.FechaLlegada.Date == dateTime).ToList();
            }

            if (tipo != null)
            {
                viajeList = viajeList.Where(p => p.TipoViaje.ToLower() == tipo.ToLower()).ToList();
            }

            if (pasajesDisponibles != 0)
            {
                viajeList = viajeList.Where(p => p.AsientosDisponibles >= pasajesDisponibles).ToList();
            }

            if (orden.ToLower() == "mayor precio")
            {
                viajeList = viajeList.OrderByDescending(p => p.Precio).ToList();
            }
            else
            {
                viajeList = viajeList.OrderBy(p => p.Precio).ToList();
            }

            return viajeList;
        }
    }
}
    