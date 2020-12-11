using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pretest02.Models
{
    [Table("Employees")]
    public class Employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int EmpID { get; set; }

        [Required]
        public DateTime EmpDoB { get; set; }

        [Required]
        public string EmpName { get; set; }

        [Required]
        public string EmpAddress { get; set; }

        [Required]
        public string EmpEmail { get; set; }
    }
}
