using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class GetAllPasajerosByIdResponse
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int dni { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string genero { get; set; }
        public int numContactoEmergencia { get; set; }

    }
}