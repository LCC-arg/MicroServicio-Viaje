using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPasajeroCommand
    {
        Pasajero InsertPasajero(Pasajero pasajero);
        Pasajero RemovePasajero(int pasajeroId);
        Pasajero UpdatePasajeroe(Pasajero pasajero);
    }
}
