using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quitr2.Models.Admin;
using Microsoft.AspNet.Identity;

namespace Quitr2.Controllers
{
    [RequireHttps]
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            

            return RedirectToAction("Index", "Home");
        }

        //[HttpPost]
        //public ActionResult Index(AdminModel model)
        //{
        //    using (var db = new ginoEntities())
        //    {
        //        var stopCounting = db.userprefs.FirstOrDefault(x => x.Id == model.userprefId);
        //        if (stopCounting == null)
        //        {

        //        }

        //        stopCounting.Deleted = true;

        //    db.SaveChanges();
        //    }

        //    return RedirectToAction("Index", "Home");
        //}

    }
}