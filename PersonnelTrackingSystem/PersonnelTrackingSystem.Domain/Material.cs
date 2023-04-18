using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelTrackingSystem.Domain
{
    public class Material
    {
        public int Id { get; set; }

        public string Request { get; set; }
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        
    }
}
