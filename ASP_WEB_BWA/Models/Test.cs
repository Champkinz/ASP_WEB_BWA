﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_WEB_BWA.Models
{
    public class Test
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public virtual ICollection<TestRv> Testz { get; set; }
    }
}