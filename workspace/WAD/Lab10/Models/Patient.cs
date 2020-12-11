using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lab10.Models
{
    [Table("Patient")]
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [Display(Name = "Ten benh nhan")]
        public string patientname { get; set; }

        [Required]
        [Display(Name = "Tuoi ben nhan")]
        public int age { get; set; }

        [Required]
        [Display(Name = "Dia chi")]
        public string address { get; set; }
        
        [Required]
        [Display(Name = "Ngay nhap vien")]
        public DateTime joindate { get; set; }

        [Required]
        [Display(Name = "Benh ly")]
        public string pathological { get; set; }

    }
}
