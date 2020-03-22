using Discovery.Core.Models;
using Discovery.DataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Discovery.WebUI.Controllers
{
    public class TeacherController : Controller
    {
        DataContext context = new DataContext();

        // GET: Teacher

        public ActionResult Index()
        {
            List<Teacher> Teachers = context.Teachers.ToList();
            return View(Teachers);
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
                context.Teachers.Remove(t);
                context.SaveChanges();

                return RedirectToAction("Index");

            }
        }
    }
}