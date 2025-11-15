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
                name: "ExerciseTemplateEntities",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Muscles = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Equipment = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTemplateEntities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingEntities",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Cycles = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingEntities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseEntities",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    CountIterations = table.Column<int>(type: "integer", nullable: true),
                    Minutes = table.Column<int>(type: "integer", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: true),
                    Weight = table.Column<double>(type: "numeric(4,1)", nullable: true),
                    ExerciseTemplateId = table.Column<Guid>(type: "uuid", nullable: false),
                    TrainingId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseEntities", x => x.id);
                    table.ForeignKey(
                        name: "FK_ExerciseEntities_ExerciseTemplateEntities_ExerciseTemplateId",
                        column: x => x.ExerciseTemplateId,
                        principalSchema: "public",
                        principalTable: "ExerciseTemplateEntities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseEntities_TrainingEntities_TrainingId",
                        column: x => x.TrainingId,
                        principalSchema: "public",
                        principalTable: "TrainingEntities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanEntities",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    MorningTrainingId = table.Column<Guid>(type: "uuid", nullable: true),
                    DayTrainingId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanEntities", x => x.id);
                    table.ForeignKey(
                        name: "FK_PlanEntities_TrainingEntities_DayTrainingId",
                        column: x => x.DayTrainingId,
                        principalSchema: "public",
                        principalTable: "TrainingEntities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_PlanEntities_TrainingEntities_MorningTrainingId",
                        column: x => x.MorningTrainingId,
                        principalSchema: "public",
                        principalTable: "TrainingEntities",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseEntities_ExerciseTemplateId",
                schema: "public",
                table: "ExerciseEntities",
                column: "ExerciseTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseEntities_TrainingId",
                schema: "public",
                table: "ExerciseEntities",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanEntities_DayTrainingId",
                schema: "public",
                table: "PlanEntities",
                column: "DayTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanEntities_MorningTrainingId",
                schema: "public",
                table: "PlanEntities",
                column: "MorningTrainingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseEntities",
                schema: "public");

            migrationBuilder.DropTable(
                name: "PlanEntities",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ExerciseTemplateEntities",
                schema: "public");

            migrationBuilder.DropTable(
                name: "TrainingEntities",
                schema: "public");
        }
    }
}
