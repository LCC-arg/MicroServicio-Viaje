using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
    public class ViajeRequest
    {
        public int ciudadOrigen { get; set; }
        public int ciudadDestino { get; set; }
        public int transporteId { get; set; }
        public int servicioId { get; set; }
        public string duracion { get; set; }
        public DateTime horarioSalida { get; set; }
        public DateTime horarioLlegada { get; set; }
        public DateTime fechaLlegada { get; set; }
        public DateTime fechaSalida { get; set; }
        public string tipoViaje { get; set; }
    }
}
