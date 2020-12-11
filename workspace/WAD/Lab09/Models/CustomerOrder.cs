using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab09.Models
{
    [Table("vCustomerOrder")]
    public class CustomerOrder
    {
        public int id { get; set; }

        public DateTime orderdate { get; set; }

        public string customername { get; set; }

        public string customeraddress { get; set; }

        public string customerphone { get; set; }

        public int quantity { get; set; }

        public decimal price { get; set; }

        public string customerid { get; set; }

        public decimal subtotal
        {
            get
            {
                return price * quantity;
            }
        }
    }
}
