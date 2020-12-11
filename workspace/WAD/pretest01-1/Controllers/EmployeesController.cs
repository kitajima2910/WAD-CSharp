using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pretest01_1.Models;
using pretest01_1.Repositories;

namespace pretest01_1.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationContext context;

        public EmployeesController(ApplicationContext context)
        {
            this.context = context;
        }

        public IActionResult ViewEmployeeList()
        {
            var employees = context.Employees.ToList();

            return View(employees);
        }


        public IActionResult EmployeeDetail(int id)
        {
            var employee = context.Employees.Find(id);

            return View(employee);
        }

        public IActionResult Delete(int id)
        {
            var employee = context.Employees.Find(id);
            context.Employees.Remove(employee);
            context.SaveChanges();

            return RedirectToAction("ViewEmployeeList");
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
                    context.Employees.Add(employee);
                    context.SaveChanges();

                    ViewBag.Msg = "Successfuly!";
                }
                else
                {
                    ViewBag.Msg = "Fail!!!";
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