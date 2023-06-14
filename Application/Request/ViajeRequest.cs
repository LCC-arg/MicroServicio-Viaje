namespace Application.Request
{
    public class ViajeRequest
    {
        public int TransporteId { get; set; }
        public string Duracion { get; set; }
        public string FechaLlegada { get; set; }
        public string FechaSalida { get; set; }
        public string TipoViaje { get; set; }
        public List<int> Escalas { get; set; }
        public List<int> Servicios { get; set; }
        public int CiudadOrigen { get; set; }
        public int CiudadDestino { get; set; }
    }
}
