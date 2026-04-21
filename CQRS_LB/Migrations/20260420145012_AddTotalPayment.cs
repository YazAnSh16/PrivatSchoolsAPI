using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CQRS_LB.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalBalance",
                table: "Payments",
                newName: "TotalAmount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Payments",
                newName: "TotalBalance");
        }
    }
}
