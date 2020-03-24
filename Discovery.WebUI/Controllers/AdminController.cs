using Discovery.Core.VIewModels;
using Discovery.WebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Discovery.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        ApplicationDbContext context = new ApplicationDbContext();
        public ActionResult Index()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            List<string> roles = roleManager.Roles.Select(r=>r.Name).ToList();


            AdminViewModel model = new AdminViewModel();

            model.roles = roles;

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(AdminViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                ApplicationUser user = context.Users.FirstOrDefault(u => u.Email == model.userEmail);

                if(user == null)
                {
                    return View("error");
                }
                else
                {
                    if(model.role == null)
                    {
                        return RedirectToAction("Index","Home");
                    }

                    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                    string role = roleManager.Roles.FirstOrDefault(r => r.Name == model.role).Name;

                    UserManager.AddToRole(user.Id, role);

                    return RedirectToAction("Index", "Home");
                }
                
            }
            
        }

    }
}