using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelTrackingSystem.Domain
{
    public class SalaryCalculator
    {

        public int Id { get; set; }
        public decimal Salary { get; set; }
        public decimal MealAllowance { get; set; }
        public decimal TransportationAllowance { get; set; }
        public decimal Bonus { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

    }
}
