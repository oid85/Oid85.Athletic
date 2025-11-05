using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oid85.Athletic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_exercises_trainings_TrainingEntityId",
                schema: "public",
                table: "exercises");

            migrationBuilder.DropIndex(
                name: "IX_exercises_TrainingEntityId",
                schema: "public",
                table: "exercises");

            migrationBuilder.DropColumn(
                name: "TrainingEntityId",
                schema: "public",
                table: "exercises");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TrainingEntityId",
                schema: "public",
                table: "exercises",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_exercises_TrainingEntityId",
                schema: "public",
                table: "exercises",
                column: "TrainingEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_exercises_trainings_TrainingEntityId",
                schema: "public",
                table: "exercises",
                column: "TrainingEntityId",
                principalSchema: "public",
                principalTable: "trainings",
                principalColumn: "id");
        }
    }
}
