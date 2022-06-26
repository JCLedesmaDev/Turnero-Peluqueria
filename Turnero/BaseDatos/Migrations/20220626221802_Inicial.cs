using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Turnero.BaseDatos.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TablaClientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
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
                    NombreCompleto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImagenPerfil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
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
                    FechaTurno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeluqueroId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "ClienteNumeroTelefono_UQ",
                table: "TablaClientes",
                column: "NumeroTelefono",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PeluqueroDNI_UQ",
                table: "TablaPeluqueros",
                column: "DNI",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TablaTurnos_ClienteId",
                table: "TablaTurnos",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TablaTurnos_PeluqueroId",
                table: "TablaTurnos",
                column: "PeluqueroId");

            migrationBuilder.CreateIndex(
                name: "TurnoFechaPeluqueroCliente",
                table: "TablaTurnos",
                columns: new[] { "FechaTurno", "PeluqueroId", "ClienteId" },
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
