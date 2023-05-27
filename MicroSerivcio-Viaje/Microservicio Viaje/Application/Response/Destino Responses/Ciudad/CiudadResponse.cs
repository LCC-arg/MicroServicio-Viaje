using Application.Response.Provincia;

namespace Application.Response.Ciudad
{
    public class CiudadResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ProvinciaResponse Provincia { get; set; }
    }
}

