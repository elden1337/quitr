using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quitr2.Models.Home;
using Microsoft.AspNet.Identity;
using System.Globalization;

namespace Quitr2.Controllers
{
   
    public class HomeController : Controller
    {

        
        [HttpGet]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "User");

            }

            var model = new HomeModel();
            using (var db = new ginoEntities1())
            {
                var result = (from p in db.userprefs
                              where p.Deleted == false
                              select new { p.Id }
                              ).Count();


                model.totalCounters = result;

            };

            return View(model);
        }

      

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Share(string UserId)
        {
            return RedirectToAction("Share", "User", new { UserId = UserId });
           
        }


    }
}