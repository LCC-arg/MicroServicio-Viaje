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
                    TransporteId = 34,
                    Duracion = "8 Horas",
                    FechaLlegada = DateTime.Parse("2023-10-05T08:00:00.514Z"),
                    FechaSalida = DateTime.Parse("2023-10-12T08:00:00.514Z"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 45,
                    Precio = 15000
                },

                new Viaje
                {
                    ViajeId = 2,
                    TransporteId = 35,
                    Duracion = "8 Horas",
                    FechaLlegada = DateTime.Parse("2023-11-30T20:00:00.514Z"),
                    FechaSalida = DateTime.Parse("2023-11-15T22:00:00.514Z"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 200,
                    Precio = 12000
                },

                new Viaje
                {
                    ViajeId = 3,
                    TransporteId = 4,
                    Duracion = "18 Horas",
                    FechaLlegada = DateTime.Parse("2024-07-18T10:00:00.514Z"),
                    FechaSalida = DateTime.Parse("2024-07-01T20:00:00.514Z"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 300,
                    Precio = 650000
                },

                new Viaje
                {
                    ViajeId = 4,
                    TransporteId = 5,
                    Duracion = "30 horas",
                    FechaLlegada = DateTime.Parse("2024-06-07T22:30:00.514Z"),
                    FechaSalida = DateTime.Parse("2024-06-01T10:30:00.514Z"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 350,
                    Precio = 1250000
                },

                new Viaje
                {
                    ViajeId = 5,
                    TransporteId = 6,
                    Duracion = "2 horas",
                    FechaLlegada = DateTime.Parse("2023-12-10T08:00:00.514Z"),
                    FechaSalida = DateTime.Parse("2023-12-03T06:00:00.514Z"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 123,
                    Precio = 27000
                },

                new Viaje
                {
                    ViajeId = 6,
                    TransporteId = 7,
                    Duracion = "3 Horas 30 min",
                    FechaLlegada = DateTime.Parse("1111-11-11T11:11:11.514Z"),
                    FechaSalida = DateTime.Parse("2023-07-10T10:30:00.514Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 250,
                    Precio = 23000
                },

                new Viaje
                {
                    ViajeId = 7,
                    TransporteId = 8,
                    Duracion = "4 Horas",
                    FechaLlegada = DateTime.Parse("2023-08-08T10:00:00.514Z"),
                    FechaSalida = DateTime.Parse("2023-08-01T06:00:00.514Z"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 165,
                    Precio = 30000
                },

                new Viaje
                {
                    ViajeId = 8,
                    TransporteId = 12,
                    Duracion = "1 Hora(s)",
                    FechaLlegada = DateTime.Parse("1111-11-11T11:11:11.514Z"),
                    FechaSalida = DateTime.Parse("2023-07-15T16:00:00.514Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 80,
                    Precio = 30500
                },

                new Viaje
                {
                    ViajeId = 9,
                    TransporteId = 8,
                    Duracion = "1 Hora",
                    FechaLlegada = DateTime.Parse("1111-11-11T11:11:11.514Z"),
                    FechaSalida = DateTime.Parse("2023-07-05T11:30:00.514Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 225,
                    Precio = 35000
                },

                new Viaje
                {
                    ViajeId = 10,
                    TransporteId = 9,
                    Duracion = "1 Hora 30 min",
                    FechaLlegada = DateTime.Parse("2023-07-21T09:15:00.514Z"),
                    FechaSalida = DateTime.Parse("2023-07-15T06:15:00.514Z"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 350,
                    Precio = 41050
                },

                new Viaje
                {
                    ViajeId = 11,
                    TransporteId = 10,
                    Duracion = "3 Horas",
                    FechaLlegada = DateTime.Parse("2024-01-21T15:00:00.514Z"),
                    FechaSalida = DateTime.Parse("2024-01-03T18:00:00.514Z"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 300,
                    Precio = 70250
                },

                new Viaje
                {
                    ViajeId = 12,
                    TransporteId = 11,
                    Duracion = "17 Horas",
                    FechaLlegada = DateTime.Parse("2023-10-23T20:00:00.514Z"),
                    FechaSalida = DateTime.Parse("2023-10-16T15:00:00.514Z"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 111,
                    Precio = 350000
                },

                new Viaje
                {
                    ViajeId = 13,
                    TransporteId = 13,
                    Duracion = "14 Hora(s)",
                    FechaLlegada = DateTime.Parse("1111-11-11T11:11:11.514Z"),
                    FechaSalida = DateTime.Parse("2023-07-07T06:00:00.514Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 325,
                    Precio = 380000
                },

                new Viaje
                {
                    ViajeId = 14,
                    TransporteId = 14,
                    Duracion = "17 Hora(s)",
                    FechaLlegada = DateTime.Parse("2023-12-13T17:00:00.514Z"),
                    FechaSalida = DateTime.Parse("2023-11-28T12:00:00.514Z"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 172,
                    Precio = 638000
                },

                new Viaje
                {
                    ViajeId = 15,
                    TransporteId = 15,
                    Duracion = "3 Hora(s)",
                    FechaLlegada = DateTime.Parse("1111-11-11T11:11:11.514Z"),
                    FechaSalida = DateTime.Parse("2023-07-07T16:00:00.514Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 210,
                    Precio = 68000
                },

                new Viaje
                {
                    ViajeId = 16,
                    TransporteId = 16,
                    Duracion = "5 Hora(s)",
                    FechaLlegada = DateTime.Parse("2023-09-04T08:30:00.514Z"),
                    FechaSalida = DateTime.Parse("2023-09-01T06:30:00.514Z"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 190,
                    Precio = 80000
                },

                new Viaje
                {
                    ViajeId = 17,
                    TransporteId = 22,
                    Duracion = "19 Horas",
                    FechaLlegada = DateTime.Parse("2023-08-30T15:00:00.514Z"),
                    FechaSalida = DateTime.Parse("2023-08-25T07:00:00.514Z"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 85,
                    Precio = 35000
                },

                new Viaje
                {
                    ViajeId = 18,
                    TransporteId = 17,
                    Duracion = "2 Horas 30 min",
                    FechaLlegada = DateTime.Parse("1111-11-11T11:11:11.514Z"),
                    FechaSalida = DateTime.Parse("2023-11-08T14:30:00.514Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 250,
                    Precio = 54500
                },
                new Viaje
                {
                    ViajeId = 19,
                    TransporteId = 18,
                    Duracion = "20 Horas",
                    FechaLlegada = DateTime.Parse("2023-10-23T20:00:00.514Z"),
                    FechaSalida = DateTime.Parse("2023-10-16T15:00:00.514Z"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 100,
                    Precio = 618000
                },

                new Viaje
                {
                    ViajeId = 20,
                    TransporteId = 4,
                    Duracion = "12 Hora(s)",
                    FechaLlegada = DateTime.Parse("2023-01-25T03:00:00.514Z"),
                    FechaSalida = DateTime.Parse("2023-01-02T06:00:00.514Z"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 295,
                    Precio = 435000
                },

                new Viaje
                {
                    ViajeId = 21,
                    TransporteId = 5,
                    Duracion = "8 Hora(s)",
                    FechaLlegada = DateTime.Parse("1111-11-11T11:11:11.514Z"),
                    FechaSalida = DateTime.Parse("2023-11-28T12:00:00.514Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 133,
                    Precio = 130000
                },
                //----------------------------------------
                new Viaje
                {
                    ViajeId = 22,
                    TransporteId = 10,
                    Duracion = "1 Hora(s) 30min",
                    FechaLlegada = DateTime.Parse("2023-12-10T10:00:00.514Z"),
                    FechaSalida = DateTime.Parse("2023-12-03T06:00:00.514Z"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 210,
                    Precio = 30000
                },

                new Viaje
                {
                    ViajeId = 23,
                    TransporteId = 6,
                    Duracion = "21 Hora(s)",
                    FechaLlegada = DateTime.Parse("2024-02-07T08:30:00.514Z"),
                    FechaSalida = DateTime.Parse("2024-02-01T06:30:00.514Z"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 300,
                    Precio = 600000
                },

                new Viaje
                {
                    ViajeId = 24,
                    TransporteId = 7,
                    Duracion = "5 Horas",
                    FechaLlegada = DateTime.Parse("1111-11-11T11:11:11.514Z"),
                    FechaSalida = DateTime.Parse("2023-08-25T07:00:00.514Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 275,
                    Precio = 145000
                },

                new Viaje
                {
                    ViajeId = 25,
                    TransporteId = 11,
                    Duracion = "3 Horas 30 min",
                    FechaLlegada = DateTime.Parse("1111-11-11T11:11:11.514Z"),
                    FechaSalida = DateTime.Parse("2023-11-08T14:30:00.514Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 300,
                    Precio = 80500
                },
                new Viaje
                {
                    ViajeId = 26,
                    TransporteId = 12,
                    Duracion = "31 Horas 20 min",
                    FechaLlegada = DateTime.Parse("1111-11-11T11:11:11.514Z"),
                    FechaSalida = DateTime.Parse("2023-08-25T07:00:00.514Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 300,
                    Precio = 635000
                },

                new Viaje
                {
                    ViajeId = 27,
                    TransporteId = 13,
                    Duracion = "20 Horas 30 min",
                    FechaLlegada = DateTime.Parse("2024-04-15T05:00:00.514Z"),
                    FechaSalida = DateTime.Parse("2024-04-08T10:30:00.514Z"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 250,
                    Precio = 545000
                },
                new Viaje
                {
                    ViajeId = 28,
                    TransporteId = 14,
                    Duracion = "20 Horas",
                    FechaLlegada = DateTime.Parse("2023-10-30T20:00:00.514Z"),
                    FechaSalida = DateTime.Parse("2023-10-15T15:00:00.514Z"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 300,
                    Precio = 500000
                },

                new Viaje
                {
                    ViajeId = 29,
                    TransporteId = 24,
                    Duracion = "21 Hora(s)",
                    FechaLlegada = DateTime.Parse("2024-01-09T03:00:00.514Z"),
                    FechaSalida = DateTime.Parse("2024-01-02T06:00:00.514Z"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 70,
                    Precio = 28000
                },

                new Viaje
                {
                    ViajeId = 30,
                    TransporteId = 23,
                    Duracion = "10 Hora(s)",
                    FechaLlegada = DateTime.Parse("1111-11-11T11:11:11.514Z"),
                    FechaSalida = DateTime.Parse("2023-11-28T12:00:00.514Z"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 73,
                    Precio = 238000
                },
                //----------------------------------------
                new Viaje
                {
                    ViajeId = 31,
                    TransporteId = 25,
                    Duracion = "4 horas",
                    FechaLlegada = DateTime.Parse("1111-11-11T11:11:11.514Z"),
                    FechaSalida = DateTime.Parse("2023-09-03T06:00:00.514Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 54,
                    Precio = 22000
                },

                new Viaje
                {
                    ViajeId = 32,
                    TransporteId = 26,
                    Duracion = "17 Hora(s)",
                    FechaLlegada = DateTime.Parse("1111-11-11T11:11:11.514Z"),
                    FechaSalida = DateTime.Parse("2023-10-14T06:30:00.514Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 50,
                    Precio = 41000
                },

                new Viaje
                {
                    ViajeId = 33,
                    TransporteId = 27,
                    Duracion = "3 Horas 30 min",
                    FechaLlegada = DateTime.Parse("1111-11-11T11:11:11.514Z"),
                    FechaSalida = DateTime.Parse("2023-08-25T07:00:00.514Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 44,
                    Precio = 26500
                },

                new Viaje
                {
                    ViajeId = 34,
                    TransporteId = 35,
                    Duracion = "4 Horas 30 min",
                    FechaLlegada = DateTime.Parse("2023-10-02T14:30:00.514Z"),
                    FechaSalida = DateTime.Parse("2023-09-26T14:30:00.514Z"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 175,
                    Precio = 20500
                },
                new Viaje
                {
                    ViajeId = 35,
                    TransporteId = 36,
                    Duracion = "6 Horas",
                    FechaLlegada = DateTime.Parse("2023-12-15T05:00:00.514Z"),
                    FechaSalida = DateTime.Parse("2023-12-08T10:30:00.514Z"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 250,
                    Precio = 15000
                },
                new Viaje
                {
                    ViajeId = 36,
                    TransporteId = 37,
                    Duracion = "7 Horas",
                    FechaLlegada = DateTime.Parse("2023-10-22T10:00:00.514Z"),
                    FechaSalida = DateTime.Parse("2023-10-15T15:00:00.514Z"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 220,
                    Precio = 19000
                },

                new Viaje
                {
                    ViajeId = 37,
                    TransporteId = 38,
                    Duracion = "5 Hora(s) 30 min",
                    FechaLlegada = DateTime.Parse("2024-01-09T03:00:00.514Z"),
                    FechaSalida = DateTime.Parse("2024-01-02T06:00:00.514Z"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 220,
                    Precio = 15000
                },

                new Viaje
                {
                    ViajeId = 38,
                    TransporteId = 34,
                    Duracion = "8 Hora(s)",
                    FechaLlegada = DateTime.Parse("2024-01-09T03:00:00.514Z"),
                    FechaSalida = DateTime.Parse("2024-01-02T12:00:00.514Z"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 200,
                    Precio = 17000
                },

                new Viaje
                {
                    ViajeId = 39,
                    TransporteId = 36,
                    Duracion = "6 horas",
                    FechaLlegada = DateTime.Parse("1111-11-11T11:11:11.514Z"),
                    FechaSalida = DateTime.Parse("2023-09-03T06:00:00.514Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 200,
                    Precio = 22000
                },

                new Viaje
                {
                    ViajeId = 40,
                    TransporteId = 26,
                    Duracion = "6 Hora(s)",
                    FechaLlegada = DateTime.Parse("2023-10-19T06:00:00.514Z"),
                    FechaSalida = DateTime.Parse("2023-10-14T06:30:00.514Z"),
                    TipoViaje = "Ida y vuelta",
                    AsientosDisponibles = 75,
                    Precio = 23000
                },

                new Viaje
                {
                    ViajeId = 41,
                    TransporteId = 27,
                    Duracion = "24 Hora(s)",
                    FechaLlegada = DateTime.Parse("1111-11-11T11:11:11.514Z"),
                    FechaSalida = DateTime.Parse("2023-08-25T07:00:00.514Z"),
                    TipoViaje = "Ida",
                    AsientosDisponibles = 75,
                    Precio = 26500
                });
        }
    }
}
