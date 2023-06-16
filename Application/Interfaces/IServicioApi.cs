namespace Application.Interfaces.IApi
{
    public interface IServicioApi
    {
        dynamic CreateViajeServicio(int viajeId, int servicioId);
        dynamic ObtenerServicioList(int viajeId);
    }
}
