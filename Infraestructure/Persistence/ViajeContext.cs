using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence
{
    public class ViajeContext : DbContext
    {
        public DbSet<Pasajero> Pasajeros { get; set; }
        public DbSet<Viaje> Viajes { get; set; }

        public ViajeContext(DbContextOptions<ViajeContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ViajeContext).Assembly);
        }
    }
}
