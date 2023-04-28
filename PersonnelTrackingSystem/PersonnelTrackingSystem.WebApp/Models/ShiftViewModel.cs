namespace PersonnelTrackingSystem.WebApp.Models
{
    public class ShiftViewModel
    {
        public ShiftViewModel()
        {
            Employees = new List<EmployeeViewModel>();
        }
        public int Id { get; set; }

        public DateTime WorkingDate { get; set; }
        public DateTime WorkingTime { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public List<EmployeeViewModel> Employees { get; set; }

    }
}
