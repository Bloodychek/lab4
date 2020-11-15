﻿using System;
using System.Collections.Generic;

namespace lab3
{
    public partial class Staff
    {
        public Staff()
        {
            IncomeAndExpensesOfGsm = new HashSet<IncomeAndExpensesOfGsm>();
        }

        public int StaffId { get; set; }
        public string FullName { get; set; }
        public int? StaffAge { get; set; }
        public string StaffFunction { get; set; }
        public DateTime? WorkingHoursForAweek { get; set; }

        public virtual ICollection<IncomeAndExpensesOfGsm> IncomeAndExpensesOfGsm { get; set; }
    }
}
