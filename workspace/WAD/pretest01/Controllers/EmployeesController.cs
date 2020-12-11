using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pretest01.Models;
using pretest01.Services;

namespace pretest01.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeServices services;

        public EmployeesController(IEmployeeServices services)
        {
            this.services = services;
        }

        public IActionResult ViewEmployeeList()
        {
            var employees = services.GetEmployees();
            return View(employees);
        }

        public IActionResult AddNewEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewEmployee(Employee employee)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    services.Create(employee);
                }
                
            }
            catch (Exception)
            {
                ViewBag.Msg = "Error add new employee";
            }

            return View();
        }

        public IActionResult EmployeeDetails(int id)
        {
            var employee = services.GetEmployee(id);
            return View(employee);
        }

        public IActionResult Delete(int id)
        {
            services.Delete(id);
            return RedirectToAction("ViewEmployeeList");
        }

    }
}