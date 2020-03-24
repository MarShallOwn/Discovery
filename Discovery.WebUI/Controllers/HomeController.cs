using Discovery.Core.Models;
using Discovery.DataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Discovery.WebUI.Controllers
{
    public class HomeController : Controller
    {

        public DataContext context = new DataContext();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult getUser()
        {
            NurseryUser user = context.Users.FirstOrDefault(u => u.Email == User.Identity.Name);

            return PartialView("_getUser",user);
        }
    }
}