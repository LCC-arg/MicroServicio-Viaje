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

        public ViajeQuery(ViajeContext context, IDestinoApi destinoApi)
        {
            _context = context;
            _destinoApi = destinoApi;
        }

        public Viaje GetViajeById(int viajeId)
        {
            var viaje = _context.Viajes.FirstOrDefault(x => x.ViajeId == viajeId);

            return viaje;
        }

        public List<Viaje> GetViajeList()
        {
            var viajeList = _context.Viajes.ToList();

            return viajeList;
        }

        public List<Viaje> GetViajeListFilters(string tipo, string fechaSalida, string fechaLlegada, int empresaId, int ciudadOrigen, int ciudadDestino)
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

                viajeList = viajesCiudadOrigen;
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

                viajeList = viajesCiudadDestino;
            }

            if (fechaSalida != null)
            {
                DateTime dateTime = DateTime.Parse(fechaSalida);
                viajeList = viajeList.Where(p => p.FechaSalida == dateTime).ToList();
            }

            if (fechaLlegada != null)
            {
                DateTime dateTime = DateTime.Parse(fechaLlegada);
                viajeList = viajeList.Where(p => p.FechaLlegada == dateTime).ToList();
            }

            if (tipo != null)
            {
                viajeList = viajeList.Where(p => p.TipoViaje.ToLower() == tipo.ToLower()).ToList();
            }

            if (empresaId != 0)
            {
                viajeList = viajeList.Where(p => p.TransporteId == empresaId).ToList();
            }

            return viajeList;
        }
    }
}
