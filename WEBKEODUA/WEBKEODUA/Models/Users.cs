using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBKEODUA.Models
{
    public class Users
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int MAKH { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string TENKH { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string EMAIL { get; set; }

        [Required]
        public string TK { get; set; }

        [Required]
        public string MK { get; set; }

        [NotMapped]
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("MK")]
        public string ConfirmPassword { get; set; }
    }
}