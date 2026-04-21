using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CQRS_LB.Migrations
{
    /// <inheritdoc />
    public partial class ForgetDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absence_Students_StudentId",
                table: "Absence");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Absence",
                table: "Absence");

            migrationBuilder.RenameTable(
                name: "Absence",
                newName: "Absences");

            migrationBuilder.RenameIndex(
                name: "IX_Absence_StudentId",
                table: "Absences",
                newName: "IX_Absences_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Absences",
                table: "Absences",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Students_StudentId",
                table: "Absences",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Students_StudentId",
                table: "Absences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Absences",
                table: "Absences");

            migrationBuilder.RenameTable(
                name: "Absences",
                newName: "Absence");

            migrationBuilder.RenameIndex(
                name: "IX_Absences_StudentId",
                table: "Absence",
                newName: "IX_Absence_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Absence",
                table: "Absence",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Absence_Students_StudentId",
                table: "Absence",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
