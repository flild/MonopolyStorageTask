using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MonopolyTestTask.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Palletes",
                columns: table => new
                {
                    PalleteId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Volume = table.Column<float>(type: "real", nullable: false),
                    Depth = table.Column<float>(type: "real", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    Width = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palletes", x => x.PalleteId);
                });

            migrationBuilder.CreateTable(
                name: "Boxes",
                columns: table => new
                {
                    BoxId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Volume = table.Column<float>(type: "real", nullable: false),
                    ExpirationDate = table.Column<DateOnly>(type: "date", nullable: true),
                    PalleteId = table.Column<int>(type: "integer", nullable: true),
                    Depth = table.Column<float>(type: "real", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    Width = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boxes", x => x.BoxId);
                    table.ForeignKey(
                        name: "FK_Boxes_Palletes_PalleteId",
                        column: x => x.PalleteId,
                        principalTable: "Palletes",
                        principalColumn: "PalleteId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boxes_PalleteId",
                table: "Boxes",
                column: "PalleteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boxes");

            migrationBuilder.DropTable(
                name: "Palletes");
        }
    }
}
