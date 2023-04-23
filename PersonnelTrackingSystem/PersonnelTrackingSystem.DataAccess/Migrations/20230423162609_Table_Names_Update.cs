using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonnelTrackingSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Table_Names_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Costs_Employee_EmployeeId",
                table: "Costs");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Employee_EmployeeId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Employee_EmployeeId",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_SalaryCalculators_Employee_EmployeeId",
                table: "SalaryCalculators");

            migrationBuilder.DropForeignKey(
                name: "FK_SalaryPayments_Employee_EmployeeId",
                table: "SalaryPayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalaryPayments",
                table: "SalaryPayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalaryCalculators",
                table: "SalaryCalculators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Materials",
                table: "Materials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Costs",
                table: "Costs");

            migrationBuilder.RenameTable(
                name: "SalaryPayments",
                newName: "SalaryPayment");

            migrationBuilder.RenameTable(
                name: "SalaryCalculators",
                newName: "SalaryCalculator");

            migrationBuilder.RenameTable(
                name: "Permissions",
                newName: "Permission");

            migrationBuilder.RenameTable(
                name: "Materials",
                newName: "Material");

            migrationBuilder.RenameTable(
                name: "Costs",
                newName: "Cost");

            migrationBuilder.RenameIndex(
                name: "IX_SalaryPayments_EmployeeId",
                table: "SalaryPayment",
                newName: "IX_SalaryPayment_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_SalaryCalculators_EmployeeId",
                table: "SalaryCalculator",
                newName: "IX_SalaryCalculator_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Permissions_EmployeeId",
                table: "Permission",
                newName: "IX_Permission_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Materials_EmployeeId",
                table: "Material",
                newName: "IX_Material_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Costs_EmployeeId",
                table: "Cost",
                newName: "IX_Cost_EmployeeId");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "SalaryPayment",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Paid",
                table: "SalaryPayment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalaryPayment",
                table: "SalaryPayment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalaryCalculator",
                table: "SalaryCalculator",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permission",
                table: "Permission",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Material",
                table: "Material",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cost",
                table: "Cost",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cost_Employee_EmployeeId",
                table: "Cost",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Material_Employee_EmployeeId",
                table: "Material",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_Employee_EmployeeId",
                table: "Permission",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalaryCalculator_Employee_EmployeeId",
                table: "SalaryCalculator",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalaryPayment_Employee_EmployeeId",
                table: "SalaryPayment",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cost_Employee_EmployeeId",
                table: "Cost");

            migrationBuilder.DropForeignKey(
                name: "FK_Material_Employee_EmployeeId",
                table: "Material");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_Employee_EmployeeId",
                table: "Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_SalaryCalculator_Employee_EmployeeId",
                table: "SalaryCalculator");

            migrationBuilder.DropForeignKey(
                name: "FK_SalaryPayment_Employee_EmployeeId",
                table: "SalaryPayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalaryPayment",
                table: "SalaryPayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalaryCalculator",
                table: "SalaryCalculator");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permission",
                table: "Permission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Material",
                table: "Material");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cost",
                table: "Cost");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "SalaryPayment");

            migrationBuilder.DropColumn(
                name: "Paid",
                table: "SalaryPayment");

            migrationBuilder.RenameTable(
                name: "SalaryPayment",
                newName: "SalaryPayments");

            migrationBuilder.RenameTable(
                name: "SalaryCalculator",
                newName: "SalaryCalculators");

            migrationBuilder.RenameTable(
                name: "Permission",
                newName: "Permissions");

            migrationBuilder.RenameTable(
                name: "Material",
                newName: "Materials");

            migrationBuilder.RenameTable(
                name: "Cost",
                newName: "Costs");

            migrationBuilder.RenameIndex(
                name: "IX_SalaryPayment_EmployeeId",
                table: "SalaryPayments",
                newName: "IX_SalaryPayments_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_SalaryCalculator_EmployeeId",
                table: "SalaryCalculators",
                newName: "IX_SalaryCalculators_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Permission_EmployeeId",
                table: "Permissions",
                newName: "IX_Permissions_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Material_EmployeeId",
                table: "Materials",
                newName: "IX_Materials_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Cost_EmployeeId",
                table: "Costs",
                newName: "IX_Costs_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalaryPayments",
                table: "SalaryPayments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalaryCalculators",
                table: "SalaryCalculators",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Materials",
                table: "Materials",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Costs",
                table: "Costs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Costs_Employee_EmployeeId",
                table: "Costs",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Employee_EmployeeId",
                table: "Materials",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Employee_EmployeeId",
                table: "Permissions",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalaryCalculators_Employee_EmployeeId",
                table: "SalaryCalculators",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalaryPayments_Employee_EmployeeId",
                table: "SalaryPayments",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
