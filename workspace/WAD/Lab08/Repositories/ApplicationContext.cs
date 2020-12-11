using Lab08.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab08.Repositories
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions dbContext) : base(dbContext)
        {

        }

        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
    }
}
