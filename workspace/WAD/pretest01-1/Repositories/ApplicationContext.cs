using Microsoft.EntityFrameworkCore;
using pretest01_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pretest01_1.Repositories
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions dbContext) : base(dbContext)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
