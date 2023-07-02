using Application.Request;
using Application.Response;

namespace Application.Interfaces
{
    public interface IViajeService
    {
        ViajeResponse GetViajeById(int viajeId);
        List<ViajeResponse> GetViajeListFilters(string tipo, string fechaSalida, string fechaLlegada, string empresa, string compania, int ciudadOrigen, int ciudadDestino, int pasajesDisponibles, string orden);
        ViajeResponse CreateViaje(ViajeRequest viaje);
        ViajeResponse RemoveViaje(int viajeId);
        ViajeResponse UpdateViaje(int viajeId, int asientosDisponibles);
    }
}
