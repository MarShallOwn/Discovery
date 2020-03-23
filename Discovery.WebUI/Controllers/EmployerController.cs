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
    public class EmployerController : Controller
    {
        DataContext context = new DataContext();

        // GET: Employer
        public ActionResult Index(string sortOrder)
        {

            ViewBag.name = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.lastName = sortOrder == "LastN" ? "LastN_desc" : "LastN";
            ViewBag.age = sortOrder == "Age" ? "Age_desc" : "Age";
            ViewBag.street = sortOrder == "Street" ? "Street_desc" : "Street";
            ViewBag.job = sortOrder == "Job" ? "Job_desc" : "Job";
            ViewBag.salary = sortOrder == "Salary" ? "Salary_desc" : "Salary";

            List<Employee> employees = context.Employees.ToList();

            switch (sortOrder)
            {
                case "name_desc":
                    employees = employees.OrderByDescending(e => e.FirstName).ToList();
                    break;
                case "LastN":
                    employees = employees.OrderBy(e => e.LastName).ToList();
                    break;
                case "LastN_desc":
                    employees = employees.OrderByDescending(e => e.LastName).ToList();
                    break;
                case "Age":
                    employees = employees.OrderBy(e => e.Age).ToList();
                    break;
                case "Age_desc":
                    employees = employees.OrderByDescending(e => e.Age).ToList();
                    break;
                case "Street":
                    employees = employees.OrderBy(e => e.Street).ToList();
                    break;
                case "Street_desc":
                    employees = employees.OrderByDescending(e => e.Street).ToList();
                    break;
                case "Job":
                    employees = employees.OrderBy(e => e.Job).ToList();
                    break;
                case "Job_desc":
                    employees = employees.OrderByDescending(e => e.Job).ToList();
                    break;
                case "Salary":
                    employees = employees.OrderBy(e => e.Salary).ToList();
                    break;
                case "Salary_desc":
                    employees = employees.OrderByDescending(e => e.Salary).ToList();
                    break;
                default:
                    employees = employees.OrderBy(e => e.FirstName).ToList();
                    break;
            }

            return View(employees);
        }

        [HttpPost]
        public JsonResult doSearch(string Search, string Option)
        {
            List<Employee> employees;
            switch (Option)
            {
                case "option2":
                    employees = context.Employees.Where(e => e.LastName.StartsWith(Search)).ToList();
                    break;
                case "option3":
                    employees = context.Employees.Where(e => e.Job.StartsWith(Search)).ToList();
                    break;
                case "option4":
                    employees = context.Employees.Where(e => e.Salary.ToString().StartsWith(Search)).ToList();
                    break;
                default:
                    employees = context.Employees.Where(e => e.FirstName.StartsWith(Search)).ToList();
                    break;
            }


            return Json(employees, JsonRequestBehavior.AllowGet);
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