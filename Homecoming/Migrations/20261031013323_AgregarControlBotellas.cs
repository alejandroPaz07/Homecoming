using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homecoming.Migrations
{
    /// <inheritdoc />
    public partial class AgregarControlBotellas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BotellasEntregadas",
                table: "Estudiantes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BotellasEntregadas",
                table: "Estudiantes");
        }
    }
}
