using Discovery.Core.Models;
using Discovery.DataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Discovery.WebUI.Controllers
{
    public class ChildController : Controller
    {

        DataContext context = new DataContext();

        // GET: Child
        public ActionResult Index()
        {
            List<Child> children = context.Children.ToList();
            
            return View(children);
        }

        public ActionResult Create()
        {
            Child c = new Child();

            return View(c);
        }

        [HttpPost]
        public ActionResult Create(Child c)
        {
            if (!ModelState.IsValid)
            {
                return View(c);
            }
            else
            {
                context.Children.Add(c);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Child c = context.Children.Find(Id);

            if(c == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(c);
            }
        }

        [HttpPost]
        public ActionResult Edit(Child c,string Id)
        {
            Child cToEdit = context.Children.Find(Id);

            if(cToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(c);
                }
                else
                {
                    cToEdit.FirstName = c.FirstName;
                    cToEdit.LastName = c.LastName;
                    cToEdit.Age = c.Age;
                    cToEdit.TeacherId = c.TeacherId;
                    cToEdit.ClassRoom = c.ClassRoom;
                    cToEdit.Degree = c.Degree;
                    cToEdit.Disability_Type = c.Disability_Type;

                    context.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
        }

        public ActionResult Details(string Id)
        {
            Child c = context.Children.Find(Id);

            if(c == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(c);
            }
        }


        public ActionResult Delete(string Id)
        {
            Child c = context.Children.Find(Id);

            if(c == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(c);
            }

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Child cToDelete = context.Children.Find(Id);

            if(cToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Children.Remove(cToDelete);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }

    }
}