using lab3;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4.Controllers
{
    public class IncomeAndExpensesOfGsmController : Controller
    {
        Petrol_StationContext context;
        public IncomeAndExpensesOfGsmController (Petrol_StationContext context)
        {
            this.context = context;
        }
        [ResponseCache(Duration = (250))]
        public IActionResult ShowTable()
        {
            var result = context.IncomeAndExpensesOfGsm.Include(c => c.Staff).Take(20);
            return View(context.IncomeAndExpensesOfGsm.ToList());
        }
    }
}
