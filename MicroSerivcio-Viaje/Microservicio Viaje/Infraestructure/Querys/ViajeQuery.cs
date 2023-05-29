using Application.Exceptions;
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

        public IEnumerable<Viaje> GetViajes(string? tipo, string? fechaSalida, string? fechaLlegada)
        {
            if (!DateTime.TryParse(fechaSalida, out _) && fechaSalida != null)
            {
                throw new BadRequestException("Fecha de Salida invalida");
            }
            if (!DateTime.TryParse(fechaLlegada, out _) && fechaLlegada != null)
            {
                throw new BadRequestException("Fecha de Llegada invalida");
            }

            IEnumerable<Viaje> viajes = _context.Viaje;
            if (!string.IsNullOrEmpty(tipo)) 
            {
                viajes = viajes.Where(v => v.TipoViaje.ToLower().Contains(tipo)).ToList();
            }

            if (fechaSalida != null)
            {
                viajes = viajes.Where(v => v.FechaSalida.Date >= DateTime.Parse(fechaSalida)).ToList();
            }

            if (fechaLlegada != null)
            {
                viajes = viajes.Where(v => v.FechaLlegada.Date <= DateTime.Parse(fechaLlegada)).ToList();
            }

            return viajes;
        }
    }
}
