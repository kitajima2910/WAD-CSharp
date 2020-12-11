using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab10.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions dbContext) : base(dbContext)
        {

        }

        public DbSet<Patient> Patients { get; set; }
    }
}
