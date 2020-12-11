﻿using Lab03.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab03.Repository
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }
        public DbSet<Account> Accounts { get; set; }
    }
}
