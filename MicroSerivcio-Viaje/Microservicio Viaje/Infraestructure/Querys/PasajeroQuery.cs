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
    public class PasajeroQuery : IPasajeroQuery
    {
        private readonly AppDbContext _context;
        public PasajeroQuery(AppDbContext context) 
        {
            _context = context;
        }
        public IEnumerable<Pasajero> GetAll()
        {
            return _context.Pasajero
                .Include(p => p.PasajeroViajes)
                .ToList();
        }

        public Pasajero GetById(int pasajeroId)
        {
            return _context.Pasajero
                .Include(p => p.PasajeroViajes)
                .FirstOrDefault(p => p.PasajeroId == pasajeroId);
        }
    }
}
