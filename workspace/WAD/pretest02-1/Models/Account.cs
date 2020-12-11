using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pretest02_1.Models
{
    [Table("Account")]
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

        public bool role { get; set; }
    }
}
