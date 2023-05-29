using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Mappings
{
    public class ViajeMappings : IEntityTypeConfiguration<Viaje>
    {
        public void Configure(EntityTypeBuilder<Viaje> builder)
        {
            builder.ToTable("Viaje");
            builder.HasKey(v => v.ViajeId);

            builder
               .HasMany(v => v.Pasajeros)
               .WithOne(p => p.Viaje)
               .IsRequired();

            builder.Property(v => v.ViajeId).ValueGeneratedOnAdd();
            builder.Property(v => v.TransporteId).IsRequired();
            builder.Property(v => v.Duracion).IsRequired();
            builder.Property(v => v.HorarioSalida).IsRequired();
            builder.Property(v => v.HorarioLlegada).IsRequired();
            builder.Property(v => v.FechaLlegada).IsRequired();
            builder.Property(v => v.FechaSalida).IsRequired();
            builder.Property(v => v.TipoViaje).IsRequired();
        }
    }
}
