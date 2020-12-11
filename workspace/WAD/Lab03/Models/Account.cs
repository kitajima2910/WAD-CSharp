using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lab03.Models
{
    [Table("Account")]
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string AccountNo { get; set; }

        [Required(ErrorMessage = "Name is required...")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Name is invalid")]
        public string AccountName { get; set; }

        [Required(ErrorMessage = "PinCode is required...")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "PinCode is invalid")]
        [DataType(DataType.Password)]
        public string PinCode { get; set; }

        [Required(ErrorMessage = "Address is required...")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Address is invalid")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Range(2, 100000, ErrorMessage = "Balance is invalid")]
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        public bool IsAdmin { get; set; }

    }
}
