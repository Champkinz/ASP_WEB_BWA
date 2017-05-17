using ASP_WEB_BWA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_WEB_BWA.Controllers
{
    public class HomeController : Controller
    {
        DbMain _db = new DbMain();

        public ActionResult Index()
        {
            //var model = _db.Tst.Where(r => searchterm == null || r.Name.StartsWith(searchterm))
            //    ; 
            var Model = _db.Tst.ToList();
            return View(Model);
        }

        //[Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return Content("lol");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (_db != null)
        //    {
        //        _db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}