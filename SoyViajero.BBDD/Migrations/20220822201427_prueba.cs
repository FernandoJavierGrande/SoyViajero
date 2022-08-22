using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoyViajero.BBDD.Migrations
{
    public partial class prueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Publicacion1Id",
                table: "fotos_publicaciones",
                newName: "PublicacionId");

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "fotos_publicaciones",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "fotos_publicaciones");

            migrationBuilder.RenameColumn(
                name: "PublicacionId",
                table: "fotos_publicaciones",
                newName: "Publicacion1Id");
        }
    }
}
