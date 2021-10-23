using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leyre.University.Repository.Migrations
{
    public partial class AddUniversityContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_COURSE",
                columns: table => new
                {
                    ID_COURSE = table.Column<int>(type: "int", nullable: false),
                    DS_TITLE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NR_CREDITS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_COURSE", x => x.ID_COURSE);
                });

            migrationBuilder.CreateTable(
                name: "TB_STUDENT",
                columns: table => new
                {
                    ID_STUDENT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DS_FIRST_MID_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DS_LAST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DT_ENROLLMENT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_STUDENT", x => x.ID_STUDENT);
                });

            migrationBuilder.CreateTable(
                name: "TB_ENROLLMENT",
                columns: table => new
                {
                    ID_ENROLLMENT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_COURSE = table.Column<int>(type: "int", nullable: false),
                    ID_STUDENT = table.Column<int>(type: "int", nullable: false),
                    DS_GRADE = table.Column<string>(type: "char", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ENROLLMENT", x => x.ID_ENROLLMENT);
                    table.ForeignKey(
                        name: "FK_TB_ENROLLMENT_TB_COURSE_ID_COURSE",
                        column: x => x.ID_COURSE,
                        principalTable: "TB_COURSE",
                        principalColumn: "ID_COURSE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ENROLLMENT_TB_STUDENT_ID_STUDENT",
                        column: x => x.ID_STUDENT,
                        principalTable: "TB_STUDENT",
                        principalColumn: "ID_STUDENT",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ENROLLMENT_ID_COURSE",
                table: "TB_ENROLLMENT",
                column: "ID_COURSE");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ENROLLMENT_ID_STUDENT",
                table: "TB_ENROLLMENT",
                column: "ID_STUDENT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ENROLLMENT");

            migrationBuilder.DropTable(
                name: "TB_COURSE");

            migrationBuilder.DropTable(
                name: "TB_STUDENT");
        }
    }
}
