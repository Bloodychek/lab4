using lab3;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4.Controllers
{
    public class GsmController: Controller
    {
        Petrol_StationContext context;
        public GsmController(Petrol_StationContext context)
        {
            this.context = context;
        }
        [ResponseCache(Duration = 250)]
        public IActionResult ShowTable()
        {
            var c = context.Gsm.Take(20);
            return View(c);
        }
    }
}
