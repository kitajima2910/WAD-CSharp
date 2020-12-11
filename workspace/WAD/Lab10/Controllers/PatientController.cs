using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab10.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Lab10.Controllers
{
    public class PatientController : Controller
    {
        private readonly ApplicationContext context;

        public PatientController(ApplicationContext context)
        {
            this.context = context;
        }

        public IActionResult Index(string keyword, int? page)
        {
            int max = 2;
            int numpage = page ?? 1;

            var patients = context.Patients.ToList().ToPagedList(numpage, max);

            if (!String.IsNullOrWhiteSpace(keyword))
            {
                patients = context.Patients.Where(p => p.pathological.Contains(keyword)).ToList().ToPagedList(numpage, max);
            }

            ViewBag.Data = patients;

            return View();
        }

        public IActionResult UpdateOrDelete(int id)
        {
            var patient = context.Patients.SingleOrDefault(p => p.id == id);
            return View(patient);
        }

        [HttpPost]
        public IActionResult UpdateOrDelete(string submit, Patient patient)
        {
            try
            {
                if(submit.Equals("update"))
                {
                    if (ModelState.IsValid)
                    {
                        context.Update(patient);
                        context.SaveChanges();

                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    context.Patients.Remove(patient);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                    
                
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var patient = context.Patients.Find(id);
                context.Patients.Remove(patient);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Patients.Add(patient);
                    context.SaveChanges();

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