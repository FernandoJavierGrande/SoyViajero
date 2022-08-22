using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoyViajero.BBDD.Migrations
{
    public partial class cuentaHostelfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cuentaHostelId",
                table: "Publicaciones",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cuentaViajeroId",
                table: "Publicaciones",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "fotos_publicaciones",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CuentaHostelId",
                table: "Comentario",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CuentaViajeroId",
                table: "Comentario",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_cuentaHostelId",
                table: "Publicaciones",
                column: "cuentaHostelId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_cuentaViajeroId",
                table: "Publicaciones",
                column: "cuentaViajeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_CuentaHostelId",
                table: "Comentario",
                column: "CuentaHostelId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_CuentaViajeroId",
                table: "Comentario",
                column: "CuentaViajeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_CuentasHostel_CuentaHostelId",
                table: "Comentario",
                column: "CuentaHostelId",
                principalTable: "CuentasHostel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_CuentasViajeros_CuentaViajeroId",
                table: "Comentario",
                column: "CuentaViajeroId",
                principalTable: "CuentasViajeros",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Publicaciones_CuentasHostel_cuentaHostelId",
                table: "Publicaciones",
                column: "cuentaHostelId",
                principalTable: "CuentasHostel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Publicaciones_CuentasViajeros_cuentaViajeroId",
                table: "Publicaciones",
                column: "cuentaViajeroId",
                principalTable: "CuentasViajeros",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_CuentasHostel_CuentaHostelId",
                table: "Comentario");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_CuentasViajeros_CuentaViajeroId",
                table: "Comentario");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicaciones_CuentasHostel_cuentaHostelId",
                table: "Publicaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicaciones_CuentasViajeros_cuentaViajeroId",
                table: "Publicaciones");

            migrationBuilder.DropIndex(
                name: "IX_Publicaciones_cuentaHostelId",
                table: "Publicaciones");

            migrationBuilder.DropIndex(
                name: "IX_Publicaciones_cuentaViajeroId",
                table: "Publicaciones");

            migrationBuilder.DropIndex(
                name: "IX_Comentario_CuentaHostelId",
                table: "Comentario");

            migrationBuilder.DropIndex(
                name: "IX_Comentario_CuentaViajeroId",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "cuentaHostelId",
                table: "Publicaciones");

            migrationBuilder.DropColumn(
                name: "cuentaViajeroId",
                table: "Publicaciones");

            migrationBuilder.DropColumn(
                name: "CuentaHostelId",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "CuentaViajeroId",
                table: "Comentario");

            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "fotos_publicaciones",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
