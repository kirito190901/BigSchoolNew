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
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            Model1 context = new Model1();
            var upcommingCourse = context.Courses.Where(p => p.DateTime >DateTime.Now).OrderBy(p => p.DateTime).ToList();
            ViewBag.LoginUser = User.Identity.GetUserId();
            var loginUser = User.Identity.GetUserId();
            ViewBag.LoginUser = loginUser;
            foreach (Course i in upcommingCourse)
            {
                ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager < ApplicationUserManager > ().FindById(i.LecturerId);
                i.Name = user.Name;
                Attendance find = context.Attendances.FirstOrDefault(p => p.CourseId == i.Id && p.Attendee == loginUser);
                if(find == null)
                {
                    i.isShowGoing = true;
                }
            }
            return View(upcommingCourse);
        }
    

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}