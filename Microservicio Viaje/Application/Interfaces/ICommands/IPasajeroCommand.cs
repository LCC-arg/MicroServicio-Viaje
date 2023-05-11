using Application.Request;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ICommands
{
    public interface IPasajeroCommand
    {
        Pasajero Create(PasajeroRequest pasajeroRequest);
        void Insert(Pasajero pasajero);
        Pasajero Update(int pasajeroId, PasajeroRequest pasajeroRequest);
        Pasajero Delete(int pasajeroId);
    }
}
