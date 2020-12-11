using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab08.Models;
using Lab08.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace Lab08.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICityServices services;
        private readonly ICountryServices servicesCountries;

        public CitiesController(ICityServices services, ICountryServices servicesCountries)
        {
            this.services = services;
            this.servicesCountries = servicesCountries;
        }

        public IActionResult Index()
        {
            return View(services.GetCities());
        }

        public IActionResult Create()
        {
            
            var list = servicesCountries.GetCountries();
            ViewBag.Countries = new SelectList(list, "idCode", "countryName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(City city)
        {
            try
            {
                    services.CreateCity(city);
                    return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }

            return View();
        }
    }
}