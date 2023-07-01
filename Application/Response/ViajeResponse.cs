namespace Application.Response
{
    public class ViajeResponse
    {
        public int Id { get; set; }
        public int TransporteId { get; set; }
        public string Duracion { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
        public string TipoViaje { get; set; }
        public int AsientosDisponibles { get; set; }
        public int Precio { get; set; }
        public int CiudadOrigen { get; set; }
        public int CiudadDestino { get; set; }
        public List<int> Escalas { get; set; }
        public List<int> Servicios { get; set; }

    }
}
