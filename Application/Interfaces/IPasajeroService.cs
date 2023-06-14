using Application.Request;
using Application.Response;

namespace Application.Interfaces
{
    public interface IPasajeroService
    {
        PasajeroResponse GetPasajeroById(int pasajeroId);
        List<PasajeroResponse> GetPasajeroList();
        PasajeroResponse CreatePasajero(PasajeroRequest pasajero);
        PasajeroResponse RemovePasajero(int pasajeroId);
        PasajeroResponse UpdatePasajero(int pasajeroId, PasajeroRequest request);
    }
}
