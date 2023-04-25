namespace PersonnelTrackingSystem.WebApp.Models
{
    public class PermissionViewModel
    {
        public PermissionViewModel()
        {
            Employees = new List<EmployeeViewModel>();
        }
        public int Id { get; set; }
        public DateTime PermitDate { get; set; }
        public object EmployeeName { get; internal set; }
        public int EmployeeId { get; set; }
        public List<EmployeeViewModel> Employees { get; set; }
    }
}
