using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelTrackingSystem.Domain
{
    public class Permission
    {
        public int Id { get; set; }

        public DateTime PermitStartDate { get; set; }
        public DateTime PermitEndDate { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
