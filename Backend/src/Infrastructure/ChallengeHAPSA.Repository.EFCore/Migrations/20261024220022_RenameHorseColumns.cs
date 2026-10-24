using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChallengeHAPSA.Repository.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class RenameHorseColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Horses",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Horses",
                newName: "Birthday");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Horses",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "Horses",
                newName: "CreationDate");
        }
    }
}
