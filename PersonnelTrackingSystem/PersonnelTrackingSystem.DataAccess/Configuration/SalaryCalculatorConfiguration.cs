using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonnelTrackingSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelTrackingSystem.DataAccess.Configuration
{
    public class SalaryCalculatorConfiguration : IEntityTypeConfiguration<SalaryCalculator>
    {
        public void Configure(EntityTypeBuilder<SalaryCalculator> builder)
        {
            builder
            .ToTable("SalaryCalculators");

            builder
            .HasKey(s => s.Id);

            builder
                .Property(s => s.Salary)
                .HasColumnName("Salary")
                .HasColumnType("decimal(18, 2)");

            builder
                .Property(s => s.MealAllowance)
                .HasColumnName("MealAllowance")
                .HasColumnType("decimal(18, 2)");

            builder
                .Property(s => s.TransportationAllowance)
                .HasColumnName("TransportationAllowance")
                .HasColumnType("decimal(18, 2)");

            builder
                .Property(s => s.Bonus)
                .HasColumnName("Bonus")
                .HasColumnType("decimal(18, 2)");

            builder
                .Property(s => s.EmployeeId)
                .HasColumnName("EmployeeId");

            builder
                .HasOne(s => s.Employee)
                .WithMany()
                .HasForeignKey(s => s.EmployeeId);
        }
    }
}
