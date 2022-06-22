using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CourseController : Controller
    {


        // GET: Course
        public ActionResult Create()
        {
            Model1 context = new Model1();
            Course C = new Course();
            C.DateTime = DateTime.Now;
            C.ListCategory = context.Categories.ToList();
            return View(C);
        }
        [Authorize] 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            Model1 context = new Model1();

            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            course.LecturerId = user.Id;


            ModelState.Remove("LecturerId"); //sua lai 
            if (!ModelState.IsValid)
            {
                course.ListCategory = context.Categories.ToList();
                return View("Create", course);
            }
            context.Courses.Add(course);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }

}