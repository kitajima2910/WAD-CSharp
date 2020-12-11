using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pretest01_1.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmpID { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string EmpName { get; set; }

        [Required]
        [Range(16, 60)]
        public int EmpAge { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        [DataType(DataType.MultilineText)]
        public string EmpAddress { get; set; }

        [Required]
        [RegularExpression(@"^\w{1,}@\w{2,}(.\w{2,}){1,2}$")]
        public string EmpEmail { get; set; }
    }
}
