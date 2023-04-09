using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelTrackingSystem.Domain
{
    public class Shift
    {
        public int Id { get; set; }
        public DateTime WorkingDate { get; set; }
        public DateTime WorkingTime { get; set; }
        public int EmployeeId { get; set; } 
        public Employee Employee { get; set; }
        
    }
}
