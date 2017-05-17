using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP_WEB_BWA.Models;

namespace ASP_WEB_BWA.Controllers
{
    public class loginusersController : Controller
    {
        private DbMain db = new DbMain();

        // GET: loginusers
        public ActionResult Index()
        {
            return View(db.loginuser.ToList());
        }

        public ActionResult loginindex(loginuser currentdetails)
        {
            if (ModelState.IsValid)
            {
                
                    var v = db.loginuser.Where(a => a.username == currentdetails.username && a.password == currentdetails.password).FirstOrDefault();
                    Session["User"] = v;

                    if (v != null)
                    {
                        if (v.type == "Admin")
                        {
                            return RedirectToAction("Contact","Home");
                        }
                        else
                        {
                            return RedirectToAction("Home", "About");
                        }

                    }
                    else
                    {
                        ViewBag.LoginErrorMessage = "Wrong Username or password";
                        return View("loginindex", currentdetails);
                    }

            }
            return View(currentdetails);
        }



        // GET: loginusers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loginuser loginuser = db.loginuser.Find(id);
            if (loginuser == null)
            {
                return HttpNotFound();
            }
            return View(loginuser);
        }

        // GET: loginusers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: loginusers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userid,username,firstname,password,type,lastname,telephone,address,sex")] loginuser loginuser)
        {
            if (ModelState.IsValid)
            {
                db.loginuser.Add(loginuser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loginuser);
        }

        // GET: loginusers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loginuser loginuser = db.loginuser.Find(id);
            if (loginuser == null)
            {
                return HttpNotFound();
            }
            return View(loginuser);
        }

        // POST: loginusers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userid,username,firstname,lastname,telephone,address,sex")] loginuser loginuser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loginuser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loginuser);
        }

        // GET: loginusers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loginuser loginuser = db.loginuser.Find(id);
            if (loginuser == null)
            {
                return HttpNotFound();
            }
            return View(loginuser);
        }

        // POST: loginusers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            loginuser loginuser = db.loginuser.Find(id);
            db.loginuser.Remove(loginuser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
