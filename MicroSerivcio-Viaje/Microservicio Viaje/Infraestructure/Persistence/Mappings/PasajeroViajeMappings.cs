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
    public class PasajeroViajeMappings : IEntityTypeConfiguration<PasajeroViaje>
    {
        public void Configure(EntityTypeBuilder<PasajeroViaje> builder)
        {
            builder.ToTable("PasajeroViaje");
            builder.HasKey(pv => pv.PasajeroViajeId);

            builder
                .HasOne(pv => pv.Pasajero)
                .WithMany(p => p.PasajeroViajes)
                .HasForeignKey(pv => pv.PasajeroId)
        .       OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pv => pv.Viaje)
                .WithMany(v => v.PasajeroViajes)
                .HasForeignKey(pv => pv.ViajeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(pv => pv.PasajeroViajeId).ValueGeneratedOnAdd();
            builder.Property(pv => pv.PasajeroId).IsRequired();
            builder.Property(pv => pv.ViajeId).IsRequired();
        }
    }
}
