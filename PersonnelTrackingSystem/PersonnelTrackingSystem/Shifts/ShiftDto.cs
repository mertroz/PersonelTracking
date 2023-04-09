﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelTrackingSystem.Shifts
{
    public class ShiftDto
    {
        public int Id { get; set; }
        public DateTime WorkingDate { get; set; }
        public DateTime WorkingTime { get; set; }
        public int EmployeeId { get; set; }
    }
}
