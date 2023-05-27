using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class TransporteResponse
    {
        public int id { get; set; }
        public CompaniaTransporteResponse companiaTransporte { get; set; }
        public TipoTransporteResponse tipoTransporte { get; set; }
    }
}
