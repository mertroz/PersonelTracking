using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonnelTrackingSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class salarypayment_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "SalaryPayment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "SalaryPayment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Month",
                table: "SalaryPayment");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "SalaryPayment");
        }
    }
}
