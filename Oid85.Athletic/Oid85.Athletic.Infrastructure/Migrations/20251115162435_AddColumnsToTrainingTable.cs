using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oid85.Athletic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnsToTrainingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalCountIterations",
                schema: "public",
                table: "TrainingEntities",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalWeight",
                schema: "public",
                table: "TrainingEntities",
                type: "numeric(6,1)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCountIterations",
                schema: "public",
                table: "TrainingEntities");

            migrationBuilder.DropColumn(
                name: "TotalWeight",
                schema: "public",
                table: "TrainingEntities");
        }
    }
}
