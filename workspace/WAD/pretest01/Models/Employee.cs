using Microsoft.AspNetCore.Mvc;
using pretest01.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pretest01.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "EmpID khong duoc rong")]
        public int? EmpID { get; set; }

        [Required(ErrorMessage = "EmpName khong duoc rong")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Ten nhan vien tu 6 den 20 ky tu")]
        public string EmpName { get; set; }

        [Required(ErrorMessage = "EmpAge khong duoc rong")]
        [Range(16, 60, ErrorMessage = "Tuoi nhan vien tu 18 den 60")]
        //[NumericInteger(ErrorMessage = "Khong dung dinh dang so")]
        [RegularExpression(@"[0-9]*$", ErrorMessage = "Some message if value entered isn't number")]
        public int? EmpAge { get; set; }

        [Required(ErrorMessage = "EmpAddress khong duoc rong")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Ten nhan vien tu 6 den 50 ky tu")]
        public string EmpAddress { get; set; }

        [Required(ErrorMessage = "EmpEmail khong duoc rong")]
        [RegularExpression(@"^\w+@\w{2,}(.\w{2,}){1,2}$", ErrorMessage = "Dia chi email khong hop le")]
        public string EmpEmail { get; set; }
    }
}
