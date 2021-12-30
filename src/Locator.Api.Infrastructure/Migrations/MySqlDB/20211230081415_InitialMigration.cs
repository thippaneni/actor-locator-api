using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locator.Api.Infrastructure.Migrations.MySqlDB
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LandMarks",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandMarks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    StartLandmarkCode = table.Column<string>(type: "text", nullable: true),
                    EndLandmarkCode = table.Column<string>(type: "text", nullable: true),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    RouteCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LandMarks");

            migrationBuilder.DropTable(
                name: "Routes");
        }
    }
}
