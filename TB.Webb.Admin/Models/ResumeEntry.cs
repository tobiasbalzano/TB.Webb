//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TB.Webb.Admin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ResumeEntry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ResumeEntry()
        {
            this.ResumeTag = new HashSet<ResumeTag>();
        }
    
        public int Id { get; set; }
        public int ResumeSectionId { get; set; }
        public string Role { get; set; }
        public string Establishment { get; set; }
        public string Additional { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public bool CurrentPosition { get; set; }
        public string Description { get; set; }
        public int Sorter { get; set; }
    
        public virtual ResumeSection ResumeSection { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResumeTag> ResumeTag { get; set; }
    }
}
