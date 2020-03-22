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
        public ActionResult Index(string sortOrder)
        {

            ViewBag.name = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.lastName = sortOrder == "LastN" ? "LastN_desc" : "LastN";
            ViewBag.age = sortOrder == "Age" ? "Age_desc" : "Age";
            ViewBag.grade = sortOrder == "Grade" ? "Grade_desc" : "Grade";
            ViewBag.disability_type = sortOrder == "Disability_Type" ? "Disability_Type_desc" : "Disability_Type";
            ViewBag.classroom = sortOrder == "Classroom" ? "Classroom_desc" : "Classroom";

            List<Child> children = context.Children.ToList();

            switch (sortOrder)
            {
                case "name_desc":
                    children = children.OrderByDescending(c => c.FirstName).ToList();
                    break;
                case "LastN":
                    children = children.OrderBy(c => c.LastName).ToList();
                    break;
                case "LastN_desc":
                    children = children.OrderByDescending(c => c.LastName).ToList();
                    break;
                case "Age":
                    children = children.OrderBy(c => c.Age).ToList();
                    break;
                case "Age_desc":
                    children = children.OrderByDescending(c => c.Age).ToList();
                    break;
                case "Grade":
                    children = children.OrderBy(c => c.Grade).ToList();
                    break;
                case "Grade_desc":
                    children = children.OrderByDescending(c => c.Grade).ToList();
                    break;
                case "Disability_Type":
                    children = children.OrderBy(c => c.Disability_Type).ToList();
                    break;
                case "Disability_Type_desc":
                    children = children.OrderByDescending(c => c.Disability_Type).ToList();
                    break;
                case "Classroom":
                    children = children.OrderBy(c => c.ClassRoom).ToList();
                    break;
                case "Classroom_desc":
                    children = children.OrderByDescending(c => c.ClassRoom).ToList();
                    break;
                default:
                    children = children.OrderBy(c => c.FirstName).ToList();
                    break;
            }

            return View(children);
        }


        [HttpPost]
        public JsonResult doSearch(string Search, string Option)
        {

            List<Child> children;
            switch (Option)
            {
                case "option2":
                    children = context.Children.Where(c => c.LastName.StartsWith(Search)).ToList();
                    break;
                case "option3":
                    children = context.Children.Where(c => c.Disability_Type.StartsWith(Search)).ToList();
                    break;
                default:
                    children = context.Children.Where(c => c.FirstName.StartsWith(Search)).ToList();
                    break;
            }

            return Json(children, JsonRequestBehavior.AllowGet);
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
                Parent parent = new Parent();
                parent.ChildId = c.Id;

                context.Parents.Add(parent);
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
                    cToEdit.Grade = c.Grade;
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
                Parent pToDelete = context.Parents.FirstOrDefault(p => p.ChildId == cToDelete.Id);
                context.Children.Remove(cToDelete);
                if(pToDelete != null)
                {
                    context.Parents.Remove(pToDelete);
                }

                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }

    }
}