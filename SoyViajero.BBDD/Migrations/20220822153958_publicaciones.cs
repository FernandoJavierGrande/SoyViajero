using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoyViajero.BBDD.Migrations
{
    public partial class publicaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Publicaciones",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CuentasId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicaciones", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    texto = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Publicacion1Id = table.Column<int>(type: "int", nullable: false),
                    PublicacionesID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CuentasId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comentario_Publicaciones_PublicacionesID",
                        column: x => x.PublicacionesID,
                        principalTable: "Publicaciones",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "fotos_publicacion",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Publicacion1Id = table.Column<int>(type: "int", nullable: false),
                    PublicacionesID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "fotos_publicaciones",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Publicacion1Id = table.Column<int>(type: "int", nullable: false),
                    PublicacionesID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fotos_publicaciones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_fotos_publicaciones_Publicaciones_PublicacionesID",
                        column: x => x.PublicacionesID,
                        principalTable: "Publicaciones",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_PublicacionesID",
                table: "Comentario",
                column: "PublicacionesID");

            migrationBuilder.CreateIndex(
                name: "IX_fotos_publicacion_PublicacionesID",
                table: "fotos_publicacion",
                column: "PublicacionesID");

            migrationBuilder.CreateIndex(
                name: "IX_fotos_publicaciones_PublicacionesID",
                table: "fotos_publicaciones",
                column: "PublicacionesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "fotos_publicacion");

            migrationBuilder.DropTable(
                name: "fotos_publicaciones");

            migrationBuilder.DropTable(
                name: "Publicaciones");
        }
    }
}
