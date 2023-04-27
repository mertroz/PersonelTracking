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
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            {
                
                builder.ToTable("Permission");

                
                builder.HasKey(p => p.Id);

                
                builder.Property(p => p.PermitStartDate)
                    .IsRequired();

                builder.Property(p => p.PermitEndDate)
                    .IsRequired();

                builder.Property(p => p.EmployeeId)
                    .IsRequired();

               
                builder.HasOne(p => p.Employee)
                    .WithMany()
                    .HasForeignKey(p => p.EmployeeId);

                
            }
        }
    }
}
