namespace Domain.Entities
{
    public class Viaje
    {
        public int ViajeId { get; set; }
        public int TransporteId { get; set; }
        public string Duracion { get; set; }
        public DateTime FechaLlegada { get; set; }
        public DateTime FechaSalida { get; set; }
        public string TipoViaje { get; set; }
        public int AsientosDisponibles { get; set; }
        public List<Pasajero> Pasajeros { get; set; }
    }
}
