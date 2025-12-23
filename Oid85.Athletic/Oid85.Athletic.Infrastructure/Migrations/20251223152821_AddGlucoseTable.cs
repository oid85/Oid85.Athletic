using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oid85.Athletic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGlucoseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GlucoseEntities",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    BeforeMorningFood = table.Column<double>(type: "double precision", nullable: true),
                    AfterMorningFood = table.Column<double>(type: "double precision", nullable: true),
                    BeforeTraining = table.Column<double>(type: "double precision", nullable: true),
                    AfterTraining = table.Column<double>(type: "double precision", nullable: true),
                    BeforeEveningFood = table.Column<double>(type: "double precision", nullable: true),
                    BeforeNight = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlucoseEntities", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GlucoseEntities",
                schema: "public");
        }
    }
}
