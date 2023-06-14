namespace Application.Response
{
    public class PasajeroResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public int NumContactoEmergencia { get; set; }
        public ViajeResponse Viaje { get; set; }

    }
}
