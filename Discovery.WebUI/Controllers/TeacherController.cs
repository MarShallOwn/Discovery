using Discovery.Core.Models;
using Discovery.DataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Discovery.WebUI.Controllers
{
    [Authorize]
    public class TeacherController : Controller
    {
        DataContext context = new DataContext();

        // GET: Teacher

        public ActionResult Index(string sortOrder)
        {

            ViewBag.name = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.lastName = sortOrder == "LastN" ? "LastN_desc" : "LastN";
            ViewBag.email = sortOrder == "Email" ? "Email_desc" : "Email";
            ViewBag.classroom = sortOrder == "Classroom" ? "Classroom_desc" : "Classroom";

            List<Teacher> teachers = context.Teachers.ToList();

            switch (sortOrder)
            {
                case "name_desc":
                    teachers = teachers.OrderByDescending(t => t.FirstName).ToList();
                    break;
                case "LastN":
                    teachers = teachers.OrderBy(t => t.LastName).ToList();
                    break;
                case "LastN_desc":
                    teachers = teachers.OrderByDescending(t => t.LastName).ToList();
                    break;
                case "Email":
                    teachers = teachers.OrderBy(t => t.Email).ToList();
                    break;
                case "Email_desc":
                    teachers = teachers.OrderByDescending(t => t.Email).ToList();
                    break;
                case "Classroom":
                    teachers = teachers.OrderBy(t => t.ClassRoom).ToList();
                    break;
                case "Classroom_desc":
                    teachers = teachers.OrderByDescending(t => t.ClassRoom).ToList();
                    break;
                default:
                    teachers = teachers.OrderBy(t => t.FirstName).ToList();
                    break;
            }

            return View(teachers);
        }


        [HttpPost]
        public JsonResult doSearch(string Search, string Option)
        {

            List<Teacher> teachers;
            switch (Option)
            {
                case "option2":
                    teachers = context.Teachers.Where(t => t.LastName.StartsWith(Search)).ToList();
                    break;
                case "option3":
                    teachers = context.Teachers.Where(t => t.Email.StartsWith(Search)).ToList();
                    break;
                case "option4":
                    teachers = context.Teachers.Where(t => t.PhoneNumber.StartsWith(Search)).ToList();
                    break;
                default:
                    teachers = context.Teachers.Where(t => t.FirstName.StartsWith(Search)).ToList();
                    break;
            }

            return Json(teachers, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            Teacher t = new Teacher();
            return View(t);
        }
        [HttpPost]
        public ActionResult Create(Teacher t)
        {
            if (!ModelState.IsValid)
            {
                return View(t);

            }
            else
            {

                List<Child> children = context.Children.Where(c => c.ClassRoom == t.ClassRoom).ToList();

                foreach(Child child in children)
                {
                    child.TeacherId = t.Id;
                }

                context.Teachers.Add(t);
                context.SaveChanges();
                return RedirectToAction("index");
            }

        }
        [HttpGet]
        public ActionResult Edit(string Id)
        {
            Teacher t = context.Teachers.Find(Id);
            if (t == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(t);
            }
        }
        [HttpPost]
        public ActionResult Edit(Teacher t, string Id)
        {
            Teacher te = context.Teachers.Find(Id);
            if (te == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(t);

                }
                else
                {
                    te.FirstName = t.FirstName;
                    te.LastName = t.LastName;
                    te.PhoneNumber = t.PhoneNumber;
                    te.Email = t.Email;
                    te.ClassRoom = t.ClassRoom;

                    List<Child> children = context.Children.Where(c => c.ClassRoom == t.ClassRoom).ToList();
                    List<Child> childrenRemove = context.Children.Where(c => c.TeacherId == t.Id).ToList();

                    foreach(Child childRemove in childrenRemove)
                    {
                        childRemove.TeacherId = null;
                    }

                    foreach (Child child in children)
                    {
                        child.TeacherId = t.Id;
                    }

                    context.SaveChanges();

                    return RedirectToAction("Index");

                }


            }

        }
        public ActionResult Details(string Id)
        {
            Teacher t = context.Teachers.Find(Id);
            if (t == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(t);
            }
        }
        [HttpGet]
        public ActionResult Delete(string Id)
        {
            Teacher t = context.Teachers.Find(Id);
            if (t == null)
            {
                return HttpNotFound();

            }
            else
            {
                return View(t);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult cDelete(string Id)
        {
            Teacher t = context.Teachers.Find(Id);
            if (t == null)
            {
                return HttpNotFound();
            }
            else
            {
                List<Child> children = context.Children.Where(c => c.ClassRoom == t.ClassRoom).ToList();

                foreach (Child child in children)
                {
                    child.TeacherId = null;
                }


                context.Teachers.Remove(t);
                context.SaveChanges();

                return RedirectToAction("Index");

            }
        }
    }
}