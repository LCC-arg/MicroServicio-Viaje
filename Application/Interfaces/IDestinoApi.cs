namespace Application.Interfaces
{
    public interface IDestinoApi
    {
        dynamic CreateViajeCiudad(int viajeId, int ciudadId, string tipo);
    }
}
