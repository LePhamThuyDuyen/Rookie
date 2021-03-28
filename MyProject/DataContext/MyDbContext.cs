using Microsoft.EntityFrameworkCore;
using MyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.DataContext
{
    public class MyDbContext : DbContext

    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<Product> products { get; set; }

        public DbSet<Category> categories { get; set; }
    }
}
