//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Quitr2.Controllers
{
    using System;
    using System.Collections.Generic;
    
    public partial class productcontent
    {
        public int Id { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string Unit { get; set; }
        public Nullable<int> productcontenttypeId { get; set; }
    
        public virtual product product { get; set; }
        public virtual productcontenttype productcontenttype { get; set; }
    }
}
