using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oid85.Athletic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "exercise_templates",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Equipment = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercise_templates", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trainings",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CountCycles = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "exercises",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    CountIterations = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    ExerciseTemplateId = table.Column<Guid>(type: "uuid", nullable: false),
                    TrainingId = table.Column<Guid>(type: "uuid", nullable: false),
                    TrainingEntityId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercises", x => x.id);
                    table.ForeignKey(
                        name: "FK_exercises_exercise_templates_ExerciseTemplateId",
                        column: x => x.ExerciseTemplateId,
                        principalSchema: "public",
                        principalTable: "exercise_templates",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_exercises_trainings_TrainingEntityId",
                        column: x => x.TrainingEntityId,
                        principalSchema: "public",
                        principalTable: "trainings",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_exercises_trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalSchema: "public",
                        principalTable: "trainings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "plans",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    MorningTrainingId = table.Column<Guid>(type: "uuid", nullable: false),
                    DayTrainingId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plans", x => x.id);
                    table.ForeignKey(
                        name: "FK_plans_trainings_DayTrainingId",
                        column: x => x.DayTrainingId,
                        principalSchema: "public",
                        principalTable: "trainings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_plans_trainings_MorningTrainingId",
                        column: x => x.MorningTrainingId,
                        principalSchema: "public",
                        principalTable: "trainings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_exercises_ExerciseTemplateId",
                schema: "public",
                table: "exercises",
                column: "ExerciseTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_exercises_TrainingEntityId",
                schema: "public",
                table: "exercises",
                column: "TrainingEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_exercises_TrainingId",
                schema: "public",
                table: "exercises",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_plans_DayTrainingId",
                schema: "public",
                table: "plans",
                column: "DayTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_plans_MorningTrainingId",
                schema: "public",
                table: "plans",
                column: "MorningTrainingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exercises",
                schema: "public");

            migrationBuilder.DropTable(
                name: "plans",
                schema: "public");

            migrationBuilder.DropTable(
                name: "exercise_templates",
                schema: "public");

            migrationBuilder.DropTable(
                name: "trainings",
                schema: "public");
        }
    }
}
