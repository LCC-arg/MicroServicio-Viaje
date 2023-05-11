using Application.Request;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IPasajeroServices
    {
        PasajeroResponse CreatePasajero(PasajeroRequest pasajeroRequest);
        IEnumerable<PasajeroResponse> GetAllPasajeros();
        PasajeroResponse GetPasajeroById(int pasajeroId);
        PasajeroResponse AddPasajero(Pasajero pasajero);
        PasajeroResponse UpdatePasajero(int pasajeroId, PasajeroRequest pasajeroRequest);
        PasajeroResponse DeletePasajero(int pasajeroId);
    }
}
