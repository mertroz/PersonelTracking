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
    public class SalaryCalculatorConfiguration : IEntityTypeConfiguration<SalaryCalculator>
    {
        public void Configure(EntityTypeBuilder<SalaryCalculator> builder)
        {
            throw new NotImplementedException();
        }
    }
}
