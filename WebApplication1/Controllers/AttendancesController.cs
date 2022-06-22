using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AttendancesController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Attend(Course courseDTO)
        {
            //doi tuong obj.Id 


            //lay ra userlogin 
            var user = User.Identity.GetUserId(); //doan nay co nghia c5ca64d2-3217-4b35-bd07-6b96d1a02c85
            if( user == null)
            {
                return BadRequest("Please login first!");
            }

            Attendance newAtt = new Attendance()
            { CourseId = courseDTO.Id, Attendee = user };

            //insert vao bang attentd 
            Model1 context = new Model1();
            context.Attendances.Add(newAtt);

            context.SaveChanges(); //luu db


            return Ok(); 
        }
    }
}
