using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiciMax.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AddMovementReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MovementReport",
                table: "MovementReport");

            migrationBuilder.RenameTable(
                name: "MovementReport",
                newName: "MovementReports");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovementReports",
                table: "MovementReports",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MovementReports",
                table: "MovementReports");

            migrationBuilder.RenameTable(
                name: "MovementReports",
                newName: "MovementReport");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovementReport",
                table: "MovementReport",
                column: "Id");
        }
    }
}
