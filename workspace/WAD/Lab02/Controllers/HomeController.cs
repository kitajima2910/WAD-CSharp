using Lab02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab02.Controllers
{
    public class HomeController : Controller
    {

        private readonly CourseContext context = new CourseContext();

        // GET: Home
        public ActionResult Index(string search, decimal? fromValue, decimal? toValue)
        {


            var model = context.Courses.Select(c => c);

            if(!string.IsNullOrEmpty(search))
            {
                model = context.Courses.Where(c => c.CourseName.Contains(search));
            }

            if(fromValue != null && toValue != null)
            {
                
                model = context.Courses.Where(c => fromValue <= c.Fee && c.Fee <= toValue);
            }

            return View(model.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Course course)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    context.Courses.Add(course);
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

        public ActionResult Update(int id)
        {
            var oblCourse = context.Courses.SingleOrDefault(c => c.Id == id);
            return View(oblCourse);
        }

        [HttpPost]
        public ActionResult Update(Course course)
        {
            try
            {
                var oldCourse = context.Courses.SingleOrDefault(c => c.Id == course.Id);
                if(oldCourse != null)
                {
                    oldCourse.CourseName = course.CourseName;
                    oldCourse.Duration = course.Duration;
                    oldCourse.Fee = course.Fee;
                }

                context.SaveChanges();
                return RedirectToAction("Index", "Home");

            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }
            return View();

        }

        [HttpGet]
        public ActionResult Delete(int[] cbDelete)
        {
            try
            {
                if(cbDelete == null && cbDelete.Length == 0)
                {
                    return RedirectToAction("Index", "Home");
                }

                foreach(var item in cbDelete)
                {
                    var course = context.Courses.SingleOrDefault(c => c.Id == item );
                    if (course != null)
                    {
                        context.Courses.Remove(course);
                    }
                }
                context.SaveChanges();

                return RedirectToAction("Index", "Home");

            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }

            return View();
        }

    }
}