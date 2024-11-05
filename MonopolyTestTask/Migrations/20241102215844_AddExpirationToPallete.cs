using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonopolyTestTask.Migrations
{
    /// <inheritdoc />
    public partial class AddExpirationToPallete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "ExpirationDate",
                table: "Palletes",
                type: "date",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Palletes");
        }
    }
}
