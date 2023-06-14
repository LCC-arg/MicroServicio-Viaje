namespace Application.Request
{
    public class PasajeroRequest
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public int NumContactoEmergencia { get; set; }
        public int ViajeId { get; set; }
        public string Nacionalidad { get; set; }
    }
}
