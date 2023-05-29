using Application.Response.ViajeCiudad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class ViajeResponse
    {
        public int id { get; set; }
        public TransporteResponse transporte { get;set; }
        public string duracion { get; set; }
        public DateTime horarioSalida { get; set; }
        public DateTime horarioLlegada { get; set; }
        public DateTime fechaSalida { get; set; }
        public DateTime fechaLlegada { get; set; }
        public string tipoViaje { get; set; }

    }
}

