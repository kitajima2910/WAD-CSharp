using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab03.Models;
using Lab03.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab03.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService service; // DI

        public AccountController(IAccountService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            ViewBag.InfoAccount = HttpContext.Session.GetString("InfoAccount");
            
            var accounts = service.GetAccounts();
            ViewBag.Data = accounts;
            //return View(accounts);
            return View();
        }

        public IActionResult Details(string accountNo)
        {
            Account account = service.FindByAccountNo(accountNo);
            return View(account);
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string accountNo, string pinCode)
        {
            try
            {
                Account account = service.CheckLoginV2(accountNo, pinCode);

                if(account != null)
                {
                    if(account.IsAdmin)
                    {
                        HttpContext.Session.SetString("InfoAccount", accountNo);
                        return RedirectToAction("Index");
                    }
                }

                ViewBag.Msg = "Invalid account no and pin code...";
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }

            return View();
        }


    }
}