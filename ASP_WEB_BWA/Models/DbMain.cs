using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASP_WEB_BWA.Models
{
    public class DbMain : DbContext
    {
        public DbSet<Test> Tst { get; set; }
        public DbSet<TestRv> Tst2 { get; set; }
        public DbSet<Class12> classss { get; set; }
        public DbSet<Charana> champ { get; set; }

        public DbSet<loginuser> loginuser { get; set; }

        public DbSet<Product> product { get; set; }
    }
}