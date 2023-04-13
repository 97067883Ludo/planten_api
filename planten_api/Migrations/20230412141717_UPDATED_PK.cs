using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace planten_api.Migrations
{
    /// <inheritdoc />
    public partial class UPDATED_PK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SoilMoistureId",
                table: "SoilMoistures",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SoilMoistures",
                newName: "SoilMoistureId");
        }
    }
}
