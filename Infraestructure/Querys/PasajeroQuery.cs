using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Querys
{
    public class PasajeroQuery : IPasajeroQuery
    {
        private readonly ViajeContext _context;

        public PasajeroQuery(ViajeContext context)
        {
            _context = context;
        }

        public Pasajero GetPasajeroById(int pasajeroId)
        {
            var pasajero = _context.Pasajeros
                .Include(s => s.Viaje)
                .FirstOrDefault(x => x.PasajeroId == pasajeroId);

            return pasajero;
        }

        public List<Pasajero> GetPasajeroList()
        {
            var pasajeroList = _context.Pasajeros
                .Include(s => s.Viaje)
                .ToList();

            return pasajeroList;
        }
    }
}
