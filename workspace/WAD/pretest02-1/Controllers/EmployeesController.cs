using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using pretest02_1.Models;

namespace pretest02_1.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationContext context;

        public EmployeesController(ApplicationContext context)
        {
            this.context = context;
        }

        public IActionResult ViewEmployeeList(string keyword)
        {
            var infoAccount = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("infoAccount"));

            var employees = context.Employees.ToList();

            if(!String.IsNullOrWhiteSpace(keyword))
            {
                employees = context.Employees.Where(e => e.EmpName.Contains(keyword)).ToList();
            }

            ViewBag.Info = infoAccount.username;
            ViewBag.Employees = new SelectList(context.Employees.ToList(), "EmpName", "EmpName");
            return View(employees);
        }

        public IActionResult EditOrDeleteEmployee(int id)
        {
            var employee = context.Employees.Find(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult EditOrDeleteEmployee(string submit, Employee employee)
        {
            try
            {
                if(submit.Equals("update"))
                {
                    if(ModelState.IsValid)
                    {
                        context.Update(employee);
                        context.SaveChanges();

                        ViewBag.Msg = "Employee updated successfuly.";
                    }
                }
                else
                {
                    context.Employees.Remove(employee);
                    context.SaveChanges();

                    return RedirectToAction("ViewEmployeeList");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }

            return View();
        }

        public IActionResult AddNewEmployee()
        {
            var infoAccount = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("infoAccount"));
            ViewBag.Info = infoAccount.username;
            return View();
        }

        [HttpPost]
        public IActionResult AddNewEmployee(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var oldEmployee = context.Employees.SingleOrDefault(e => e.EmpID == employee.EmpID);
                    if(oldEmployee == null)
                    {
                        context.Employees.Add(employee);
                        context.SaveChanges();

                        ViewBag.Msg = "Employee created successfuly.";
                    }
                    else
                    {
                        ViewBag.Msg = "Had id...";
                    }
                    
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