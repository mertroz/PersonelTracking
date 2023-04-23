namespace PersonnelTrackingSystem.Domain
{
    public class SalaryPayment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public bool Paid { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

    }
}
