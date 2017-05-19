using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_WEB_BWA.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public int Quantity { get; set; }
        public int ItemPrice { get; set; }
        public int sellingPrice { get; set; }
        public byte[] productImage { get; set; }
    }
}