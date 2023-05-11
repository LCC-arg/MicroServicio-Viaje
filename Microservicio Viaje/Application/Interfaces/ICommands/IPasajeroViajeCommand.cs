using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ICommands
{
    public interface IPasajeroViajeCommand
    {
        void Update(PasajeroViaje pasajeroViaje);
        void Delete(int pasajeroViajeId);
    }
}
