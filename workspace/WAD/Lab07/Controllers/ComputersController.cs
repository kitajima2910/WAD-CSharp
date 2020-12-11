using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lab07.Models;
using Lab07.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab07.Controllers
{
    public class ComputersController : Controller
    {
        private readonly IComputerService _service;

        public ComputersController(IComputerService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var computers = _service.GetComputers();

            return View(computers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Computer computer, IFormFile file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (file.Length > 0)
                    {
                        var path = Path.Combine("wwwroot/images", file.FileName);
                        var stream = new FileStream(path, FileMode.Create);
                        file.CopyToAsync(stream);
                        computer.Photo = "images/" + file.FileName;
                        _service.Create(computer);

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Msg = "Fail...";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }

            return View();
        }

        public IActionResult Edit(int id)
        {
            var computer = _service.GetComputer(id);
            return View(computer);
        }

        [HttpPost]
        public IActionResult Edit(Computer computer, IFormFile file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (file.Length > 0)
                    {
                        var path = Path.Combine("wwwroot/images", file.FileName);
                        var stream = new FileStream(path, FileMode.Create);
                        file.CopyToAsync(stream);
                        computer.Photo = "images/" + file.FileName;
                        _service.Edit(computer);

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Msg = "Fail...";
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