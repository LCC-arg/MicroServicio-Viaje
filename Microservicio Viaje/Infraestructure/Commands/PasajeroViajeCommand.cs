using Application.Interfaces.ICommands;
using Domain.Entities;
using Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Commands
{
    public class PasajeroViajeCommand : IPasajeroViajeCommand
    {
        private readonly AppDbContext _context;

        public PasajeroViajeCommand(AppDbContext context)
        {
            _context = context;
        }

        public void Delete(int pasajeroViajeId)
        {
            throw new NotImplementedException();
        }

        public void Update(PasajeroViaje pasajeroViaje)
        {
            throw new NotImplementedException();
        }
    }
}
