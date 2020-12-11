namespace Lab02.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string CourseName { get; set; }

        [Required]
        [StringLength(50)]
        public string Duration { get; set; }

        public decimal? Fee { get; set; }
    }
}
