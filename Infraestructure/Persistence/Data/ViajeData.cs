using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infraestructure.Persistence.Data
{
    public class ViajeData : IEntityTypeConfiguration<Viaje>
    {
        public void Configure(EntityTypeBuilder<Viaje> entityBuilder)
        {
            entityBuilder.HasData
            (
                new Viaje
                {
                    ViajeId = 1,
                    TransporteId = 1,
                    Duracion = "1 Hora",
                    FechaLlegada = DateTime.Parse("10/05/2023"),
                    FechaSalida = DateTime.Parse("10/05/2023"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 50,
                },

                new Viaje
                {
                    ViajeId = 2,
                    TransporteId = 2,
                    Duracion = "2 Hora",
                    FechaLlegada = DateTime.Parse("11/05/2023"),
                    FechaSalida = DateTime.Parse("11/05/2023"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 60,
                },

                new Viaje
                {
                    ViajeId = 3,
                    TransporteId = 3,
                    Duracion = "5 Hora",
                    FechaLlegada = DateTime.Parse("23/05/2023"),
                    FechaSalida = DateTime.Parse("23/05/2023"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 360,
                });
        }
    } 
}
