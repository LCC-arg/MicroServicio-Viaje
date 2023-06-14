using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPasajeroQuery
    {
        Pasajero GetPasajeroById(int pasajeroId);
        List<Pasajero> GetPasajeroList();
    }
}
