using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lab09.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string customerid { get; set; }

        [Required]
        public string customername { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Address from 2 to 50 characters!")]
        public string customeraddress { get; set; }

        [Required]
        public string customerphone { get; set; }
    }
}
