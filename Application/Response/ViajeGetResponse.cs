using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class ViajeGetResponse
    {
        public int Id { get; set; }
        public int TransporteId { get; set; }
        public string Duracion { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
        public string TipoViaje { get; set; }
    }
}
