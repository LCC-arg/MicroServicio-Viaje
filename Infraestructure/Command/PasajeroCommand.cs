using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Command
{
    public class PasajeroCommand : IPasajeroCommand
    {
        private readonly ViajeContext _context;

        public PasajeroCommand(ViajeContext context)
        {
            _context = context;
        }

        public Pasajero InsertPasajero(Pasajero pasajero)
        {
            _context.Add(pasajero);
            _context.SaveChanges();

            return pasajero;
        }

        public Pasajero RemovePasajero(int pasajeroId)
        {
            var pasajero = _context.Pasajeros
            .Include(s => s.Viaje)
            .FirstOrDefault(x => x.PasajeroId == pasajeroId);

            _context.Remove(pasajero);
            _context.SaveChanges();

            return pasajero;
        }

        public Pasajero UpdatePasajeroe(Pasajero pasajero)
        {
            _context.Update(pasajero);
            _context.SaveChanges();

            return pasajero;
        }
    }
}
