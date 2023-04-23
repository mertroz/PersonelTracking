using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonnelTrackingSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelTrackingSystem.DataAccess.Configuration
{
    public class CostConfiguration : IEntityTypeConfiguration<Cost>
    {
        public void Configure(EntityTypeBuilder<Cost> builder)
        {
            builder.ToTable("Cost");

            
            builder.HasKey(c => c.Id);

           
            builder.Property(c => c.CostType)
                .IsRequired();

            
            builder.Property(c => c.CostAmount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            
            builder.Property(c => c.EmployeeId)
                .IsRequired();

           
            builder.HasOne(c => c.Employee)
                .WithMany()
                .HasForeignKey(c => c.EmployeeId);
        }
    }
}
