using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ScheduleWebApp.Controllers
{
    public class staffHoursWorkedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Week()
        {
            return View();
        }
        public IActionResult Month()
        {
            return View();
        }
        public IActionResult Individual()
        {
            return View();
        }
    }
}