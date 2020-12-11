using Lab09.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab09.Repositories
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions dbContext) : base(dbContext)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
    }
}
