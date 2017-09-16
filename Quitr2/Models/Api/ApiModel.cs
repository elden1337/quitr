using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quitr2.Models.Api
{


    public class GetAllCounters
    {

        public GetAllCounters()
        {
            UserIds = new List<GetAllCountersUserId>();
            GetAllCounterslist = new List<GetAllCountersDetails>();
        }
        
        public List<GetAllCountersUserId> UserIds { get; set; }
        public List<GetAllCountersDetails> GetAllCounterslist { get; set; }

    }

    public class GetAllCountersUserId
    {
        //public GetAllCountersUserId()
        //{
        //    GetAllCounterslist = new List<GetAllCountersDetails>();
        //}

        public List<GetAllCountersDetails> GetAllCounterslist { get; set; }
        public string userId { get; set; }
    }


    public class GetAllCountersDetails
    {
        public int? Id { get; set; }
        public bool? deleted { get; set; }
        public string Addiction { get; set; }
        public GetAllCounters GetAllCounters { get; set; }

    }



    public class GetCounter
    {

        public DateTime stopDate { get; set; }
        public int? totalDays { get; set; }

        public int? unitsPerDay { get; set; }
        public int? totalUnits { get; set; }

        public int? costPerDay { get; set; }
        public int? totalCost { get; set; }

        public int? addictionType { get; set; }
        public string addictionTypeName { get; set; }

        public bool? deleted { get; set; }

    }
}