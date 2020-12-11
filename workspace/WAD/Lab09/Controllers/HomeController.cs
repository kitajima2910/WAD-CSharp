using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lab09.Models;
using Lab09.Services.CustomerOrders;

namespace Lab09.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerOrderServices services;

        public HomeController(ILogger<HomeController> logger, ICustomerOrderServices services)
        {
            _logger = logger;
            this.services = services;
        }

        public IActionResult Index()
        {
            var customerOrdes = services.GetCustomerOrders();

            return View(customerOrdes);
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
