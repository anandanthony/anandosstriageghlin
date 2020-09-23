using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ananddotnetlin.Models;

namespace ananddotnetlin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult handledException()
        {
            try
            {
                int i = 0;
                i = 5 / i;
                System.Diagnostics.Trace.WriteLine("Computed Value: " + i);
            }
            catch(DivideByZeroException ex)
            {
                ViewBag.rException = ex.Message;
                System.Diagnostics.Trace.WriteLine("Exception: " + ex.Message);
                System.Diagnostics.Trace.WriteLine("Stack Trace: " + ex.StackTrace);

                _logger.LogInformation("Exception from Logger: " + ex.Message);
                _logger.LogInformation("Stack Trace from Logger: " + ex.StackTrace);
            }
            return View("Index");
        }

        public IActionResult unhandledException()
        {
            _logger.LogInformation("inside unhandled exception");

            int i = 0;
            i = 5 / i;

            _logger.LogInformation("Executed divide by zero");

            System.Diagnostics.Trace.WriteLine("Computed Value: " + i);

            ViewBag.rException = "Can you reach me!";

            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
