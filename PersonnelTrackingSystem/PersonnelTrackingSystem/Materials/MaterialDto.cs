using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelTrackingSystem.Materials
{
    public class MaterialDto
    {
        public int Id { get; set; }

        public string Request { get; set; }
        public int EmployeeId { get; set; }
    }
}
