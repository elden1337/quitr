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
    
    public partial class achivement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public achivement()
        {
            this.userachivements = new HashSet<userachivement>();
        }
    
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Nullable<bool> deleted { get; set; }
        public string icon { get; set; }
        public string color { get; set; }
        public Nullable<int> type { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userachivement> userachivements { get; set; }
    }
}
