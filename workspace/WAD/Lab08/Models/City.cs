using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lab08.Models
{
    [Table("City")]
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string cityName { get; set; }

        [Required]
        public int cityPopulation { get; set; }

        [Required]
        public decimal cityArea { get; set; }
        public string idCode { get; set; }

        [ForeignKey("idCode")]
        public Country Country { get; set; }
    }
}
