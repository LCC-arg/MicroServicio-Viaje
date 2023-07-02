using Domain.Entities;

namespace Application.Interfaces
{
    public interface IViajeQuery
    {
        Viaje GetViajeById(int viajeId);
        Viaje GetViajeList(int transporteId);
        List<Viaje> GetViajeListFilters(string tipo, string fechaSalida, string fechaLlegada, string empresa, string compania, int ciudadOrigen, int ciudadDestino, int pasajesDisponibles, string orden);
    }
}
