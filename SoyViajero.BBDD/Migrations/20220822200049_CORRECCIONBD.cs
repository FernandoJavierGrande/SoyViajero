using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoyViajero.BBDD.Migrations
{
    public partial class CORRECCIONBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fotos_publicacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fotos_publicacion",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PublicacionesID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Publicacion1Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fotos_publicacion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_fotos_publicacion_Publicaciones_PublicacionesID",
                        column: x => x.PublicacionesID,
                        principalTable: "Publicaciones",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_fotos_publicacion_PublicacionesID",
                table: "fotos_publicacion",
                column: "PublicacionesID");
        }
    }
}
