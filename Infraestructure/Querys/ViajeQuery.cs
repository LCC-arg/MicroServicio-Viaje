using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Querys
{
    public class ViajeQuery : IViajeQuery
    {
        private readonly ViajeContext _context;

        public ViajeQuery(ViajeContext context)
        {
            _context = context;
        }

        public Viaje GetViajeById(int viajeId)
        {
            var viaje = _context.Viajes.FirstOrDefault(x => x.ViajeId == viajeId);

            return viaje;
        }

        public List<Viaje> GetViajeList()
        {
            var viajeList = _context.Viajes.ToList();

            return viajeList;
        }

        public List<Viaje> GetViajeListFilters(string tipo, string fechaSalida, string fechaLlegada, int empresaId)
        {
            var viajeList = _context.Viajes.ToList();

            if (fechaSalida != null)
            {
                DateTime dateTime = DateTime.Parse(fechaSalida);
                viajeList = viajeList.Where(p => p.FechaSalida == dateTime).ToList();
            }

            if (fechaLlegada != null)
            {
                DateTime dateTime = DateTime.Parse(fechaLlegada);
                viajeList = viajeList.Where(p => p.FechaLlegada == dateTime).ToList();
            }

            if (tipo != null)
            {
                viajeList = viajeList.Where(p => p.TipoViaje.ToLower().Contains(tipo.ToLower())).ToList();
            }

            if (empresaId != 0)
            {
                viajeList = viajeList.Where(p => p.TransporteId == empresaId).ToList();
            }

            return viajeList;
        }
    }
}
