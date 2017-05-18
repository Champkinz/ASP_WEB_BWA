using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP_WEB_BWA.Models
{
    public class loginuser
    {
        [Key]
        public int userid { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string password { get; set; }
        public string type { get; set; }
        [Required]
        public string firstname { get; set; }
        [Required]
        public string lastname { get; set; }
        [Required]
        public string telephone { get; set; }
        [Required]
        public string address { get; set; }
        public string sex { get; set; }

    }
}