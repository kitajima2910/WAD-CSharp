namespace Lab02.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CourseContext : DbContext
    {
        public CourseContext()
            : base("name=CourseContext")
        {
        }

        public virtual DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .Property(e => e.CourseName)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.Duration)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.Fee)
                .HasPrecision(18, 0);
        }
    }
}
