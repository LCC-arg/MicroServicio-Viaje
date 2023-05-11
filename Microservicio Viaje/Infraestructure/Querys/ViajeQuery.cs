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
           .Include(v => v.PasajeroViajes)
           .ToList();
        }

        public Viaje GetById(int viajeId)
        {
            return _context.Viaje
                .Include(v => v.PasajeroViajes)
                .FirstOrDefault(v => v.ViajeId == viajeId);
        }
    }
}
