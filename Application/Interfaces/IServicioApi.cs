namespace Application.Interfaces.IApi
{
    public interface IServicioApi
    {
        dynamic CreateViajeServicio(int viajeId, int servicioId);
    }
}
