using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Quitr2.Models.Api;
using Quitr2.ApiClasses;

namespace Quitr2.Controllers
{
    public class CounterController : ApiController
    {
        // GET all counters
        [cacheFilter(TimeDuration = 3600)]
        public IHttpActionResult Get()
        {

            var model = new GetAllCounters();

            using (var db = new ginoEntities1())
            {
                var userIdquery = (from prefs in db.userprefs
                              select new { prefs.userId }).Distinct();

                if (userIdquery == null)
                {
                    return NotFound();
                }
                else
                {

                    model.UserIds.AddRange(
                        userIdquery.ToList().Select(
                            x =>
                            new GetAllCountersUserId()
                            {
                                userId = x.userId
                            }));

                    var countersquery = (from prefs in db.userprefs
                                         join a1 in db.addictiontypes on prefs.addictiontype equals a1.Id into a2
                                         from a in a2.DefaultIfEmpty()
                                         select new { prefs.Deleted, prefs.userId, prefs.Id, a.Name });

                    model.GetAllCounterslist.AddRange(
                        countersquery.ToList().Select(
                            x =>
                            new GetAllCountersDetails()
                            {
                                Id = x.Id,
                                deleted = x.Deleted ?? false,
                                Addiction = x.Name
                            }));


                }
            }
            return Ok(model);
        }


        // GET details about a counter
        [cacheFilter(TimeDuration = 200)]
        public IHttpActionResult Get(int id)
        {

            var model = new GetCounter();

            using (var db = new ginoEntities1())
            {
                var result = (from prefs in db.userprefs
                              where prefs.Id == id
                              select new
                              {
                                  prefs.stopDate,
                                  prefs.cost,
                                  prefs.addictiontype,
                                  prefs.units,
                                  prefs.Id,
                                  prefs.Deleted,
                                  prefs.addictionproducttype,
                                  prefs.substituteUser
                              }).FirstOrDefault();

                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    var days = DateTime.UtcNow.Subtract(result.stopDate ?? DateTime.UtcNow).TotalDays;
                    var addtype = (from a in db.addictiontypes
                                   where a.Id == result.addictiontype
                                   select new { a.Name }).FirstOrDefault();

                    model.stopDate = result.stopDate ?? DateTime.UtcNow;
                    model.costPerDay = result.cost;
                    model.unitsPerDay = result.units;
                    model.addictionType = result.addictiontype;
                    model.addictionTypeName = addtype.Name;
                    model.deleted = result.Deleted ?? true;

                    int daysConverted = Convert.ToInt32(days);
                    model.totalDays = daysConverted;
                    model.totalUnits = Convert.ToInt32(days * result.units ?? 0);
                    model.totalCost = Convert.ToInt32(days * result.cost ?? 0);

                    return Ok(model);
                }


                //var ContentsQuery = (from g in db.productcontents
                //                     join p1 in db.productcontenttypes on g.productcontenttypeId equals p1.Id into p2
                //                     from p in p2.DefaultIfEmpty()
                //                     where result.addictionproducttype == g.ProductId
                //                     orderby g.Id
                //                     select new
                //                     {
                //                         p.Name,
                //                         g.Amount,
                //                         g.Unit
                //                     });

                //model.ProductContents.AddRange(
                //    ContentsQuery.ToList().Select(
                //        x =>
                //        new ProductContentsModel()
                //        {
                //            Amount = x.Amount ?? 0,
                //            Unit = x.Unit,
                //            ContentName = x.Name
                //        }));

                ////get achivements
                //var achivementsresult = (from ua in db.userachivements
                //                         join a1 in db.achivements on ua.achivementid equals a1.level into a2
                //                         from a in a2.DefaultIfEmpty()
                //                         where ua.userprefid == result.Id && ua.deleted == false && a.type == ua.achivementtype
                //                         orderby a.level ascending
                //                         select new { a.icon, a.level, a.color, a.description });

                //model.Achivements.AddRange(
                //    achivementsresult.ToList().Select(
                //        x =>
                //        new AchivementsModel()
                //        {
                //            icon = x.icon,
                //            color = x.color,
                //            description = x.description,
                //            level = x.level
                //        }));

                //if (result.substituteUser == true)
                //{
                //    model.isUsingSubstitute = true;

                //    var substituteIdQuery = (from s in db.substitutes
                //                             where s.deleted == false && s.userprefId == result.Id
                //                             orderby s.updated descending
                //                             select new { s.Id }).FirstOrDefault();

                //    model.substituteId = substituteIdQuery.Id;

                //    //get total nicotine per day
                //    var nicPerDayQuery = (from n in db.nicotine_per_day
                //                          where n.userprefid == result.Id
                //                          select new { n.nic_per_day }
                //                          ).FirstOrDefault();

                //    //get today's substitute-nicotine
                //    var substitute = (from s in db.substitute_nicotine_today
                //                      where s.userprefid == result.Id
                //                      select new { s.today_amount }).FirstOrDefault();

                //    if (substitute != null)
                //    {
                //        var badamount = (substitute.today_amount / nicPerDayQuery.nic_per_day);

                //        if (badamount.Value > 0.3M)
                //        { model.substituteMood = "#ecaa93"; }
                //        else if (badamount.Value > 0.2M)
                //        { model.substituteMood = "#f3c8b9"; }
                //        else if (badamount.Value > 0.05M)
                //        { model.substituteMood = "#faf5e5"; }
                //        else if (badamount.Value > 0.02M)
                //        { model.substituteMood = "#b9f3c8"; }
                //        else
                //        { model.substituteMood = "#93ecaa"; }

                //        model.substituteDayAmount = substitute.today_amount;
                //    }
                //    else
                //    {
                //        model.substituteMood = "#93ecaa";
                //        model.substituteDayAmount = 0;
                //    }



                //    model.ProductContents.AddRange(
                //   ContentsQuery.ToList().Select(
                //       x =>
                //       new ProductContentsModel()
                //       {
                //           Amount = x.Amount ?? 0,
                //           Unit = x.Unit,
                //           ContentName = x.Name
                //       }));
                //}
            }


            //return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}