using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Mappings
{
    public class PasajeroMappings : IEntityTypeConfiguration<Pasajero>
    {
        public void Configure(EntityTypeBuilder<Pasajero> builder)
        {
            builder.ToTable("Pasajero");
            builder.HasKey(p => p.PasajeroId);

            builder
                .HasOne(p => p.Viaje)
                .WithMany(v => v.Pasajeros)
                .IsRequired();

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
