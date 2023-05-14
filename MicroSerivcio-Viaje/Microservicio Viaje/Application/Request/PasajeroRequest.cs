using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
    public class PasajeroRequest
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int dni { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string genero { get; set; }
        public int numContactoEmergencia { get; set; }
        public int viajeId { get; set; }
        public string nacionalidad { get; set; }
    }
}
