namespace PersonnelTrackingSystem.WebApp.Models
{
    public class SalaryViewModel
    {
        public int Id { get; set; }
        public decimal Salary { get; set; }
        public decimal MealAllowance { get; set; }
        public decimal TransportationAllowance { get; set; }
        public decimal Bonus { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
}
