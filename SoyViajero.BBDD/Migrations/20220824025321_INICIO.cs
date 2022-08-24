using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoyViajero.BBDD.Migrations
{
    public partial class INICIO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CuentasHostel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoPerfil = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentasHostel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CuentasHostel_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuentasViajeros",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoPerfil = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentasViajeros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CuentasViajeros_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Publicaciones",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Texto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CuentasId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cuentaHostelId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    cuentaViajeroId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicaciones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Publicaciones_CuentasHostel_cuentaHostelId",
                        column: x => x.cuentaHostelId,
                        principalTable: "CuentasHostel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Publicaciones_CuentasViajeros_cuentaViajeroId",
                        column: x => x.cuentaViajeroId,
                        principalTable: "CuentasViajeros",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    texto = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PublicacionId = table.Column<int>(type: "int", nullable: false),
                    CuentasId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CuentaHostelId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CuentaViajeroId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comentarios_CuentasHostel_CuentaHostelId",
                        column: x => x.CuentaHostelId,
                        principalTable: "CuentasHostel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comentarios_CuentasViajeros_CuentaViajeroId",
                        column: x => x.CuentaViajeroId,
                        principalTable: "CuentasViajeros",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comentarios_Publicaciones_PublicacionId",
                        column: x => x.PublicacionId,
                        principalTable: "Publicaciones",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fotos_publicaciones",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicacionId = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fotos_publicaciones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_fotos_publicaciones_Publicaciones_PublicacionId",
                        column: x => x.PublicacionId,
                        principalTable: "Publicaciones",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_CuentaHostelId",
                table: "Comentarios",
                column: "CuentaHostelId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_CuentaViajeroId",
                table: "Comentarios",
                column: "CuentaViajeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_PublicacionId",
                table: "Comentarios",
                column: "PublicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_CuentasHostel_UsuarioId",
                table: "CuentasHostel",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_CuentasViajeros_UsuarioId",
                table: "CuentasViajeros",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fotos_publicaciones_PublicacionId",
                table: "fotos_publicaciones",
                column: "PublicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_cuentaHostelId",
                table: "Publicaciones",
                column: "cuentaHostelId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_cuentaViajeroId",
                table: "Publicaciones",
                column: "cuentaViajeroId");

            migrationBuilder.CreateIndex(
                name: "uqUser",
                table: "Usuarios",
                column: "NombreUser",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "fotos_publicaciones");

            migrationBuilder.DropTable(
                name: "Publicaciones");

            migrationBuilder.DropTable(
                name: "CuentasHostel");

            migrationBuilder.DropTable(
                name: "CuentasViajeros");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
