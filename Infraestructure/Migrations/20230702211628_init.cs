using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Viaje",
                columns: table => new
                {
                    ViajeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransporteId = table.Column<int>(type: "int", nullable: false),
                    Duracion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaLlegada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoViaje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AsientosDisponibles = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viaje", x => x.ViajeId);
                });

            migrationBuilder.CreateTable(
                name: "Pasajero",
                columns: table => new
                {
                    PasajeroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumContactoEmergencia = table.Column<int>(type: "int", nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViajeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasajero", x => x.PasajeroId);
                    table.ForeignKey(
                        name: "FK_Pasajero_Viaje_ViajeId",
                        column: x => x.ViajeId,
                        principalTable: "Viaje",
                        principalColumn: "ViajeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Viaje",
                columns: new[] { "ViajeId", "AsientosDisponibles", "Duracion", "FechaLlegada", "FechaSalida", "Precio", "TipoViaje", "TransporteId" },
                values: new object[,]
                {
                    { 1, 45, "8 Horas", new DateTime(2023, 10, 5, 5, 0, 0, 514, DateTimeKind.Local), new DateTime(2023, 10, 12, 5, 0, 0, 514, DateTimeKind.Local), 15000, "Ida y vuelta", 34 },
                    { 2, 200, "8 Horas", new DateTime(2023, 11, 30, 17, 0, 0, 514, DateTimeKind.Local), new DateTime(2023, 11, 15, 19, 0, 0, 514, DateTimeKind.Local), 12000, "Ida y vuelta", 35 },
                    { 3, 300, "18 Horas", new DateTime(2024, 7, 18, 7, 0, 0, 514, DateTimeKind.Local), new DateTime(2024, 7, 1, 17, 0, 0, 514, DateTimeKind.Local), 650000, "Ida y vuelta", 4 },
                    { 4, 350, "30 horas", new DateTime(2024, 6, 7, 19, 30, 0, 514, DateTimeKind.Local), new DateTime(2024, 6, 1, 7, 30, 0, 514, DateTimeKind.Local), 1250000, "Ida y vuelta", 5 },
                    { 5, 123, "2 horas", new DateTime(2023, 12, 10, 5, 0, 0, 514, DateTimeKind.Local), new DateTime(2023, 12, 3, 3, 0, 0, 514, DateTimeKind.Local), 27000, "Ida y vuelta", 6 },
                    { 6, 250, "3 Horas 30 min", new DateTime(1111, 11, 11, 8, 11, 11, 514, DateTimeKind.Local), new DateTime(2023, 7, 10, 7, 30, 0, 514, DateTimeKind.Local), 23000, "Ida", 7 },
                    { 7, 165, "4 Horas", new DateTime(2023, 8, 8, 7, 0, 0, 514, DateTimeKind.Local), new DateTime(2023, 8, 1, 3, 0, 0, 514, DateTimeKind.Local), 30000, "Ida y vuelta", 8 },
                    { 8, 80, "1 Hora(s)", new DateTime(1111, 11, 11, 8, 11, 11, 514, DateTimeKind.Local), new DateTime(2023, 7, 15, 13, 0, 0, 514, DateTimeKind.Local), 30500, "Ida", 12 },
                    { 9, 225, "1 Hora", new DateTime(1111, 11, 11, 8, 11, 11, 514, DateTimeKind.Local), new DateTime(2023, 7, 5, 8, 30, 0, 514, DateTimeKind.Local), 35000, "Ida", 8 },
                    { 10, 350, "1 Hora 30 min", new DateTime(2023, 7, 21, 6, 15, 0, 514, DateTimeKind.Local), new DateTime(2023, 7, 15, 3, 15, 0, 514, DateTimeKind.Local), 41050, "Ida y vuelta", 9 },
                    { 11, 300, "3 Horas", new DateTime(2024, 1, 21, 12, 0, 0, 514, DateTimeKind.Local), new DateTime(2024, 1, 3, 15, 0, 0, 514, DateTimeKind.Local), 70250, "Ida y vuelta", 10 },
                    { 12, 111, "17 Horas", new DateTime(2023, 10, 23, 17, 0, 0, 514, DateTimeKind.Local), new DateTime(2023, 10, 16, 12, 0, 0, 514, DateTimeKind.Local), 350000, "Ida y vuelta", 11 },
                    { 13, 325, "14 Hora(s)", new DateTime(1111, 11, 11, 8, 11, 11, 514, DateTimeKind.Local), new DateTime(2023, 7, 7, 3, 0, 0, 514, DateTimeKind.Local), 380000, "Ida", 13 },
                    { 14, 172, "17 Hora(s)", new DateTime(2023, 12, 13, 14, 0, 0, 514, DateTimeKind.Local), new DateTime(2023, 11, 28, 9, 0, 0, 514, DateTimeKind.Local), 638000, "Ida y vuelta", 14 },
                    { 15, 210, "3 Hora(s)", new DateTime(1111, 11, 11, 8, 11, 11, 514, DateTimeKind.Local), new DateTime(2023, 7, 7, 13, 0, 0, 514, DateTimeKind.Local), 68000, "Ida", 15 },
                    { 16, 190, "5 Hora(s)", new DateTime(2023, 9, 4, 5, 30, 0, 514, DateTimeKind.Local), new DateTime(2023, 9, 1, 3, 30, 0, 514, DateTimeKind.Local), 80000, "Ida y vuelta", 16 },
                    { 17, 85, "19 Horas", new DateTime(2023, 8, 30, 12, 0, 0, 514, DateTimeKind.Local), new DateTime(2023, 8, 25, 4, 0, 0, 514, DateTimeKind.Local), 35000, "Ida y vuelta", 22 },
                    { 18, 250, "2 Horas 30 min", new DateTime(1111, 11, 11, 8, 11, 11, 514, DateTimeKind.Local), new DateTime(2023, 11, 8, 11, 30, 0, 514, DateTimeKind.Local), 54500, "Ida", 17 },
                    { 19, 100, "20 Horas", new DateTime(2023, 10, 23, 17, 0, 0, 514, DateTimeKind.Local), new DateTime(2023, 10, 16, 12, 0, 0, 514, DateTimeKind.Local), 6180000, "Ida y vuelta", 18 },
                    { 20, 295, "12 Hora(s)", new DateTime(2023, 1, 25, 0, 0, 0, 514, DateTimeKind.Local), new DateTime(2023, 1, 2, 3, 0, 0, 514, DateTimeKind.Local), 435000, "Ida y vuelta", 4 },
                    { 21, 133, "8 Hora(s)", new DateTime(1111, 11, 11, 8, 11, 11, 514, DateTimeKind.Local), new DateTime(2023, 11, 28, 9, 0, 0, 514, DateTimeKind.Local), 130000, "Ida", 5 },
                    { 22, 210, "1 Hora(s) 30min", new DateTime(2023, 12, 10, 7, 0, 0, 514, DateTimeKind.Local), new DateTime(2023, 12, 3, 3, 0, 0, 514, DateTimeKind.Local), 30000, "Ida y vuelta", 10 },
                    { 23, 300, "21 Hora(s)", new DateTime(2024, 2, 7, 5, 30, 0, 514, DateTimeKind.Local), new DateTime(2024, 2, 1, 3, 30, 0, 514, DateTimeKind.Local), 600000, "Ida y vuelta", 6 },
                    { 24, 275, "5 Horas", new DateTime(1111, 11, 11, 8, 11, 11, 514, DateTimeKind.Local), new DateTime(2023, 8, 25, 4, 0, 0, 514, DateTimeKind.Local), 145000, "Ida", 7 },
                    { 25, 300, "3 Horas 30 min", new DateTime(1111, 11, 11, 8, 11, 11, 514, DateTimeKind.Local), new DateTime(2023, 11, 8, 11, 30, 0, 514, DateTimeKind.Local), 80500, "Ida", 11 },
                    { 26, 300, "31 Horas 20 min", new DateTime(1111, 11, 11, 8, 11, 11, 514, DateTimeKind.Local), new DateTime(2023, 8, 25, 4, 0, 0, 514, DateTimeKind.Local), 635000, "Ida", 12 },
                    { 27, 250, "20 Horas 30 min", new DateTime(2024, 4, 15, 2, 0, 0, 514, DateTimeKind.Local), new DateTime(2024, 4, 8, 7, 30, 0, 514, DateTimeKind.Local), 545000, "Ida y vuelta", 13 },
                    { 28, 300, "20 Horas", new DateTime(2023, 10, 30, 17, 0, 0, 514, DateTimeKind.Local), new DateTime(2023, 10, 15, 12, 0, 0, 514, DateTimeKind.Local), 500000, "Ida y vuelta", 14 },
                    { 29, 70, "21 Hora(s)", new DateTime(2024, 1, 9, 0, 0, 0, 514, DateTimeKind.Local), new DateTime(2024, 1, 2, 3, 0, 0, 514, DateTimeKind.Local), 28000, "Ida y vuelta", 24 },
                    { 30, 73, "10 Hora(s)", new DateTime(1111, 11, 11, 8, 11, 11, 514, DateTimeKind.Local), new DateTime(2023, 11, 28, 9, 0, 0, 514, DateTimeKind.Local), 238000, "Ida y vuelta", 23 },
                    { 31, 54, "4 horas", new DateTime(1111, 11, 11, 8, 11, 11, 514, DateTimeKind.Local), new DateTime(2023, 9, 3, 3, 0, 0, 514, DateTimeKind.Local), 22000, "Ida", 25 },
                    { 32, 50, "17 Hora(s)", new DateTime(1111, 11, 11, 8, 11, 11, 514, DateTimeKind.Local), new DateTime(2023, 10, 14, 3, 30, 0, 514, DateTimeKind.Local), 41000, "Ida", 26 },
                    { 33, 44, "3 Horas 30 min", new DateTime(1111, 11, 11, 8, 11, 11, 514, DateTimeKind.Local), new DateTime(2023, 8, 25, 4, 0, 0, 514, DateTimeKind.Local), 26500, "Ida", 27 },
                    { 34, 175, "4 Horas 30 min", new DateTime(2023, 10, 2, 11, 30, 0, 514, DateTimeKind.Local), new DateTime(2023, 9, 26, 11, 30, 0, 514, DateTimeKind.Local), 20500, "Ida y vuelta", 35 },
                    { 35, 250, "6 Horas", new DateTime(2023, 12, 15, 2, 0, 0, 514, DateTimeKind.Local), new DateTime(2023, 12, 8, 7, 30, 0, 514, DateTimeKind.Local), 15000, "Ida y vuelta", 36 },
                    { 36, 220, "7 Horas", new DateTime(2023, 10, 22, 7, 0, 0, 514, DateTimeKind.Local), new DateTime(2023, 10, 15, 12, 0, 0, 514, DateTimeKind.Local), 19000, "Ida y vuelta", 37 },
                    { 37, 220, "5 Hora(s) 30 min", new DateTime(2024, 1, 9, 0, 0, 0, 514, DateTimeKind.Local), new DateTime(2024, 1, 2, 3, 0, 0, 514, DateTimeKind.Local), 15000, "Ida y vuelta", 38 },
                    { 38, 200, "8 Hora(s)", new DateTime(2024, 1, 9, 0, 0, 0, 514, DateTimeKind.Local), new DateTime(2024, 1, 2, 9, 0, 0, 514, DateTimeKind.Local), 17000, "Ida y vuelta", 34 },
                    { 39, 200, "6 horas", new DateTime(1111, 11, 11, 8, 11, 11, 514, DateTimeKind.Local), new DateTime(2023, 9, 3, 3, 0, 0, 514, DateTimeKind.Local), 22000, "Ida", 36 },
                    { 40, 75, "6 Hora(s)", new DateTime(2023, 10, 19, 3, 0, 0, 514, DateTimeKind.Local), new DateTime(2023, 10, 14, 3, 30, 0, 514, DateTimeKind.Local), 23000, "Ida y vuelta", 26 },
                    { 41, 75, "24 Hora(s)", new DateTime(1111, 11, 11, 8, 11, 11, 514, DateTimeKind.Local), new DateTime(2023, 8, 25, 4, 0, 0, 514, DateTimeKind.Local), 26500, "Ida", 27 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pasajero_ViajeId",
                table: "Pasajero",
                column: "ViajeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pasajero");

            migrationBuilder.DropTable(
                name: "Viaje");
        }
    }
}
