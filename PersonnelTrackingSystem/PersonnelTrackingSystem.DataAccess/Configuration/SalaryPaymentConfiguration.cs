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
    public class SalaryPaymentConfiguration : IEntityTypeConfiguration<SalaryPayment>
    {
        public void Configure(EntityTypeBuilder<SalaryPayment> builder)
        {
            builder
            .HasKey(s => s.Id);

            builder
            .HasKey(e => e.Id);

            builder
                .HasOne(s => s.Employee)
                .WithMany()
                .HasForeignKey(s => s.EmployeeId);
        }
    }
}
