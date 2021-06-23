using Microsoft.EntityFrameworkCore;
using MUSACA.Data.Models;
using System;

namespace MUSACA.Data
{
   public class ApplicationDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=MUSACA;Integrated Security=true");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
    }
}
