namespace Application.Interfaces
{
    public interface IDestinoApi
    {
        dynamic ObtenerViajeList();
        dynamic ObtenerViajeList(int viajeId);
        dynamic CreateViajeCiudad(int viajeId, int ciudadId, string tipo);
        dynamic ObtenerCiudadDestino(int idCiudad);
        dynamic ObtenerInfoCiudadDestino(int idCiudad);
    }
}
