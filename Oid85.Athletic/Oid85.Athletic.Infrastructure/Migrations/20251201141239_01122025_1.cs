using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oid85.Athletic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _01122025_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Equipment",
                schema: "public",
                table: "ExerciseTemplateEntities");

            migrationBuilder.DropColumn(
                name: "Muscles",
                schema: "public",
                table: "ExerciseTemplateEntities");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Equipment",
                schema: "public",
                table: "ExerciseTemplateEntities",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Muscles",
                schema: "public",
                table: "ExerciseTemplateEntities",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);
        }
    }
}
