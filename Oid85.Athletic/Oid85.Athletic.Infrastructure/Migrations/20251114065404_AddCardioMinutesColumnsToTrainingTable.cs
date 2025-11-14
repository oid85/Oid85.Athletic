using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oid85.Athletic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCardioMinutesColumnsToTrainingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FinishCardioMinutes",
                schema: "public",
                table: "TrainingEntities",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StartCardioMinutes",
                schema: "public",
                table: "TrainingEntities",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinishCardioMinutes",
                schema: "public",
                table: "TrainingEntities");

            migrationBuilder.DropColumn(
                name: "StartCardioMinutes",
                schema: "public",
                table: "TrainingEntities");
        }
    }
}
