using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using pretest02_1.Models;

namespace pretest02_1.Controllers
{
    public class AccountsController : Controller
    {
        private readonly ApplicationContext context;

        public AccountsController(ApplicationContext context)
        {
            this.context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Account account)
        {
            try
            {
                var oldAccount = context.Accounts
                    .SingleOrDefault(a => a.username.Equals(account.username) && a.password.Equals(account.password));
            
                if(oldAccount == null)
                {
                    ViewBag.Msg = "Please check username or password";
                }
                else
                {
                    if(oldAccount.role)
                    {
                        HttpContext.Session.SetString("infoAccount", JsonConvert.SerializeObject(oldAccount));
                        return RedirectToAction("ViewEmployeeList", "Employees");
                    }
                    else
                    {
                        HttpContext.Session.SetString("infoAccount", JsonConvert.SerializeObject(oldAccount));
                        return RedirectToAction("AddNewEmployee", "Employees");
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