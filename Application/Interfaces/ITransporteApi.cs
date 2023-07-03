namespace Application.Interfaces
{
    public interface ITransporteApi
    {
        dynamic ObtenerCaracteristicaTransporteList();
        dynamic ObtenerTransporteList();
        dynamic ObtenerTransporte(int viajeId);
    }
}
