using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyFKTypeOnInterview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interview_InterviewStatus_InterviewStatusID1",
                table: "Interview");

            migrationBuilder.DropIndex(
                name: "IX_Interview_InterviewStatusID1",
                table: "Interview");

            migrationBuilder.DropColumn(
                name: "InterviewStatusID1",
                table: "Interview");

            migrationBuilder.AlterColumn<int>(
                name: "InterviewStatusID",
                table: "Interview",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Interview_InterviewStatusID",
                table: "Interview",
                column: "InterviewStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_InterviewStatus_InterviewStatusID",
                table: "Interview",
                column: "InterviewStatusID",
                principalTable: "InterviewStatus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interview_InterviewStatus_InterviewStatusID",
                table: "Interview");

            migrationBuilder.DropIndex(
                name: "IX_Interview_InterviewStatusID",
                table: "Interview");

            migrationBuilder.AlterColumn<string>(
                name: "InterviewStatusID",
                table: "Interview",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "InterviewStatusID1",
                table: "Interview",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Interview_InterviewStatusID1",
                table: "Interview",
                column: "InterviewStatusID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_InterviewStatus_InterviewStatusID1",
                table: "Interview",
                column: "InterviewStatusID1",
                principalTable: "InterviewStatus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
