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

        public DateTime PermitDate { get; set; }

        public int EmployeeId { get; set; }
    }
}
