using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace planten_api.Migrations
{
    /// <inheritdoc />
    public partial class addeddeviceactive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ActiveDevice",
                table: "Devices",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveDevice",
                table: "Devices");
        }
    }
}
