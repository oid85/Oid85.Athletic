using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oid85.Athletic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SetColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_exercises_exercise_templates_ExerciseTemplateId",
                schema: "public",
                table: "exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_exercises_trainings_TrainingId",
                schema: "public",
                table: "exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_plans_trainings_DayTrainingId",
                schema: "public",
                table: "plans");

            migrationBuilder.DropForeignKey(
                name: "FK_plans_trainings_MorningTrainingId",
                schema: "public",
                table: "plans");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "public",
                table: "trainings",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "CountCycles",
                schema: "public",
                table: "trainings",
                newName: "count_cycles");

            migrationBuilder.RenameColumn(
                name: "Date",
                schema: "public",
                table: "plans",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "MorningTrainingId",
                schema: "public",
                table: "plans",
                newName: "morning_training_id");

            migrationBuilder.RenameColumn(
                name: "DayTrainingId",
                schema: "public",
                table: "plans",
                newName: "day_training_id");

            migrationBuilder.RenameIndex(
                name: "IX_plans_MorningTrainingId",
                schema: "public",
                table: "plans",
                newName: "IX_plans_morning_training_id");

            migrationBuilder.RenameIndex(
                name: "IX_plans_DayTrainingId",
                schema: "public",
                table: "plans",
                newName: "IX_plans_day_training_id");

            migrationBuilder.RenameColumn(
                name: "Order",
                schema: "public",
                table: "exercises",
                newName: "order");

            migrationBuilder.RenameColumn(
                name: "TrainingId",
                schema: "public",
                table: "exercises",
                newName: "training_id");

            migrationBuilder.RenameColumn(
                name: "ExerciseTemplateId",
                schema: "public",
                table: "exercises",
                newName: "exercise_template_id");

            migrationBuilder.RenameColumn(
                name: "CountIterations",
                schema: "public",
                table: "exercises",
                newName: "count_iterations");

            migrationBuilder.RenameIndex(
                name: "IX_exercises_TrainingId",
                schema: "public",
                table: "exercises",
                newName: "IX_exercises_training_id");

            migrationBuilder.RenameIndex(
                name: "IX_exercises_ExerciseTemplateId",
                schema: "public",
                table: "exercises",
                newName: "IX_exercises_exercise_template_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "public",
                table: "exercise_templates",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Equipment",
                schema: "public",
                table: "exercise_templates",
                newName: "equipment");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "public",
                table: "trainings",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "public",
                table: "exercise_templates",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "equipment",
                schema: "public",
                table: "exercise_templates",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_exercises_exercise_templates_exercise_template_id",
                schema: "public",
                table: "exercises",
                column: "exercise_template_id",
                principalSchema: "public",
                principalTable: "exercise_templates",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_exercises_trainings_training_id",
                schema: "public",
                table: "exercises",
                column: "training_id",
                principalSchema: "public",
                principalTable: "trainings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_plans_trainings_day_training_id",
                schema: "public",
                table: "plans",
                column: "day_training_id",
                principalSchema: "public",
                principalTable: "trainings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_plans_trainings_morning_training_id",
                schema: "public",
                table: "plans",
                column: "morning_training_id",
                principalSchema: "public",
                principalTable: "trainings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_exercises_exercise_templates_exercise_template_id",
                schema: "public",
                table: "exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_exercises_trainings_training_id",
                schema: "public",
                table: "exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_plans_trainings_day_training_id",
                schema: "public",
                table: "plans");

            migrationBuilder.DropForeignKey(
                name: "FK_plans_trainings_morning_training_id",
                schema: "public",
                table: "plans");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "public",
                table: "trainings",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "count_cycles",
                schema: "public",
                table: "trainings",
                newName: "CountCycles");

            migrationBuilder.RenameColumn(
                name: "date",
                schema: "public",
                table: "plans",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "morning_training_id",
                schema: "public",
                table: "plans",
                newName: "MorningTrainingId");

            migrationBuilder.RenameColumn(
                name: "day_training_id",
                schema: "public",
                table: "plans",
                newName: "DayTrainingId");

            migrationBuilder.RenameIndex(
                name: "IX_plans_morning_training_id",
                schema: "public",
                table: "plans",
                newName: "IX_plans_MorningTrainingId");

            migrationBuilder.RenameIndex(
                name: "IX_plans_day_training_id",
                schema: "public",
                table: "plans",
                newName: "IX_plans_DayTrainingId");

            migrationBuilder.RenameColumn(
                name: "order",
                schema: "public",
                table: "exercises",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "training_id",
                schema: "public",
                table: "exercises",
                newName: "TrainingId");

            migrationBuilder.RenameColumn(
                name: "exercise_template_id",
                schema: "public",
                table: "exercises",
                newName: "ExerciseTemplateId");

            migrationBuilder.RenameColumn(
                name: "count_iterations",
                schema: "public",
                table: "exercises",
                newName: "CountIterations");

            migrationBuilder.RenameIndex(
                name: "IX_exercises_training_id",
                schema: "public",
                table: "exercises",
                newName: "IX_exercises_TrainingId");

            migrationBuilder.RenameIndex(
                name: "IX_exercises_exercise_template_id",
                schema: "public",
                table: "exercises",
                newName: "IX_exercises_ExerciseTemplateId");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "public",
                table: "exercise_templates",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "equipment",
                schema: "public",
                table: "exercise_templates",
                newName: "Equipment");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "public",
                table: "trainings",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "public",
                table: "exercise_templates",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Equipment",
                schema: "public",
                table: "exercise_templates",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AddForeignKey(
                name: "FK_exercises_exercise_templates_ExerciseTemplateId",
                schema: "public",
                table: "exercises",
                column: "ExerciseTemplateId",
                principalSchema: "public",
                principalTable: "exercise_templates",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_exercises_trainings_TrainingId",
                schema: "public",
                table: "exercises",
                column: "TrainingId",
                principalSchema: "public",
                principalTable: "trainings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_plans_trainings_DayTrainingId",
                schema: "public",
                table: "plans",
                column: "DayTrainingId",
                principalSchema: "public",
                principalTable: "trainings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_plans_trainings_MorningTrainingId",
                schema: "public",
                table: "plans",
                column: "MorningTrainingId",
                principalSchema: "public",
                principalTable: "trainings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
