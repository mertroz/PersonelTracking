namespace PersonnelTrackingSystem.WebApp.Models
{
    public class CostViewModel
    {
        public CostViewModel()
        {
            Employees = new List<EmployeeViewModel>();
        }
        public int Id { get; set; }

        public string CostType { get; set; }

        public decimal CostAmount { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public List<EmployeeViewModel> Employees { get; set; }
    }
}
