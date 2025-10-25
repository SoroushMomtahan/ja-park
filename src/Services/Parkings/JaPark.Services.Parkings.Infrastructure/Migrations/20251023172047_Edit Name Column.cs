using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JaPark.Services.Parkings.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditNameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name_Value",
                table: "Parkings",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Parkings",
                newName: "Name_Value");
        }
    }
}
