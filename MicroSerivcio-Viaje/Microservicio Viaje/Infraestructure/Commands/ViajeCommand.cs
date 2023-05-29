﻿using Application.Interfaces.ICommands;
using Application.Request;
using Domain.Entities;
using Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Commands
{
    public class ViajeCommand : IViajeCommand
    {
        private readonly AppDbContext _context;

        public ViajeCommand(AppDbContext context)
        {
            _context = context;
        }

   
        public Viaje Delete(int viajeId)
        {
            Viaje viaje = _context.Viaje
                .FirstOrDefault(v => v.ViajeId == viajeId);
            if (viaje == null)
            {
                return null;
            }
            _context.Viaje.Remove(viaje);
            _context.SaveChanges();
            return viaje;
        }

        public Viaje Insert(Viaje viaje)
        {
            _context.Viaje.Add(viaje);

            _context.SaveChanges();

            return viaje;
        }

        public Viaje Update(int viajeId, ViajeRequest viajeRequest)
        {
            var updateViaje = _context.Viaje
                .FirstOrDefault(v => v.ViajeId == viajeId);


            updateViaje.TransporteId = viajeRequest.transporteId;
            updateViaje.Duracion = viajeRequest.duracion;
            updateViaje.HorarioSalida = DateTime.Parse(viajeRequest.horarioSalida);
            updateViaje.HorarioLlegada = DateTime.Parse(viajeRequest.horarioLlegada);
            updateViaje.FechaLlegada = DateTime.Parse(viajeRequest.fechaLlegada);
            updateViaje.FechaSalida = DateTime.Parse(viajeRequest.fechaSalida);
            updateViaje.TipoViaje = viajeRequest.tipoViaje;

            _context.Update(updateViaje);
            _context.SaveChanges();

            return updateViaje;
        }
    }
}
