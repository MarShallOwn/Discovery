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

            var usersWithRoles = (from user in context.Users
                                  from userRole in user.Roles
                                  join role in context.Roles on userRole.RoleId equals
                                  role.Id
                                  select new UserWithRoleViewModel()
                                  {
                                      UserId = user.Id, 
                                      Email = user.UserName,
                                      Role = role.Name
                                  }).ToList();

            AdminViewModel model = new AdminViewModel();

            model.roles = roles;
            model.UsersWithRoleModel = usersWithRoles;

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
                        return RedirectToAction("Index");
                    }

                    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                    string role = roleManager.Roles.FirstOrDefault(r => r.Name == model.role).Name;

                    UserManager.AddToRole(user.Id, role);

                    return RedirectToAction("Index");
                }
                
            }
            
        }

        public ActionResult Delete(string UserId)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            List<string> roles = roleManager.Roles.Select(r => r.Name).ToList();

            var UsersWithRole = (from user in context.Users
                                  from userRole in user.Roles
                                  join role in context.Roles on user.Id equals
                                  UserId
                                 select new UserWithRoleViewModel()
                                  {
                                      Email = user.UserName,
                                      Role = role.Name
                                  }).FirstOrDefault();

            return View(UsersWithRole);
        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string UserId)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            
            UserManager.RemoveFromRole(UserId, UserManager.GetRoles(UserId).FirstOrDefault());

            return RedirectToAction("Index");
        }

    }
}