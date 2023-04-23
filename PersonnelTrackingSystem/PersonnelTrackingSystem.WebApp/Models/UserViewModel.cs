using PersonnelTrackingSystem.Employees;
using PersonnelTrackingSystem.Roles;

namespace PersonnelTrackingSystem.WebApp.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Employees = new List<EmployeeViewModel>();
            Roles = new List<RoleViewModel>();
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public int EmployeeId { get; set; }
        public int RoleId { get; set; }
        public string Password { get; set; }
        public List<EmployeeViewModel> Employees { get; set; }
        public List<RoleViewModel> Roles { get; set; }
        public object EmployeeName { get; internal set; }
        public object RoleName { get; internal set; }
    }
}
