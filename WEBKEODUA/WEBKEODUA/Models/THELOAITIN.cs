//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WEBKEODUA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class THELOAITIN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THELOAITIN()
        {
            this.TINTUCs = new HashSet<TINTUC>();
        }
    
        public string MALOAI { get; set; }
        public string TENLOAI { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TINTUC> TINTUCs { get; set; }
    }
}