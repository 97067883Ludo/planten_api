using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace planten_api.Migrations
{
    /// <inheritdoc />
    public partial class addactivationDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ActivatedAt",
                table: "Devices",
                type: "timestamp without time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivatedAt",
                table: "Devices");
        }
    }
}
