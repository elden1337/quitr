using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quitr2.Models.Home;
using Microsoft.AspNet.Identity;
using System.Globalization;
using Quitr2.ApiClasses;

namespace Quitr2.Controllers
{
   
    public class HomeController : Controller
    {

        
        [HttpGet]
        [cacheFilter(TimeDuration = 7200)]
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
           
                var unitssnus = (from u in db.totalunits
                             where u.addictiontype == 1
                             select new {u.units}).FirstOrDefault();

                var unitscig = (from u in db.totalunits
                                where u.addictiontype == 2
                                select new { u.units }).FirstOrDefault();

                var savings = (from s in db.totalsavings
                               select new { s.savings }).FirstOrDefault();

                model.totalCounters = result;
                model.totalSnus =  unitssnus.units;
                model.totalCig = unitscig.units;
                model.savings = savings.savings;
                
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