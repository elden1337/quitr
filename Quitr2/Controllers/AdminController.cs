using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quitr2.Models.Admin;
using Microsoft.AspNet.Identity;

namespace Quitr2.Controllers
{

    public class AdminController : Controller
    {

        [HttpGet]
        public ActionResult A6628f749b17c4e5b832c354e5b0ea22d()
        {

            //if (User.Identity.Name == "magnus.elden@outlook.com")
            //{

                using (var db = new ginoEntities1())
                {
                    var prefs = (from p in db.userprefs
                                 where p.Deleted == false
                                 select new { p.Id, p.stopDate }).ToArray();

                    if (prefs != null)
                    {
                        foreach (var Id in prefs)
                        {
                            var now = DateTime.UtcNow;
                            var stop = Id.stopDate;
                            var length = (now - stop).Value.TotalDays;
                            int level = 0;

                            if (length > 364)
                            {
                                level = 6;
                            }
                            else if (length > (365 / 2))
                            {
                                level = 5;
                            }
                            else if (length > 99)
                            {
                                level = 4;
                            }
                            else if (length > 31)
                            {
                                level = 3;
                            }
                            else if (length > 6)
                            {
                                level = 2;
                            }
                            else if (length > 1)
                            {
                                level = 1;
                            }

                            var maxlevel = (from ua in db.userachivements
                                            where ua.userprefid == Id.Id && ua.deleted == false && ua.achivementtype == 2
                                            orderby ua.achivementid descending
                                            select ua.achivementid).Take(1).SingleOrDefault().ToString();

                            var maxlevelint = 0;
                            maxlevelint = Int32.Parse(maxlevel);
                          

                            if (level > maxlevelint)
                            {
                                for (int n = 1; n <= level; n++)
                                {
                                    userachivement uas = new userachivement();
                                    db.userachivements.Add(uas);
                                    uas.deleted = false;
                                    uas.TS = DateTime.UtcNow;
                                    uas.userprefid = Id.Id;
                                    uas.achivementtype = 2;
                                    //uas.achivementid = level;
                                    uas.achivementid = n;
                                    db.SaveChanges();
                                }
                            }

                        }
                    }

                }

                return View();
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Home");
            //}
        }

        [HttpPost]
        public ActionResult Index(int test)
        {



            using (var db = new ginoEntities1())
            {
                var prefs = (from p in db.userprefs
                             where p.Deleted == false
                             select p.Id);

                if (prefs != null)
                {
                    foreach (var Id in prefs)
                    {
                        var now = DateTime.UtcNow;
                        var stop = (from u in db.userprefs
                                    where u.Id == Id
                                    select u.stopDate).Single();
                        var length = now - stop.Value;

                    }
                }

            }

            return View();
        }

    }
}