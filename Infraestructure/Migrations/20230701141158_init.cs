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
                    { 1, 50, "1 Hora", new DateTime(2023, 10, 5, 19, 33, 39, 514, DateTimeKind.Local), new DateTime(2023, 10, 5, 20, 33, 39, 514, DateTimeKind.Local), 15000, "Ida y vuelta", 1 },
                    { 2, 60, "2 Hora", new DateTime(2023, 11, 5, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 5, 19, 0, 0, 0, DateTimeKind.Local), 12000, "Ida", 2 },
                    { 3, 360, "5 Hora", new DateTime(2023, 12, 5, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 5, 17, 0, 0, 0, DateTimeKind.Local), 8000, "Ida y vuelta", 3 },
                    { 4, 30, "12 Horas", new DateTime(2023, 7, 4, 19, 33, 39, 514, DateTimeKind.Local), new DateTime(2023, 7, 5, 7, 33, 39, 514, DateTimeKind.Local), 11000, "Ida", 19 },
                    { 5, 50, "12 Horas", new DateTime(2023, 8, 4, 19, 33, 39, 514, DateTimeKind.Local), new DateTime(2023, 8, 5, 7, 33, 39, 514, DateTimeKind.Local), 8500, "Ida", 20 },
                    { 6, 50, "5 Horas", new DateTime(2023, 5, 4, 12, 33, 39, 514, DateTimeKind.Local), new DateTime(2023, 5, 5, 7, 33, 39, 514, DateTimeKind.Local), 8000, "Ida", 21 },
                    { 7, 40, "10 Horas", new DateTime(2023, 8, 4, 17, 33, 39, 514, DateTimeKind.Local), new DateTime(2023, 8, 5, 7, 33, 39, 514, DateTimeKind.Local), 8000, "Ida", 22 },
                    { 8, 35, "4 Horas", new DateTime(2023, 6, 5, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 6, 5, 13, 0, 0, 0, DateTimeKind.Local), 8000, "Ida", 23 },
                    { 9, 30, "4 Horas", new DateTime(2023, 5, 5, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2023, 5, 5, 8, 30, 0, 0, DateTimeKind.Local), 8000, "Ida", 24 },
                    { 10, 60, "3 Horas", new DateTime(2023, 7, 6, 6, 15, 0, 0, DateTimeKind.Local), new DateTime(2023, 7, 6, 3, 15, 0, 0, DateTimeKind.Local), 8000, "Ida", 25 },
                    { 11, 50, "4 Horas", new DateTime(2023, 4, 6, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 4, 6, 8, 0, 0, 0, DateTimeKind.Local), 8000, "Ida", 26 },
                    { 12, 30, "5 Horas", new DateTime(2023, 7, 6, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 7, 6, 12, 0, 0, 0, DateTimeKind.Local), 8000, "Ida", 27 },
                    { 13, 30, "4 Horas", new DateTime(2023, 7, 7, 7, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 7, 7, 3, 0, 0, 0, DateTimeKind.Local), 8000, "Ida", 28 },
                    { 14, 45, "5 Horas", new DateTime(2023, 7, 7, 14, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 7, 7, 9, 0, 0, 0, DateTimeKind.Local), 8000, "Ida", 29 },
                    { 15, 20, "5 Horas", new DateTime(2023, 7, 7, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 7, 7, 13, 0, 0, 0, DateTimeKind.Local), 8000, "Ida", 30 },
                    { 16, 15, "2 Horas", new DateTime(2023, 7, 8, 5, 30, 0, 0, DateTimeKind.Local), new DateTime(2023, 7, 8, 3, 30, 0, 0, DateTimeKind.Local), 8000, "Ida", 31 },
                    { 17, 10, "8 Horas", new DateTime(2023, 7, 8, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 7, 8, 4, 0, 0, 0, DateTimeKind.Local), 8000, "Ida", 26 },
                    { 18, 5, "3 Horas", new DateTime(2023, 7, 8, 14, 30, 0, 0, DateTimeKind.Local), new DateTime(2023, 7, 8, 11, 30, 0, 0, DateTimeKind.Local), 8000, "Ida", 33 }
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
