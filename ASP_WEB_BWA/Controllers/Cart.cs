using ASP_WEB_BWA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_WEB_BWA.Controllers
{
    public class Cart
    {
        private Product pro = new Product();
        private int quantity;

        public Product Pro
        {
            get
            {
                return pro;
            }

            set
            {
                pro = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }

        public Cart()
        {
            
        }

        public Cart(Product Product,int qty)
        {
            this.pro = Product;
            this.Quantity = qty;
        }

        

    }
}