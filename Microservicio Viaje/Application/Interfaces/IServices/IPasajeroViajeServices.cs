using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IPasajeroViajeServices
    {
        //PasajeroViajeResponse CreatePasajeroViaje(PasajeroViajeRequest pasajeroViajeRequest);
        IEnumerable<PasajeroViaje> GetAllPasajeroViajes();
        PasajeroViajeResponse GetPasajeroViajeById(int pasajeroViajeId);
        //void AddPasajeroViaje(PasajeroViaje pasajeroViaje);
        //void UpdatePasajeroViaje(PasajeroViaje pasajeroViaje);
        //void DeletePasajeroViaje(int viajeId);
    }
}
