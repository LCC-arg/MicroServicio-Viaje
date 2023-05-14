using Application.Request;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ICommands
{
    public interface IViajeCommand
    {
        Viaje Create(ViajeRequest viajeRequest);
        void Insert(Viaje viaje);
        Viaje Update(int viajeId, ViajeRequest viajeRequest);
        Viaje Delete(int viajeId);
    }
}
