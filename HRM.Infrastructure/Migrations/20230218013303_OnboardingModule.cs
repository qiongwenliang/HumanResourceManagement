using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OnboardingModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(type: "varchar(30)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "varchar(10)", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "varchar(20)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "varchar(30)", nullable: false),
                    DateOfBirth = table.Column<string>(type: "varchar(30)", nullable: false),
                    SSN = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "varchar(100)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    EmployeeRoleId = table.Column<int>(type: "int", nullable: false),
                    EmployeeTypeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_EmployeeRole_EmployeeRoleId",
                        column: x => x.EmployeeRoleId,
                        principalTable: "EmployeeRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_EmployeeStatus_EmployeeStatusId",
                        column: x => x.EmployeeStatusId,
                        principalTable: "EmployeeStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_EmployeeType_EmployeeTypeId",
                        column: x => x.EmployeeTypeId,
                        principalTable: "EmployeeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeRoleId",
                table: "Employee",
                column: "EmployeeRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeStatusId",
                table: "Employee",
                column: "EmployeeStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeTypeId",
                table: "Employee",
                column: "EmployeeTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "EmployeeRole");

            migrationBuilder.DropTable(
                name: "EmployeeStatus");

            migrationBuilder.DropTable(
                name: "EmployeeType");
        }
    }
}
