using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelTrackingSystem.Domain
{
    public class Cost
    {
        public int Id { get; set; }

        public string CostType { get; set; }

        public decimal CostAmount { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
