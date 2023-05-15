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
                .ToList();
        }

        public Pasajero GetById(int pasajeroId)
        {
            return _context.Pasajero
                .FirstOrDefault(p => p.PasajeroId == pasajeroId);
        }

        public IEnumerable<Pasajero> GetPasajeros(string nombre, string apellido)
        {

            IEnumerable<Pasajero> pasajeros = _context.Pasajero.Include(p => p.Viaje);
            if (!string.IsNullOrEmpty(nombre))
            {
                pasajeros = pasajeros.Where(p => p.Nombre.ToLower().Contains(nombre));
            }

            if (!string.IsNullOrEmpty(apellido))
            {
                pasajeros = pasajeros.Where(p => p.Apellido.ToLower().Contains(apellido));
            }

            pasajeros.ToList();
            return pasajeros;
        }
    }
}
