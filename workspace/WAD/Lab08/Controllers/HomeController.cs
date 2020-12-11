using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lab08.Models;
using Lab08.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab08.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICountryCityServices services;
        private readonly ICountryServices servicesCountry;

        public HomeController(ILogger<HomeController> logger, ICountryCityServices services,
            ICountryServices servicesCountry)
        {
            _logger = logger;
            this.services = services;
            this.servicesCountry = servicesCountry;
        }

        public IActionResult Index(string keyword)
        {
            var results = services.GetCountryCities();

            if(!String.IsNullOrWhiteSpace(keyword))
            {
                results = services.GetCountryCities(keyword);
            }

            ViewBag.Countries = new SelectList(servicesCountry.GetCountries(), "idCode", "countryName");
            return View(results);
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
