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
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();

            builder.Property(x => x.FirstName).HasColumnName("FirstName").IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).HasColumnName("LastName").IsRequired().HasMaxLength(50);

            builder.Property(x => x.Identity).HasColumnName("Identity").IsRequired().HasMaxLength(11).IsUnicode(false);
            builder.Property(x => x.RegistrationNumber).HasColumnName("RegistrationNumber").IsRequired().HasMaxLength(50);

            builder.Property(x => x.MobilePhone).HasColumnName("MobilePhone").HasMaxLength(20);
            builder.Property(x => x.HomePhone).HasColumnName("HomePhone").HasMaxLength(20);
            builder.Property(x => x.Address).HasColumnName("Address").HasMaxLength(250);

            builder.Property(x => x.Department).HasColumnName("Department").HasMaxLength(50);
            builder.Property(x => x.HiringDate).HasColumnName("HiringDate").IsRequired();

            builder.Property(x => x.Gender).HasColumnName("Gender").IsRequired().HasColumnType("tinyint");

        }
    }

}
