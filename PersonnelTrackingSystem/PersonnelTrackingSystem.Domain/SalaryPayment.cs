namespace PersonnelTrackingSystem.Domain
{
    public class SalaryPayment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public bool Paid { get; set; }
        public int EmployeeId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public Employee Employee { get; set; }

    }
}
