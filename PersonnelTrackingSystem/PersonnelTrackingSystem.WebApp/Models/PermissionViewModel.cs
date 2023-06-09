﻿namespace PersonnelTrackingSystem.WebApp.Models
{
    public class PermissionViewModel
    {
        public PermissionViewModel()
        {
            Employees = new List<EmployeeViewModel>();
        }
        public int Id { get; set; }
        public DateTime PermitStartDate { get; set; }
        public DateTime PermitEndDate { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeId { get; set; }
        public List<EmployeeViewModel> Employees { get; set; }
    }
}
