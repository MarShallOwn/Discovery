using Discovery.Core.Models;
using Discovery.DataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Discovery.WebUI.Controllers
{
    public class EmployerController : Controller
    {
        DataContext context = new DataContext();

        // GET: Employer
        public ActionResult Index()
        {
            List<Employee> e = context.Employees.ToList();

            return View(e);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee e)
        {
            context.Employees.Add(e);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Edit(string Id)
        {
            Employee e = context.Employees.Find(Id);

            if (e == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(e);
            }
        }

        [HttpPost]
        public ActionResult Edit(Employee e, string Id)
        {
            Employee eToEdit = context.Employees.Find(Id);

            if (eToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(e);
                }
                else
                {
                    eToEdit.FirstName = e.FirstName;
                    eToEdit.LastName = e.LastName;
                    eToEdit.Age = e.Age;
                    eToEdit.Street = e.Street;
                    eToEdit.Job = e.Job;
                    eToEdit.Salary = e.Salary;


                    context.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
        }

        public ActionResult Details(string Id)
        {
            Employee e = context.Employees.Find(Id);

            if (e == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(e);
            }
        }


        public ActionResult Delete(string Id)
        {
            Employee e = context.Employees.Find(Id);

            if (e == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(e);
            }

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Employee eToDelete = context.Employees.Find(Id);

            if (eToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Employees.Remove(eToDelete);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }

    }
}