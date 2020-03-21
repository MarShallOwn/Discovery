using Discovery.Core.Models;
using Discovery.Core.VIewModels;
using Discovery.DataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Discovery.WebUI.Controllers
{
    public class UserController : Controller
    {
        DataContext context = new DataContext();

        // GET: User
        [Authorize]
        public ActionResult Index()
        {

            NurseryUser user = context.Users.FirstOrDefault(u => u.Email == User.Identity.Name);
            return View(user);
        }

        [HttpPost]
        public JsonResult getChild(string Password)
        {
            Child child = context.Children.FirstOrDefault(c => c.Password == Password);

            if(child == null)
            {
                return Json("Not Found", JsonRequestBehavior.AllowGet);
            }
            else
            {
                Teacher teacher = context.Teachers.FirstOrDefault(t => t.Id == child.TeacherId);


                if (teacher == null)
                {
                    teacher = new Teacher()
                    {
                        FirstName = "Not Found",
                        LastName = "Not Found",
                        Email = "Not Found",
                        PhoneNumber = "Not Found",
                        ClassRoom = "Not Found",
                    };
                }



                Parent parent = context.Parents.FirstOrDefault(p => p.ChildId == child.Id);

                if (parent == null)
                {
                    parent = new Parent();
                    parent.UserId = context.Users.FirstOrDefault(u => u.Email == User.Identity.Name).Id;
                    parent.ChildId = child.Id;
                    context.Parents.Add(parent);
                    context.SaveChanges();
                }

                TeacherChildViewModel viewModel = new TeacherChildViewModel()
                {
                    CFirstName = child.FirstName,
                    CLastName = child.LastName,
                    CAge = child.Age,
                    CDegree = child.Degree,
                    CClassRoom = child.ClassRoom,
                    CDisability_Type = child.Disability_Type,
                    CGrade = child.Grade,
                    TFirstName = teacher.FirstName,
                    TLastName = teacher.LastName,
                    TEmail = teacher.Email,
                    TPhoneNumber = teacher.PhoneNumber,
                };

                return Json(viewModel, JsonRequestBehavior.AllowGet);
            }

        }

    }
}