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

                
            }

            
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

    public class magnusController : ApiController
    {
        // GET the user's counter
        [cacheFilter(TimeDuration = 3600)]
        public IHttpActionResult Get(string userid)
        {
            //string userid = "f55abb72-b485-43eb-bf99-159ff08aa0b6";
            var model = new GetCounter();

            using (var db = new ginoEntities1())
            {
                var result = (from prefs in db.userprefs
                              where prefs.userId == userid && prefs.Deleted == false
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


            }


        }
    }
}