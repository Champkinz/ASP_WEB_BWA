using ASP_WEB_BWA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ASP_WEB_BWA.Models
{
    public class Log
    {
        [Required]
        [Display(Name = "Username")]
            public string Username { get; set; }

        [Required]
        [Display(Name = "Password")]
            public string Password { get; set; }
    }
}