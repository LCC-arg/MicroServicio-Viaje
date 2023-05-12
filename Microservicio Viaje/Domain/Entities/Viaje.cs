using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Viaje
    {
        public int ViajeId { get; set; }
        public int CiudadOrigen { get; set; }
        public int CiudadDestino { get; set; }
        public int TransporteId { get; set; }
        public int ServicioId { get; set; } //No va más
        public string Duracion { get; set; }
        public DateTime HorarioSalida { get; set; }
        public DateTime HorarioLlegada { get; set; }
        public DateTime FechaLlegada { get; set; }
        public DateTime FechaSalida { get; set; }
        public string TipoViaje { get; set; }

        public List<PasajeroViaje> PasajeroViajes { get; set; }
       
    }
}
