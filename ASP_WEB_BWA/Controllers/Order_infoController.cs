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
    public class Order_infoController : Controller
    {
        private DbMain db = new DbMain();

        // GET: Order_info
        public ActionResult Index()
        {
            return View(db.OrderDts.ToList());
        }

        public ActionResult Checkout(Order_info odr)
        {
            List<Cart> cart = (List<Cart>)Session["Cart"];
            loginuser currentuser = (loginuser)Session["User"];
            var x = db.OrderDts.Count();
            Order_info oder = new Order_info();
           
                foreach (Cart item in cart)
                {
                    oder.Product_ID = x++;
                    oder.Total = oder.Total + (item.Quantity * item.Pro.sellingPrice);
                    oder.Product_ID = item.Pro.ProductID;
                    oder.Product_Type = item.Pro.ProductType;
                    oder.Product_Name = oder.Product_Name + " | " + item.Pro.ProductName + "x" + item.Quantity;
                    oder.Quantity = item.Quantity;
                    oder.Full_Name = currentuser.firstname;
                    oder.Username = currentuser.username;
                    oder.Address = currentuser.address;
                    oder.CardType = odr.CardType;
                    oder.CreditCardNo = odr.CreditCardNo;
                    oder.CVC = odr.CVC;
                    oder.Expiry_Date = odr.Expiry_Date;
                }
            if (oder.CVC != null)
            {
                db.OrderDts.Add(oder);
                db.SaveChanges();
            }
            return View("Checkout");

        }

        public ActionResult vieworders()
        {
            //var model = db.OrderDts.Where(r => r.Username)
                var result = db.OrderDts.GroupBy(chk => new { chk.Username ,chk.Expiry_Date })
                  .Select(group => group.FirstOrDefault());
            return View(result);
        }

        // GET: Order_info/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_info order_info = db.OrderDts.Find(id);
            if (order_info == null)
            {
                return HttpNotFound();
            }
            return View(order_info);
        }

        // GET: Order_info/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order_info/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "orderid,Total,Product_ID,Product_Type,Product_Name,Quantity,Full_Name,Username,Address,CardType,CreditCardNo,CVC,Expiry_Date")] Order_info order_info)
        {
            if (ModelState.IsValid)
            {
                db.OrderDts.Add(order_info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order_info);
        }

        // GET: Order_info/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_info order_info = db.OrderDts.Find(id);
            if (order_info == null)
            {
                return HttpNotFound();
            }
            return View(order_info);
        }

        // POST: Order_info/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "orderid,Total,Product_ID,Product_Type,Product_Name,Quantity,Full_Name,Username,Address,CardType,CreditCardNo,CVC,Expiry_Date")] Order_info order_info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order_info);
        }

        // GET: Order_info/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_info order_info = db.OrderDts.Find(id);
            if (order_info == null)
            {
                return HttpNotFound();
            }
            return View(order_info);
        }

        // POST: Order_info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order_info order_info = db.OrderDts.Find(id);
            db.OrderDts.Remove(order_info);
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
