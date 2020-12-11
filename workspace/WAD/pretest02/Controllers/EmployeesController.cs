using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pretest02.Models;
using pretest02.Repositories;
using pretest02.Services;

namespace pretest02.Controllers
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

        public IActionResult AddNewEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewEmployee(Employees employees)
        {

            try
            {
                if(ModelState.IsValid)
                {
                    var employee = context.Employees.SingleOrDefault(e => e.EmpID == employees.EmpID);

                    if(employee == null)
                    {
                        context.Employees.Add(employees);
                        context.SaveChanges();

                        ViewBag.Msg = "Employee added successful.";
                    }
                    else
                    {
                        ViewBag.Msg = "Had empID " + employees.EmpID;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }

            return View();
        }

        public IActionResult EditOrDeleteEmployees(int? empID)
        {
            if(empID == null)
            {
                return NotFound();
            }

            var employee = context.Employees.SingleOrDefault(e => e.EmpID == empID);

            if(employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        public IActionResult EditOrDeleteEmployees(Employees employees)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    context.Update(employees);
                    context.SaveChanges();
                    ViewBag.Msg = "Employee updated successful";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }

            return View();
        }

        public IActionResult Delete(int? empID)
        {
            var employee = context.Employees.SingleOrDefault(e => e.EmpID == empID);

            if (employee != null)
            {
                context.Remove(employee);
                context.SaveChanges();
                return RedirectToAction("ViewEmployeeList");
            }

            return View();
            
        }


    }
}