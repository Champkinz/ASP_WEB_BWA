using ASP_WEB_BWA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_WEB_BWA.Controllers
{
    public class CartController : Controller
    {
        private DbMain db = new DbMain();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Checkout()
        {
            return View("Checkout"); 
        }

       
        private int isExisting(int id)
        {
            List<Cart> cart = (List<Cart>)Session["Cart"];

            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Pro.ProductID == id)
                    return i;
            return -1;


        }

        public ActionResult DeleteFromCart(int id)
        {
            int index = isExisting(id);
            List<Cart> cart = (List<Cart>)Session["Cart"];
            cart.RemoveAt(index);
            Session["Cart"] = cart;


            return View("Cart");
        }

        public ActionResult OrderNow(int id)
        {
            if (Session["cart"] == null)
            {
                List<Cart> cart = new List<Cart>();
                cart.Add(new Cart(db.product.Find(id),1));
                Session["cart"] = cart; 
            }else
            {
                List<Cart> cart = (List<Cart>)Session["Cart"];

                int index = isExisting(id);

                if (index == -1)
                    cart.Add(new Cart(db.product.Find(id), 1));
                else
                    cart[index].Quantity++;

                Session["Cart"] = cart;
            }
            return View("Cart");
        }
    }
}