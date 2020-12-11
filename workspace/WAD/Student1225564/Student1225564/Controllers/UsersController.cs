using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student1225564.Models;

namespace Student1225564.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationContext context;

        public UsersController(ApplicationContext context)
        {
            this.context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            try
            {
                var oldUser = context.Users
                        .SingleOrDefault(u => u.Username.Equals(user.Username) && u.Password.Equals(user.Password));

                if (oldUser == null)
                {
                    ViewBag.Msg = "Please check username or password";
                }
                else
                {
                    if (oldUser.isAdmin)
                    {
                        return RedirectToAction("AddNew");
                    }
                    else
                    {
                        HttpContext.Session.SetString("isAdmin", oldUser.UserId.ToString());
                        return RedirectToAction("Profiles");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }

            return View();
        }

        public IActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNew(User user)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    ViewBag.Msg = "Successfuly!";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }

            return View();
        }

        public IActionResult Profiles()
        {
            var id = int.Parse(HttpContext.Session.GetString("isAdmin"));

            var user = context.Users.Find(id);

            return View(user);
        }
    }
}