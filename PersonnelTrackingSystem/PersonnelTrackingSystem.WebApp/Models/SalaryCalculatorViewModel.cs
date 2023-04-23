namespace PersonnelTrackingSystem.WebApp.Models
{
    public class SalaryCalculatorViewModel
    {
        public int Id { get; set; }
        public decimal Salary { get; set; }
        public decimal MealAllowance { get; set; }
        public decimal TransportationAllowance { get; set; }
        public decimal Bonus { get; set; }
        public int EmployeeId { get; set; }
        public List<EmployeeViewModel> Employees { get; set; }
    }
}
