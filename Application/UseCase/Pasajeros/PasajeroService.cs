using Application.Interfaces;
using Application.Request;
using Application.Response;

namespace Application.UseCase.Pasajeros
{
    public class PasajeroService : IPasajeroService
    {
        private readonly IPasajeroCommand _command;
        private readonly IPasajeroQuery _query;

        public PasajeroService(IPasajeroCommand command, IPasajeroQuery query)
        {
            _command = command;
            _query = query;
        }

        public PasajeroResponse GetPasajeroById(int pasajeroId)
        {
            throw new NotImplementedException();
        }

        public List<PasajeroResponse> GetPasajeroList()
        {
            throw new NotImplementedException();
        }

        public PasajeroResponse CreatePasajero(PasajeroRequest pasajero)
        {
            throw new NotImplementedException();
        }

        public PasajeroResponse RemovePasajero(int pasajeroId)
        {
            throw new NotImplementedException();
        }

        public PasajeroResponse UpdatePasajero(int pasajeroId, PasajeroRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
