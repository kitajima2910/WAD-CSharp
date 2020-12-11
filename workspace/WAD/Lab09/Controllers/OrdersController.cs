using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab09.Services.Orders;
using Microsoft.AspNetCore.Mvc;

namespace Lab09.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderServices services;

        public OrdersController(IOrderServices services)
        {
            this.services = services;
        }

        public IActionResult Index()
        {
            var orders = services.GetOrders();

            return View(orders);
        }
    }
}