using Domain.Entities;

namespace Application.Interfaces
{
    public interface IViajeCommand
    {
        Viaje InsertViaje(Viaje viaje);
        Viaje RemoveViaje(int viajeId);
        Viaje UpdateViaje(Viaje viaje);
    }
}
