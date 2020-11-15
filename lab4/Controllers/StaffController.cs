using lab3;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4.Controllers
{
    public class StaffController: Controller
    {
        Petrol_StationContext context;

        public StaffController (Petrol_StationContext context)
        {
            this.context = context;
        }
        [ResponseCache(Duration = 250)]
        public IActionResult ShowTable()
        {
            return View(context.Staff);
        }
    }
}
