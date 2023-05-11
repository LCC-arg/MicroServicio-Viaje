using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PasajeroViaje
    {
        public int PasajeroViajeId { get; set; }
        public int PasajeroId { get; set; }
        public int ViajeId { get; set; }
        
        public Pasajero Pasajero { get; set; }
        public Viaje Viaje { get; set; }
    }
}
