using DotNetCoreTraversal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreTraversal.Controllers
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
            var date = DateTime.Now;
            _logger.LogInformation("Index page called at " + date + ".");
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("Privacy page called.");
            _logger.LogError("This a test error log.");
            return View();
        }

        public IActionResult LogTest()
        {
            _logger.LogInformation("LogTest page called.");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
