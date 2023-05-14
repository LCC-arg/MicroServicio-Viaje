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
    public class PasajeroMappings : IEntityTypeConfiguration<Pasajero>
    {
        public void Configure(EntityTypeBuilder<Pasajero> builder)
        {
            builder.ToTable("Pasajero");
            builder.HasKey(p => p.PasajeroId);

            builder.Property(p => p.PasajeroId).ValueGeneratedOnAdd();
            builder.Property(p => p.Nombre).IsRequired();
            builder.Property(p => p.Apellido).IsRequired();
            builder.Property(p => p.Dni).IsRequired();
            builder.Property(p => p.FechaNacimiento).IsRequired();
            builder.Property(p => p.Genero).IsRequired();
            builder.Property(p => p.NumContactoEmergencia).IsRequired();
            builder.Property(p => p.Nacionalidad).IsRequired();

            

        }
    }
}
