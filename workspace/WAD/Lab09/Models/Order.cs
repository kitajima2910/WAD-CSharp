using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lab09.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public DateTime orderdate { get; set; }

        public string customerid { get; set; }

        public string productname { get; set; }

        public int quantity { get; set; }

        public decimal price { get; set; }

        public decimal subtotal 
        { 
            get
            {
                return price * quantity;
            }
        }
    }
}
