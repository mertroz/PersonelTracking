using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelTrackingSystem.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Identity { get; set; }
        public string RegistrationNumber { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public DateTime HiringDate { get; set; }
        public Gender Gender { get; set; }
    }
}
