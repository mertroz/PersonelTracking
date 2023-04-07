using Microsoft.EntityFrameworkCore;
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
            "Server=.;Database=McTours;Integrated Security=true";

        public DbSet<Employee> Employees { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // buraları doldur
        }
    }
}
