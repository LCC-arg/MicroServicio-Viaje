using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                    FechaLlegada = DateTime.Parse("2023-10-05T22:33:39.514Z"),
                    FechaSalida = DateTime.Parse("2023-10-05T23:33:39.514Z"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 50,
                    Precio = 15000
                },

                new Viaje
                {
                    ViajeId = 2,
                    TransporteId = 2,
                    Duracion = "2 Hora",
                    FechaLlegada = DateTime.Parse("2023-11-05T20:00:00.000Z"),
                    FechaSalida = DateTime.Parse("2023-11-05T22:00:00.000Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 60,
                    Precio = 12000
                },

                new Viaje
                {
                    ViajeId = 3,
                    TransporteId = 3,
                    Duracion = "5 Hora",
                    FechaLlegada = DateTime.Parse("2023-12-05T15:00:00.000Z"),
                    FechaSalida = DateTime.Parse("2023-12-05T20:00:00.000Z"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 360,
                    Precio = 8000
                },

                new Viaje
                {
                    ViajeId = 4,
                    TransporteId = 19,
                    Duracion = "12 Horas",
                    FechaLlegada = DateTime.Parse("2023-07-04T22:33:39.514Z"),
                    FechaSalida = DateTime.Parse("2023-07-05T10:33:39.514Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 30,
                    Precio = 11000
                },

                new Viaje
                {
                    ViajeId = 5,
                    TransporteId = 20,
                    Duracion = "12 Horas",
                    FechaLlegada = DateTime.Parse("2023-08-04T22:33:39.514Z"),
                    FechaSalida = DateTime.Parse("2023-08-05T10:33:39.514Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 50,
                    Precio = 8500
                },

                new Viaje
                {
                    ViajeId = 6,
                    TransporteId = 21,
                    Duracion = "5 Horas",
                    FechaLlegada = DateTime.Parse("2023-05-04T15:33:39.514Z"),
                    FechaSalida = DateTime.Parse("2023-05-05T10:33:39.514Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 50,
                    Precio = 8000
                },

                new Viaje
                {
                    ViajeId = 7,
                    TransporteId = 22,
                    Duracion = "10 Horas",
                    FechaLlegada = DateTime.Parse("2023-08-04T20:33:39.514Z"),
                    FechaSalida = DateTime.Parse("2023-08-05T10:33:39.514Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 40,
                    Precio = 8000
                },

                new Viaje
                {
                    ViajeId = 8,
                    TransporteId = 23,
                    Duracion = "4 Horas",
                    FechaLlegada = DateTime.Parse("2023-06-05T20:00:00.000Z"),
                    FechaSalida = DateTime.Parse("2023-06-05T16:00:00.000Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 35,
                    Precio = 8000
                },

                new Viaje
                {
                    ViajeId = 9,
                    TransporteId = 24,
                    Duracion = "4 Horas",
                    FechaLlegada = DateTime.Parse("2023-05-05T15:30:00.000Z"),
                    FechaSalida = DateTime.Parse("2023-05-05T11:30:00.000Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 30,
                    Precio = 8000
                },

                new Viaje
                {
                    ViajeId = 10,
                    TransporteId = 25,
                    Duracion = "3 Horas",
                    FechaLlegada = DateTime.Parse("2023-07-06T09:15:00.000Z"),
                    FechaSalida = DateTime.Parse("2023-07-06T06:15:00.000Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 60,
                    Precio = 8000
                },

                new Viaje
                {
                    ViajeId = 11,
                    TransporteId = 26,
                    Duracion = "4 Horas",
                    FechaLlegada = DateTime.Parse("2023-04-06T15:00:00.000Z"),
                    FechaSalida = DateTime.Parse("2023-04-06T11:00:00.000Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 50,
                    Precio = 8000
                },

                new Viaje
                {
                    ViajeId = 12,
                    TransporteId = 27,
                    Duracion = "5 Horas",
                    FechaLlegada = DateTime.Parse("2023-07-06T20:00:00.000Z"),
                    FechaSalida = DateTime.Parse("2023-07-06T15:00:00.000Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 30,
                    Precio = 8000
                },

                new Viaje
                {
                    ViajeId = 13,
                    TransporteId = 28,
                    Duracion = "4 Horas",
                    FechaLlegada = DateTime.Parse("2023-07-07T10:00:00.000Z"),
                    FechaSalida = DateTime.Parse("2023-07-07T06:00:00.000Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 30,
                    Precio = 8000
                },

                new Viaje
                {
                    ViajeId = 14,
                    TransporteId = 29,
                    Duracion = "5 Horas",
                    FechaLlegada = DateTime.Parse("2023-07-07T17:00:00.000Z"),
                    FechaSalida = DateTime.Parse("2023-07-07T12:00:00.000Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 45,
                    Precio = 8000
                },

                new Viaje
                {
                    ViajeId = 15,
                    TransporteId = 30,
                    Duracion = "5 Horas",
                    FechaLlegada = DateTime.Parse("2023-07-07T21:00:00.000Z"),
                    FechaSalida = DateTime.Parse("2023-07-07T16:00:00.000Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 20,
                    Precio = 8000
                },

                new Viaje
                {
                    ViajeId = 16,
                    TransporteId = 31,
                    Duracion = "2 Horas",
                    FechaLlegada = DateTime.Parse("2023-07-08T08:30:00.000Z"),
                    FechaSalida = DateTime.Parse("2023-07-08T06:30:00.000Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 15,
                    Precio = 8000
                },

                new Viaje
                {
                    ViajeId = 17,
                    TransporteId = 26,
                    Duracion = "8 Horas",
                    FechaLlegada = DateTime.Parse("2023-07-08T15:00:00.000Z"),
                    FechaSalida = DateTime.Parse("2023-07-08T07:00:00.000Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 10,
                    Precio = 8000
                },

                new Viaje
                {
                    ViajeId = 18,
                    TransporteId = 33,
                    Duracion = "3 Horas",
                    FechaLlegada = DateTime.Parse("2023-07-08T17:30:00.000Z"),
                    FechaSalida = DateTime.Parse("2023-07-08T14:30:00.000Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 5,
                    Precio = 8000
                });
        }
    }
}
