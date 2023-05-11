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
    public class PasajeroViajeQuery : IPasajeroViajeQuery
    {
        private readonly AppDbContext _context;
        public PasajeroViajeQuery(AppDbContext context)
        {
            _context = context;
        }

        public PasajeroViaje GetById(int pasajeroViajeId)
        {
            return _context.PasajeroViaje
                .Include(pv => pv.Viaje)
                .Include(pv => pv.Pasajero)
                .FirstOrDefault(pv => pv.PasajeroViajeId == pasajeroViajeId);
            
        }
        public IEnumerable<PasajeroViaje> GetAll()
        {
            return _context.PasajeroViaje.ToList();
        }

    }
}
