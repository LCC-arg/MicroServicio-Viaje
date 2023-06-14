using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Command
{
    public class ViajeCommand : IViajeCommand
    {
        private readonly ViajeContext _context;

        public ViajeCommand(ViajeContext context)
        {
            _context = context;
        }

        public Viaje InsertViaje(Viaje viaje)
        {
            _context.Add(viaje);
            _context.SaveChanges();

            return viaje;
        }

        public Viaje RemoveViaje(int viajeId)
        {
            var viaje = _context.Viajes
            .FirstOrDefault(x => x.ViajeId == viajeId);

            _context.Remove(viaje);
            _context.SaveChanges();

            return viaje;
        }

        public Viaje UpdateViaje(Viaje viaje)
        {
            _context.Update(viaje);
            _context.SaveChanges();

            return viaje;
        }
    }
}
