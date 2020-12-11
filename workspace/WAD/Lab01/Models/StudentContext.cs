using System.Data.Entity;

namespace Lab01.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext() : base("Lab01Conn")
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}