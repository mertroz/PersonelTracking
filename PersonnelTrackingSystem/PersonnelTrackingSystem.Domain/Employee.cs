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
        public int Identity { get; set; }
        public int RegistrationNumber { get; set; }
        public int MobilePhone { get; set; }
        public int HomePhone { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public DateTime HiringDate { get; set; }

    }
}
