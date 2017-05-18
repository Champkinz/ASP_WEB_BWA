using ASP_WEB_BWA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_WEB_BWA.Controllers
{
    public class Cart
    {
        private Product product = new Product();
        private int quantity;

        public Product Product
        {
            get
            {
                return product;
            }

            set
            {
                product = value;
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
            this.Product = Product;
            this.Quantity = qty;
        }

        public Product 

    }
}