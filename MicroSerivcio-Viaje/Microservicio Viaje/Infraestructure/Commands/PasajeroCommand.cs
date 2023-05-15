using Application.Interfaces.ICommands;
using Application.Request;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Commands
{
    public class PasajeroCommand : IPasajeroCommand
    {
        private readonly AppDbContext _context;

        public PasajeroCommand(AppDbContext context)
        {
            _context = context;
        }

        public Pasajero Create(PasajeroRequest pasajeroRequest)
        {
            Viaje viaje = _context.Viaje.Find(pasajeroRequest.viajeId);
            Pasajero newPasajero = new Pasajero
            {
                Nombre = pasajeroRequest.nombre,
                Apellido = pasajeroRequest.apellido,
                Dni = pasajeroRequest.dni,
                FechaNacimiento = pasajeroRequest.fechaNacimiento,
                Genero = pasajeroRequest.genero,
                NumContactoEmergencia = pasajeroRequest.numContactoEmergencia,
                ViajeId = pasajeroRequest.viajeId,
                Nacionalidad = pasajeroRequest.nacionalidad,
                Viaje = viaje
            };

            _context.Pasajero.Add(newPasajero);
            viaje.Pasajeros.Add(newPasajero);

            _context.SaveChanges();
            return newPasajero;

        }


        public Pasajero Delete(int pasajeroId)
        {
            Pasajero pasajero = _context.Pasajero
                .Include(p => p.Viaje)
                .FirstOrDefault(p => p.PasajeroId == pasajeroId);
            if (pasajero == null)
            {
                return null;
            }
            _context.Pasajero.Remove(pasajero);
            _context.SaveChanges();
            return pasajero;
        }

        public void Insert(Pasajero pasajero)
        {
            throw new NotImplementedException();
        }

        public Pasajero Update(int pasajeroId, PasajeroRequest pasajeroRequest)
        {
            var updatePasajero = _context.Pasajero
                .FirstOrDefault(p => p.PasajeroId == pasajeroId);

            updatePasajero.Nombre = pasajeroRequest.nombre;
            updatePasajero.Apellido = pasajeroRequest.apellido;
            updatePasajero.Dni = pasajeroRequest.dni;
            updatePasajero.FechaNacimiento = pasajeroRequest.fechaNacimiento;
            updatePasajero.Genero = pasajeroRequest.genero;
            updatePasajero.NumContactoEmergencia = pasajeroRequest.numContactoEmergencia;
            updatePasajero.ViajeId = pasajeroRequest.viajeId;
            updatePasajero.Nacionalidad = pasajeroRequest.nacionalidad;

            _context.Update(updatePasajero);
            _context.SaveChanges();

            return updatePasajero;
        }

    }
}
