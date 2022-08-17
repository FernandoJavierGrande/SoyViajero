using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoyViajero.BBDD.Migrations
{
    public partial class modKeyCuentas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CuentasViajeros",
                table: "CuentasViajeros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CuentasHostel",
                table: "CuentasHostel");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "CuentasViajeros");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "CuentasHostel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CuentasViajeros",
                table: "CuentasViajeros",
                column: "CuentaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CuentasHostel",
                table: "CuentasHostel",
                column: "CuentaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CuentasViajeros",
                table: "CuentasViajeros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CuentasHostel",
                table: "CuentasHostel");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "CuentasViajeros",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "CuentasHostel",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CuentasViajeros",
                table: "CuentasViajeros",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CuentasHostel",
                table: "CuentasHostel",
                column: "ID");
        }
    }
}
