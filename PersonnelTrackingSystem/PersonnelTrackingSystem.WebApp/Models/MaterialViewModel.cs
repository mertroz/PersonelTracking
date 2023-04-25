namespace PersonnelTrackingSystem.WebApp.Models
{
    public class MaterialViewModel
    {
        public MaterialViewModel()
        {
            Employees = new List<EmployeeViewModel>();
        }
        public int Id { get; set; }

        public string Request { get; set; }
        public object EmployeeName { get; internal set; }
        public int EmployeeId { get; set; }
        public List<EmployeeViewModel> Employees { get; set; }


    }
}
