using Application.Request;
using Application.Response;

namespace Application.Interfaces
{
    public interface IViajeService
    {
        ViajeCompletoResponse GetViajeById(int viajeId);
        List<ViajeCompletoResponse> GetViajeListFilters(string tipo, string fechaSalida, string fechaLlegada, string empresa, string compania, int ciudadOrigen, int ciudadDestino, int pasajesDisponibles, string orden);
        ViajeResponse CreateViaje(ViajeRequest viaje);
        ViajeCompletoResponse RemoveViaje(int viajeId);
        ViajeCompletoResponse UpdateViaje(int viajeId, int asientosDisponibles);
    }
}
