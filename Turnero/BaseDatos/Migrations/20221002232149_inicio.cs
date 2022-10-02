using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Turnero.BaseDatos.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TablaClientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaClientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TablaPeluqueros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagenPerfil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DNI = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaPeluqueros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TablaTurnos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeluqueroId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacionTurno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaTurnoReservado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaTurnos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TablaTurnos_TablaClientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TablaClientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TablaTurnos_TablaPeluqueros_PeluqueroId",
                        column: x => x.PeluqueroId,
                        principalTable: "TablaPeluqueros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TablaClientes",
                columns: new[] { "Id", "Apellido", "Email", "Nombre", "NumeroTelefono" },
                values: new object[,]
                {
                    { 1234, "Cejas", "", "Mariano", "123123" },
                    { 2345, "Marin", "", "Tincho", "5234" },
                    { 3456, "Aguada", "", "Nacho", "35124789" }
                });

            migrationBuilder.InsertData(
                table: "TablaPeluqueros",
                columns: new[] { "Id", "Apellido", "DNI", "ImagenPerfil", "Nombre", "Password" },
                values: new object[,]
                {
                    { 11, "Gonzales", "35.214.872", "https://img.freepik.com/foto-gratis/retrato-joven-sonriente-gafas_171337-4842.jpg?w=2000", "David", "ASD" },
                    { 23, "Del Valle", "25.214.872", "https://i0.wp.com/sonria.com/wp-content/uploads/2016/08/2165947w620.jpg?fit=620%2C348&ssl=1", "Eduardo", "ASD" }
                });

            migrationBuilder.InsertData(
                table: "TablaTurnos",
                columns: new[] { "Id", "ClienteId", "FechaCreacionTurno", "FechaTurnoReservado", "PeluqueroId" },
                values: new object[] { 1, 1234, new DateTime(2022, 8, 19, 14, 22, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 22, 18, 30, 0, 0, DateTimeKind.Unspecified), 11 });

            migrationBuilder.InsertData(
                table: "TablaTurnos",
                columns: new[] { "Id", "ClienteId", "FechaCreacionTurno", "FechaTurnoReservado", "PeluqueroId" },
                values: new object[] { 2, 3456, new DateTime(2022, 9, 14, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 23, 16, 30, 0, 0, DateTimeKind.Unspecified), 11 });

            migrationBuilder.InsertData(
                table: "TablaTurnos",
                columns: new[] { "Id", "ClienteId", "FechaCreacionTurno", "FechaTurnoReservado", "PeluqueroId" },
                values: new object[] { 3, 2345, new DateTime(2022, 9, 2, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 17, 30, 0, 0, DateTimeKind.Unspecified), 23 });

            migrationBuilder.CreateIndex(
                name: "ClienteNumeroTelefono_UQ",
                table: "TablaClientes",
                column: "NumeroTelefono",
                unique: true,
                filter: "[NumeroTelefono] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "PeluqueroDNI_UQ",
                table: "TablaPeluqueros",
                column: "DNI",
                unique: true,
                filter: "[DNI] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TablaTurnos_ClienteId",
                table: "TablaTurnos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TablaTurnos_PeluqueroId",
                table: "TablaTurnos",
                column: "PeluqueroId");

            migrationBuilder.CreateIndex(
                name: "TurnoFechaPeluquero",
                table: "TablaTurnos",
                columns: new[] { "FechaTurnoReservado", "PeluqueroId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TablaTurnos");

            migrationBuilder.DropTable(
                name: "TablaClientes");

            migrationBuilder.DropTable(
                name: "TablaPeluqueros");
        }
    }
}
