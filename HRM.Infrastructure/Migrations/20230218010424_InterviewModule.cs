using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InterviewModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InterviewStatus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InterviewType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "varchar(30)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmissionId = table.Column<int>(type: "int", nullable: false),
                    InterviewDate = table.Column<string>(type: "varchar(30)", nullable: false),
                    InterviewRound = table.Column<int>(type: "int", nullable: false),
                    InterviewTypeID = table.Column<int>(type: "int", nullable: false),
                    InterviewStatusID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterviewStatusID1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interview_InterviewStatus_InterviewStatusID1",
                        column: x => x.InterviewStatusID1,
                        principalTable: "InterviewStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interview_InterviewType_InterviewTypeID",
                        column: x => x.InterviewTypeID,
                        principalTable: "InterviewType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interview_Submission_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterviewFeedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterviewID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewFeedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterviewFeedback_Interview_InterviewID",
                        column: x => x.InterviewID,
                        principalTable: "Interview",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interview_InterviewStatusID1",
                table: "Interview",
                column: "InterviewStatusID1");

            migrationBuilder.CreateIndex(
                name: "IX_Interview_InterviewTypeID",
                table: "Interview",
                column: "InterviewTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Interview_SubmissionId",
                table: "Interview",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewFeedback_InterviewID",
                table: "InterviewFeedback",
                column: "InterviewID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterviewFeedback");

            migrationBuilder.DropTable(
                name: "Interview");

            migrationBuilder.DropTable(
                name: "InterviewStatus");

            migrationBuilder.DropTable(
                name: "InterviewType");
        }
    }
}
