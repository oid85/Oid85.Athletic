using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oid85.Athletic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20251218_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                schema: "public",
                table: "PressureEntities");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                schema: "public",
                table: "PressureEntities",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "Time",
                schema: "public",
                table: "PressureEntities",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                schema: "public",
                table: "PressureEntities");

            migrationBuilder.DropColumn(
                name: "Time",
                schema: "public",
                table: "PressureEntities");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                schema: "public",
                table: "PressureEntities",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
