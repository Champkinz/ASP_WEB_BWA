using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_WEB_BWA.Models
{
    public class Order_info
    {
        public Order_info()
            {
            Expiry_Date = DateTime.Now;
            }
            [Key]
            public int orderid { get; set; }
            public int Total { get; set; }
            public int Product_ID { get; set; }
            public string Product_Type { get; set; }
            public string Product_Name { get; set; }
            public int Quantity { get; set; }
            public string Full_Name { get; set; }
            public string Username { get; set; }
            public string Address { get; set; }
            public string CardType { get; set; }
            public string CreditCardNo { get; set; }
            public string CVC { get; set; }
            public DateTime Expiry_Date { get; set ; }
    }
}