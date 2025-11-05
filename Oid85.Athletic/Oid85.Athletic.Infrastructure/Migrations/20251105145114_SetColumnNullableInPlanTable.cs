using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oid85.Athletic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SetColumnNullableInPlanTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanEntities_TrainingEntities_DayTrainingId",
                schema: "public",
                table: "PlanEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanEntities_TrainingEntities_MorningTrainingId",
                schema: "public",
                table: "PlanEntities");

            migrationBuilder.AlterColumn<Guid>(
                name: "MorningTrainingId",
                schema: "public",
                table: "PlanEntities",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "DayTrainingId",
                schema: "public",
                table: "PlanEntities",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanEntities_TrainingEntities_DayTrainingId",
                schema: "public",
                table: "PlanEntities",
                column: "DayTrainingId",
                principalSchema: "public",
                principalTable: "TrainingEntities",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanEntities_TrainingEntities_MorningTrainingId",
                schema: "public",
                table: "PlanEntities",
                column: "MorningTrainingId",
                principalSchema: "public",
                principalTable: "TrainingEntities",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanEntities_TrainingEntities_DayTrainingId",
                schema: "public",
                table: "PlanEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanEntities_TrainingEntities_MorningTrainingId",
                schema: "public",
                table: "PlanEntities");

            migrationBuilder.AlterColumn<Guid>(
                name: "MorningTrainingId",
                schema: "public",
                table: "PlanEntities",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DayTrainingId",
                schema: "public",
                table: "PlanEntities",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanEntities_TrainingEntities_DayTrainingId",
                schema: "public",
                table: "PlanEntities",
                column: "DayTrainingId",
                principalSchema: "public",
                principalTable: "TrainingEntities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanEntities_TrainingEntities_MorningTrainingId",
                schema: "public",
                table: "PlanEntities",
                column: "MorningTrainingId",
                principalSchema: "public",
                principalTable: "TrainingEntities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
