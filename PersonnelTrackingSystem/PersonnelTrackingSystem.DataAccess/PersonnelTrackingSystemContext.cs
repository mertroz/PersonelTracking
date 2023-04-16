﻿using Microsoft.EntityFrameworkCore;
using PersonnelTrackingSystem.DataAccess.Configuration;
using PersonnelTrackingSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelTrackingSystem.DataAccess
{
    public class PersonnelTrackingSystemContext: DbContext
    {
        private const string ConnectionString =
            "Server=DESKTOP-7LSJ7BF\\SRVMERT;Database=PersonnelTrackingSystem;Integrated Security=true; TrustServerCertificate=True";

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<SalaryCalculator> SalaryCalculators { get; set; }
        public DbSet<SalaryPayment> SalaryPayments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new ShiftConfiguration());
            modelBuilder.ApplyConfiguration(new SalaryCalculatorConfiguration());
            modelBuilder.ApplyConfiguration(new SalaryPaymentConfiguration());
          

        }
    }
}
