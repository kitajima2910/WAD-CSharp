using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab09.Models;
using Lab09.Services.Customers;
using Microsoft.AspNetCore.Mvc;

namespace Lab09.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerServices services;

        public CustomersController(ICustomerServices services)
        {
            this.services = services;
        }

        public IActionResult Index()
        {
            ViewBag.Customers = services.GetCustomers();

            return View();
        }

        public IActionResult _PVCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult _PVCreate(Customer customer)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    services.Create(customer);
                    return RedirectToAction("Index");
                }

                
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }
            return View();
        }
    }
}