using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelTrackingSystem.Permissions
{
    public class PermissionDto
    {
        public int Id { get; set; }

        public DateTime PermitStartDate { get; set; }
        public DateTime PermitEndDate { get; set; }

        public int EmployeeId { get; set; }
    }
}
