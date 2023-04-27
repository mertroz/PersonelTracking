using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonnelTrackingSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class permissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PermitDate",
                table: "Permission",
                newName: "PermitStartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "PermitEndDate",
                table: "Permission",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PermitEndDate",
                table: "Permission");

            migrationBuilder.RenameColumn(
                name: "PermitStartDate",
                table: "Permission",
                newName: "PermitDate");
        }
    }
}
