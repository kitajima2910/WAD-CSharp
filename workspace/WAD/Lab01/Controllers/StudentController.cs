using Lab01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Lab01.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext context = new StudentContext();

        //[HttpGet]
        //public ActionResult Index()
        //{
        //    //var result = context.Students.ToList();
        //    var result = context.Students
        //        .Select(s => s).ToList();
        //    return View(result);
        //}

        [HttpGet]
        public ActionResult Index(string sortOrder, string keyword)
        {
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var result = context.Students
                .Select(s => s);

            if (!String.IsNullOrEmpty(keyword))
            {
                result = context.Students
                .Where(s => s.StudentId.Contains(keyword) ||
                            s.StudentName.Contains(keyword) ||
                            s.Address.Contains(keyword));
            }

            switch (sortOrder)
            {
                case "Date":
                    result = context.Students.OrderBy(s => s.JoinDate);
                    break;
                case "date_desc":
                    result = context.Students.OrderByDescending(s => s.JoinDate);
                    break;
            }


            return View(result.ToList());

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                var oldStudent = context.Students
                    .SingleOrDefault(s => student.StudentId.Equals(s.StudentId));

                if(oldStudent == null && ModelState.IsValid)
                {
                    context.Students.Add(student);
                    context.SaveChanges();
                    return RedirectToAction("Index", "Student");
                }
                else
                {
                    ViewBag.Msg = "Has existed...";
                }

            }
            catch (System.Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var oldStudent = context.Students
                    .SingleOrDefault(s => id.Equals(s.StudentId));

            return View(oldStudent);
        }


        [HttpPost]
        public ActionResult Edit(Student student)
        {
            try
            {
                var oldStudent = context.Students
                    .SingleOrDefault(s => student.StudentId.Equals(s.StudentId));

                if (oldStudent != null && ModelState.IsValid)
                {
                    oldStudent.StudentName = student.StudentName;
                    oldStudent.Address = student.Address;
                    oldStudent.JoinDate = student.JoinDate;
                    context.SaveChanges();
                    return RedirectToAction("Index", "Student");
                }
                else
                {
                    ViewBag.Msg = "Has not exist...";
                }

                
            }
            catch (System.Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }

            return View();
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            try
            {
                var oldStudent = context.Students.SingleOrDefault(s => id.Equals(s.StudentId));
                if(oldStudent != null)
                {
                    context.Students.Remove(oldStudent);
                    context.SaveChanges();
                    return RedirectToAction("Index", "Student");
                }
                else
                {
                    ViewBag.Msg = "Has not exist...";
                }

                
            }
            catch (System.Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }

            return View();
        }

    }
}