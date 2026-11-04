using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homecoming.Migrations
{
    /// <inheritdoc />
    public partial class AgregarSistmaQR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodigoQR",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EntradaUtilizada",
                table: "Estudiantes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoQR",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "EntradaUtilizada",
                table: "Estudiantes");
        }
    }
}
