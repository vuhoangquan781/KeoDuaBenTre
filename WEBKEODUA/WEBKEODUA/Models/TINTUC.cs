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
    
    public partial class TINTUC
    {
        public string MATIN { get; set; }
        public string MALOAI { get; set; }
        public string TIEUDETIN { get; set; }
        public string NOIDUNG { get; set; }
        public Nullable<System.DateTime> NGAYDANGTIN { get; set; }
        public string ANH { get; set; }
    
        public virtual THELOAITIN THELOAITIN { get; set; }
    }
}