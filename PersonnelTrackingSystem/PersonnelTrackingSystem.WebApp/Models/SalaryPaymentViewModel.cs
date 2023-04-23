namespace PersonnelTrackingSystem.WebApp.Models
{
    public class SalaryPaymentViewModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public decimal Amount { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public bool Paid { get; set; }
        public string MonthName { get; internal set; }
    }
}
