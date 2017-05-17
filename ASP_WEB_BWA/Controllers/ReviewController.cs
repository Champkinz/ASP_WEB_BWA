using ASP_WEB_BWA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_WEB_BWA.Controllers
{
    public class ReviewController : Controller
    {
        DbMain _db = new DbMain();

        // GET: Review
        public ActionResult Index([Bind(Prefix="id")] int resid)
        {
            var res = _db.Tst.Find(resid);
            if (res != null)
            {
                return View(res);
            }

            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Create(int resid)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TestRv rev)
        {
            if (ModelState.IsValid)
            {
                _db.Tst2.Add(rev);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = rev.ResID });
            }
            return View(rev);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}