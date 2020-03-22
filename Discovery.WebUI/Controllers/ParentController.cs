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
    public class ParentController : Controller
    {
        // GET: Parent
        DataContext context = new DataContext();

        public PartialViewResult ChildReport(string Id)
        {

            Parent parent = context.Parents.FirstOrDefault(p => p.ChildId == Id);

            
            Child child = context.Children.FirstOrDefault(c => c.Id == Id);
            NurseryUser user = context.Users.FirstOrDefault(u => u.Id == parent.UserId);
            

            ParentUserChildViewModel model = new ParentUserChildViewModel();

            model.user = user;
            model.child = child;
            model.parent = parent;

            return PartialView("_ChildReport", model);
        }


        [HttpPost]
        public ActionResult Edit(Parent parent)
        {

            Parent pToEdit = context.Parents.Find(parent.Id);

            pToEdit.Child_Weekly_Report = parent.Child_Weekly_Report;

            context.SaveChanges();

            return RedirectToAction("Index", "Child");
        }

    }
}