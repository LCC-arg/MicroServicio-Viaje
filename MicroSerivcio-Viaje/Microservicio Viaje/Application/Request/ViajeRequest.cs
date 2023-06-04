using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
    public class ViajeRequest
    {
        public int transporteId { get; set; }
        public string duracion { get; set; }
        public string horarioSalida { get; set; }
        public string horarioLlegada { get; set; }
        public string fechaLlegada { get; set; }
        public string fechaSalida { get; set; }
        public string tipoViaje { get; set; }
        public List<int> ciudades { get; set; }
        public List<int> servicios { get; set; }
        
    }
}
