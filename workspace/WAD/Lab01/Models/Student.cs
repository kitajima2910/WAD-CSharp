using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab01.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string StudentId { get; set; }

        [Required(ErrorMessage = "Student name is required...")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Address name is required...")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Address from 2 to 100 characters")]
        public string Address { get; set; }

        public DateTime JoinDate { get; set; }
    }
}