using Application.Response.Pais;

namespace Application.Response.Provincia
{
    public class ProvinciaResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public PaisResponse Pais { get; set; }

    }
}
