using Application.Interfaces.IQuerys;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Querys
{
    public class ViajeQuery : IViajeQuery
    {
        private readonly AppDbContext _context;
        public ViajeQuery(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Viaje> GetAll()
        {
            return _context.Viaje
           .ToList();
        }

        public Viaje GetById(int viajeId)
        {
            return _context.Viaje
                .Include(v => v.Pasajeros)
                .FirstOrDefault(v => v.ViajeId == viajeId);
        }

        public List<Pasajero> GetAllPasajerosById(int viajeId)
        {
            Viaje viaje = _context.Viaje
                .Include(v => v.Pasajeros)
                .FirstOrDefault(v => v.ViajeId == viajeId);

            List<Pasajero> pasajeros = viaje.Pasajeros;

            return pasajeros;
        }

        public IEnumerable<Viaje> GetViajes(string? tipo, DateTime? fechaSalida, DateTime? fechaLlegada)
        {
            IEnumerable<Viaje> viajes = _context.Viaje;
            if (!string.IsNullOrEmpty(tipo)) 
            {
                viajes = viajes.Where(v => v.TipoViaje.ToLower().Contains(tipo)).ToList();
            }

            if (fechaSalida != null)
            {
                viajes = viajes.Where(v => v.FechaSalida.Date >= fechaSalida.Value.Date).ToList();
            }

            if (fechaLlegada != null)
            {
                viajes = viajes.Where(v => v.FechaLlegada.Date <= fechaLlegada.Value.Date).ToList();
            }

            return viajes;
        }
    }
}
