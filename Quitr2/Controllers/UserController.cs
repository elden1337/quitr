using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quitr2.Models.User;
using Microsoft.AspNet.Identity;
using System.Globalization;

namespace Quitr2.Controllers
{

    public class UserController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");

            }

            var model = new UserModel();
            using (var db = new ginoEntities1())
            {

                var user = User.Identity.GetUserId();
                if (user != null)
                {
                    var result = (from prefs in db.userprefs
                                  where prefs.Deleted == false && prefs.userId == user
                                  select new { prefs.stopDate, prefs.cost, prefs.addictiontype, prefs.units, prefs.Id, prefs.Deleted, prefs.addictionproducttype, prefs.substituteUser }).FirstOrDefault();

                    if (result == null)
                    {
                        return RedirectToAction("Setup", "User");
                    }

                    //påbörja achivements
                    var days = DateTime.UtcNow.Subtract(result.stopDate ?? DateTime.UtcNow).TotalDays;

                    if (days > 1)
                    {
                        if (days > 365)
                        {

                        }
                        else if (days > 182)
                        {

                        }
                        else if (days > 100)
                        {

                        }
                        else if (days > 31)
                        {

                        }
                        else if (days > 7)
                        {

                        }
                        else
                        {

                        }
                    }
                    //achivements slut

                    var addtype = (from a in db.addictiontypes
                                   where a.Id == result.addictiontype
                                   select new { a.Name }).FirstOrDefault();


                    model.stopDate = result.stopDate ?? DateTime.UtcNow;
                    model.cost = result.cost;
                    model.units = result.units;
                    model.addictionType = result.addictiontype;
                    model.addictionTypeName = addtype.Name;
                    model.userprefId = result.Id;
                    model.counterDeleted = result.Deleted ?? true;

                    
                    int daysConverted = Convert.ToInt32(days);
                    int totalUnits = daysConverted * result.units ?? 0;


                    var ContentsQuery = (from g in db.productcontents
                                         join p1 in db.productcontenttypes on g.productcontenttypeId equals p1.Id into p2
                                         from p in p2.DefaultIfEmpty()
                                         where result.addictionproducttype == g.ProductId
                                         orderby g.Id
                                         select new
                                         {
                                             p.Name,
                                             g.Amount,
                                             g.Unit
                                         });

                    //foreach (var amount in ContentsQuery)
                    //{
                    //   if(amount.Amount * totalUnits > 1000 && amount.Unit == "mg")
                    //    {
                    //        amount.Unit = "g";

                    //    }

                    //}

                    model.ProductContents.AddRange(
                        ContentsQuery.ToList().Select(
                            x =>
                            new ProductContentsModel()
                            {
                                Amount = x.Amount ?? 0,
                                Unit = x.Unit,
                                ContentName = x.Name
                            }));

                    if (result.substituteUser == true)
                    {
                        model.isUsingSubstitute = true;

                        var substituteIdQuery = (from s in db.substitutes
                                                 where s.deleted == false && s.userprefId == result.Id
                                                 orderby s.updated descending
                                                 select new { s.Id }).FirstOrDefault();

                        model.substituteId = substituteIdQuery.Id;

                        //get total nicotine per day
                        var nicPerDayQuery = (from n in db.nicotine_per_day
                                              where n.userprefid == result.Id
                                              select new { n.nic_per_day }
                                              ).FirstOrDefault();

                        //get today's substitute-nicotine
                        var substitute = (from s in db.substitute_nicotine_today
                                          where s.userprefid == result.Id
                                          select new { s.today_amount }).FirstOrDefault();

                        if (substitute != null)
                        {
                            var badamount = (substitute.today_amount / nicPerDayQuery.nic_per_day);

                            if (badamount.Value > 0.3M)
                            { model.substituteMood = "#ecaa93"; }
                            else if (badamount.Value > 0.2M)
                            { model.substituteMood = "#f3c8b9"; }
                            else if (badamount.Value > 0.05M)
                            { model.substituteMood = "#faf5e5"; }
                            else if (badamount.Value > 0.02M)
                            { model.substituteMood = "#b9f3c8"; }
                            else
                            { model.substituteMood = "#93ecaa"; }

                            model.substituteDayAmount = substitute.today_amount;
                        }
                        else
                        {
                            model.substituteMood = "#93ecaa";
                            model.substituteDayAmount = 0;
                        }
                    }
                }
            }
            return View(model);
        }

        //LÄGG TILL SUBSTITUTE
        [HttpPost]
        public PartialViewResult addMg(string moodbutton, int substituteId, UserModel model)

        {
            using (var db = new ginoEntities1())
            {
                substitutestat st = new substitutestat();
                db.substitutestats.Add(st);

                st.substituteId = substituteId;
                st.TS = DateTime.UtcNow;
                db.SaveChanges();
            };

            //detta borde inte vara här

            using (var db = new ginoEntities1())
            {

                var user = User.Identity.GetUserId();
                if (user != null)
                {
                    var result = (from prefs in db.userprefs
                                  where prefs.Deleted == false && prefs.userId == user
                                  select new { prefs.Id, prefs.substituteUser }).FirstOrDefault();

                    if (result == null)
                    {
                        //return RedirectToAction("Setup", "User");
                    }

                    //HARDCODE, CHANGE LATER
                    if (result.substituteUser == true)
                    {
                        model.isUsingSubstitute = true;

                        var substituteIdQuery = (from s in db.substitutes
                                                 where s.deleted == false && s.userprefId == result.Id
                                                 orderby s.updated descending
                                                 select new { s.Id }).FirstOrDefault();

                        model.substituteId = substituteIdQuery.Id;

                        //get total nicotine per day
                        var nicPerDayQuery = (from n in db.nicotine_per_day
                                              where n.userprefid == result.Id
                                              select new { n.nic_per_day }
                                              ).FirstOrDefault();

                        //get today's substitute-nicotine
                        var substitute = (from s in db.substitute_nicotine_today
                                          where s.userprefid == result.Id
                                          select new { s.today_amount }).FirstOrDefault();

                        if (substitute != null)
                        {
                            var badamount = (substitute.today_amount / nicPerDayQuery.nic_per_day);

                            if (badamount.Value > 0.3M)
                            { model.substituteMood = "#ecaa93"; }
                            else if (badamount.Value > 0.2M)
                            { model.substituteMood = "#f3c8b9"; }
                            else if (badamount.Value > 0.05M)
                            { model.substituteMood = "#faf5e5"; }
                            else if (badamount.Value > 0.02M)
                            { model.substituteMood = "#b9f3c8"; }
                            else
                            { model.substituteMood = "#93ecaa"; }
                            model.substituteDayAmount = substitute.today_amount ?? 0;
                        }
                        else
                        {
                            model.substituteMood = "#93ecaa";
                            model.substituteDayAmount = 0;
                        }


                    }
                }
            }

            //DEtta borde inte vara här

            return PartialView("_SubstitutePartial", model);

        }

        //SKICKA MOODS
        [HttpPost]
        public PartialViewResult Index(int userprefid, string moodbutton, UserModel model)

        {
            int mood = 1337;

            if (moodbutton == "minustwo")
            {
                mood = -2;
            }
            else if (moodbutton == "minusone")
            {
                mood = -1;
            }
            else if (moodbutton == "zero")
            {
                mood = 0;
            }
            else if (moodbutton == "plusone")
            {
                mood = 1;
            }
            else if (moodbutton == "plustwo")
            {
                mood = 2;
            }

            using (var db = new ginoEntities1())
            {
                mood dd = new mood();
                db.moods.Add(dd);

                dd.Mood1 = mood;
                dd.TS = DateTime.UtcNow;
                dd.userprefid = userprefid;
                //dd.userprefid = model.userprefId;
                db.SaveChanges();
            }

            ViewBag.Records = "Your mood has been stored. Keep it up!";

            //detta borde inte vara här

            using (var db = new ginoEntities1())
            {

                var user = User.Identity.GetUserId();
                if (user != null)
                {
                    var result = (from prefs in db.userprefs
                                  where prefs.Deleted == false && prefs.userId == user
                                  select new { prefs.Id }).FirstOrDefault();

                    if (result == null)
                    {
                        //return RedirectToAction("Setup", "User");
                    }

                    model.userprefId = result.Id;
                }
            }

            //DEtta borde inte vara här

            return PartialView("_MoodPartial", model);

        }

        [HttpGet]
        public ActionResult Settings()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");

            }

            var model = new UserModel();
            using (var db = new ginoEntities1())
            {

                var user = User.Identity.GetUserId();
                if (user != null)
                {
                    var oldcounters = (from prefs in db.userprefs
                                       where prefs.userId == user && prefs.Deleted == true
                                       orderby prefs.stopDate descending
                                       select new { prefs.stopDate, prefs.cost, prefs.addictiontype, prefs.units, prefs.Id, prefs.addictionproducttype, prefs.deleteDate, prefs.sharing });

                    model.UserCounters.AddRange(
                                           oldcounters.ToList().Select(
                                               x =>
                                               new UserDeletedCountersModel()
                                               {
                                                   stopDate = x.stopDate ?? DateTime.UtcNow,
                                                   cost = x.cost,
                                                   units = x.units,
                                                   addictionType = x.addictiontype,
                                                   addictionProductType = x.addictionproducttype,
                                                   userprefId = x.Id,
                                                   deletedDate = x.deleteDate,
                                               }));

                    var currentcounter = (from prefs in db.userprefs
                                          where prefs.userId == user && prefs.Deleted == false
                                          select new { prefs.stopDate, prefs.cost, prefs.addictiontype, prefs.units, prefs.Id, prefs.addictionproducttype, prefs.substituteUser }).FirstOrDefault();

                    if (currentcounter.substituteUser == true)
                    {
                        var substitutequery = (from s in db.substitutes
                                               where currentcounter.Id == s.userprefId && s.deleted == false
                                               orderby s.updated descending
                                               select new { s.amount }
                                          ).FirstOrDefault();

                        model.Substituteamount = substitutequery.amount;

                    }

                    if (currentcounter != null)
                    {
                        model.stopDate = currentcounter.stopDate ?? DateTime.UtcNow;
                        model.cost = currentcounter.cost;
                        model.addictionType = currentcounter.addictiontype;
                        model.units = currentcounter.units;
                        model.addictionProductType = currentcounter.addictionproducttype;
                        model.userprefId = currentcounter.Id;
                        model.isUsingSubstitute = currentcounter.substituteUser ?? false;
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Settings(UserModel model)
        {

            if (Request.Form["updateSettings"] != null)
            {
                using (var db = new ginoEntities1())
                {

                    var updatebool = db.userprefs.FirstOrDefault(x => x.Id == model.userprefId);
                    if (updatebool == null)
                    {

                    }
                    updatebool.substituteUser = model.isUsingSubstitute;

                    if (model.isUsingSubstitute == true)
                    {

                        substitute dd = new substitute();
                        db.substitutes.Add(dd);

                        dd.updated = DateTime.UtcNow;
                        dd.unit = "mg";
                        dd.amount = model.Substituteamount;
                        dd.userprefId = model.userprefId;
                        dd.deleted = false;
                    }

                    db.SaveChanges();

                }
                return RedirectToAction("Settings", "User");
            }
            else if (Request.Form["stopCounter"] != null)
            {
                using (var db = new ginoEntities1())
                {

                    var stopCounting = db.userprefs.FirstOrDefault(x => x.Id == model.userprefId);
                    if (stopCounting == null)
                    {
                        return this.HttpNotFound("Something went wrong. Please try again.");
                    }

                    stopCounting.Deleted = true;
                    stopCounting.deleteDate = DateTime.UtcNow;

                    db.SaveChanges();
                }
                return RedirectToAction("Setup", "User");

            }
            else
            {
                return RedirectToAction("Settings", "User");
            }
        }

        [HttpGet]
        public ActionResult Setup()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");

            }


            var model = new SetupModel();
            using (var db = new ginoEntities1())
            {
                var typeQuery = (from t in db.addictiontypes
                                 where t.Deleted == false
                                 orderby t.Name ascending
                                 select new { t.Id, t.Name });

                model.AddicitionTypes.AddRange(
                    typeQuery.ToList().Select(
                        x =>
                        new AddictionTypesModel()
                        {
                            Id = x.Id,
                            Name = x.Name
                        }));

                var productQuery = (from p in db.products
                                    where p.deleted == false
                                    orderby p.Producttype ascending
                                    select new { p.Producttype, p.Id, p.Name });



                model.ProductListing.AddRange(
                    productQuery.ToList().Select(
                        x =>
                        new ProductListingModel()
                        {
                            Id = x.Id,
                            Name = x.Name,
                            ProductType = x.Producttype
                        }
                        ));

            }

            return View(model);
        }


        [HttpPost]
        public ActionResult Setup(SetupModel model)
        {
            if (model == null)
            {
                ViewBag.Records = "Something went wrong. Please try again.";
                return RedirectToAction("Index", "Home");
            }

            using (var db = new ginoEntities1())
            {
                userpref dd = new userpref();
                 db.userprefs.Add(dd);

                dd.addictiontype = model.AddictionType;
                dd.cost = model.Costperday;
                dd.units = model.Nmbrperday;
                dd.userId = model.UserId;
                dd.stopDate = DateTime.UtcNow;
                dd.Deleted = false;
                dd.sharing = true;
                dd.substituteUser = model.UsingSubstitute;

                //dd.addictionproducttype = model.ProductPost;
                //Hårdkodat produktval tills väljare funkar bra.
                if (model.AddictionType == 1)
                {
                    dd.addictionproducttype = 1;
                }
                else if (model.AddictionType == 2)
                {
                    dd.addictionproducttype = 2;
                }

                db.SaveChanges();

                if (model.UsingSubstitute == true)
                {
                    substitute s = new substitute();
                    db.substitutes.Add(s);

                    s.amount = model.Substituteamount;
                    s.unit = "mg";
                    s.deleted = false;
                    s.updated = DateTime.UtcNow;
                    s.userprefId = dd.Id;
                    db.SaveChanges();
                }

            }

            return RedirectToAction("Index", "User");
        }

        public ActionResult Stats(int CounterId)
        {
            if (CounterId > 0)
            {
                using (var db = new ginoEntities1())
                {
                    var moods = (from m in db.substitute_nicotine_per_day
                                 where m.userprefid == CounterId
                                 select new { m.year, m.month, m.day, m.substitute_sum});
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }



        public ActionResult Share(string UserId)
        {

            var model = new UserModel();
            using (var db = new ginoEntities1())
            {


                if (UserId != null)
                {
                    var result = (from prefs in db.userprefs
                                  where prefs.Deleted == false && prefs.userId == UserId && prefs.sharing == true
                                  select new { prefs.stopDate, prefs.cost, prefs.addictiontype, prefs.units, prefs.Id, prefs.addictionproducttype }).FirstOrDefault();

                    if (result == null)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    var CurrentMoodQuery = (from m in db.moods
                                            where m.userprefid == result.Id
                                            orderby m.TS descending
                                            select new { m.Mood1 }
                        ).FirstOrDefault();

                    if (CurrentMoodQuery != null)
                    {
                        model.currentMood = CurrentMoodQuery.Mood1;
                    }

                    model.stopDate = result.stopDate ?? DateTime.UtcNow;
                    model.cost = result.cost;
                    model.units = result.units;
                    model.addictionType = result.addictiontype;
                    model.userprefId = result.Id;
                    model.userId = UserId;


                    var ContentsQuery = (from g in db.productcontents
                                         join p1 in db.productcontenttypes on g.productcontenttypeId equals p1.Id into p2
                                         from p in p2.DefaultIfEmpty()
                                         where result.addictionproducttype == g.ProductId
                                         orderby g.Id
                                         select new { p.Name, g.Amount, g.Unit });

                    model.ProductContents.AddRange(
                        ContentsQuery.ToList().Select(
                            x =>
                            new ProductContentsModel()
                            {
                                Amount = x.Amount ?? 0,
                                Unit = x.Unit,
                                ContentName = x.Name
                            }));





                }
            }
            return View(model);
        }
    }
}