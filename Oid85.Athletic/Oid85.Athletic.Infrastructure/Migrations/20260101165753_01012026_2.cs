using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oid85.Athletic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _01012026_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanEntities_TrainingEntities_MorningTrainingId",
                schema: "public",
                table: "PlanEntities");

            migrationBuilder.DropIndex(
                name: "IX_PlanEntities_MorningTrainingId",
                schema: "public",
                table: "PlanEntities");

            migrationBuilder.DropColumn(
                name: "MorningTrainingId",
                schema: "public",
                table: "PlanEntities");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MorningTrainingId",
                schema: "public",
                table: "PlanEntities",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanEntities_MorningTrainingId",
                schema: "public",
                table: "PlanEntities",
                column: "MorningTrainingId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanEntities_TrainingEntities_MorningTrainingId",
                schema: "public",
                table: "PlanEntities",
                column: "MorningTrainingId",
                principalSchema: "public",
                principalTable: "TrainingEntities",
                principalColumn: "id");
        }
    }
}
