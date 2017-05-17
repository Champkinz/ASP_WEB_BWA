using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_WEB_BWA.Models
{
    public class loginuser
    {
        [Key]
        public int userid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string type { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string telephone { get; set; }
        public string address { get; set; }
        public string sex { get; set; }

    }
}