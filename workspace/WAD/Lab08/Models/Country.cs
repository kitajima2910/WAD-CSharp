using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lab08.Models
{
    [Table("Country")]
    public class Country
    {
        [Key]
        public string idCode { get; set; }

        [Required]
        public string countryName { get; set; }

        [Required]
        public string languageCode { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
