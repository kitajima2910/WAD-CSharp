using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lab07.Models
{
    [Table("Computer")]
    public class Computer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "ComputerName is required...")]
        public string ComputerName { get; set; }

        [Required(ErrorMessage = "Description is required...")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Currency is required...")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string Photo { get; set; }


    }
}
