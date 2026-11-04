using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homecoming.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCantidadBotellas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CantidadBotellas",
                table: "Estudiantes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
        
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadBotellas",
                table: "Estudiantes");
        }
    }
}
