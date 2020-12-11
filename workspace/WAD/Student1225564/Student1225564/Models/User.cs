using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Student1225564.Models
{
    [Table("tbUsers")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Address from 6 to 50")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"^\w{1,}@\w{2,}(.\w{2,}){1,2}$", ErrorMessage = "Email is formal")]
        public string Email { get; set; }

        public bool isAdmin { get; set; }
    }
}
