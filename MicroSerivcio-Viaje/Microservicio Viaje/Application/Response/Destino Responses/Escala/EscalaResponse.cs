using Application.Response.Ciudad;

namespace Application.Response.Escala
{
    public class EscalaResponse
    {
        public int Id { get; set; }
        public string NombreParada { get; set; }
        public DateTime HoraLlegada { get; set; }
        public DateTime HoraSalida { get; set; }
        public int ViajeId { get; set; }
        public CiudadResponse Ciudad { get; set; }
    }
}
