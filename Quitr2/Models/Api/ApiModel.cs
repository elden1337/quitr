using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quitr2.Models.Api
{
    public class ApiModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}