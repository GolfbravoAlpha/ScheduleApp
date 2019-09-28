using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleApp.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StaffTbl",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    jobTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffTbl", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "StudentTbl",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    age = table.Column<byte>(nullable: false),
                    subjectStudying = table.Column<string>(nullable: true),
                    disability = table.Column<string>(nullable: true),
                    additionalInformation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTbl", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "staffHoursWorkedTbl",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    startDateAndTime = table.Column<DateTime>(nullable: false),
                    endDateAndTime = table.Column<DateTime>(nullable: false),
                    staffId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staffHoursWorkedTbl", x => x.id);
                    table.ForeignKey(
                        name: "FK_staffHoursWorkedTbl_StaffTbl_staffId",
                        column: x => x.staffId,
                        principalTable: "StaffTbl",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleDateAndTimeTbl",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    startDateAndTime = table.Column<DateTime>(nullable: false),
                    endDateAndTime = table.Column<DateTime>(nullable: false),
                    studentId = table.Column<int>(nullable: true),
                    staffId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleDateAndTimeTbl", x => x.id);
                    table.ForeignKey(
                        name: "FK_ScheduleDateAndTimeTbl_StaffTbl_staffId",
                        column: x => x.staffId,
                        principalTable: "StaffTbl",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleDateAndTimeTbl_StudentTbl_studentId",
                        column: x => x.studentId,
                        principalTable: "StudentTbl",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDateAndTimeTbl_staffId",
                table: "ScheduleDateAndTimeTbl",
                column: "staffId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDateAndTimeTbl_studentId",
                table: "ScheduleDateAndTimeTbl",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_staffHoursWorkedTbl_staffId",
                table: "staffHoursWorkedTbl",
                column: "staffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleDateAndTimeTbl");

            migrationBuilder.DropTable(
                name: "staffHoursWorkedTbl");

            migrationBuilder.DropTable(
                name: "StudentTbl");

            migrationBuilder.DropTable(
                name: "StaffTbl");
        }
    }
}
