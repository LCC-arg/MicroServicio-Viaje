using Domain.Entities;

namespace Application.Interfaces
{
    public interface IViajeQuery
    {
        Viaje GetViajeById(int viajeId);
        List<Viaje> GetViajeList();
        List<Viaje> GetViajeListFilters(string tipo, string fechaSalida, string fechaLlegada, int empresaId, int ciudadOrigen, int ciudadDestino, int pasajesDisponibles);
    }
}
