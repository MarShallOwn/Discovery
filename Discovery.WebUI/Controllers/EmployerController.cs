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

    }
}