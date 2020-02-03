using Microsoft.EntityFrameworkCore.Migrations;

namespace proyectoSolveX.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Anio",
                table: "Nomina",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoUsuario",
                table: "Empleados",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anio",
                table: "Nomina");

            migrationBuilder.DropColumn(
                name: "TipoUsuario",
                table: "Empleados");
        }
    }
}
