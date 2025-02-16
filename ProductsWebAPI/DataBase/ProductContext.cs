using Microsoft.EntityFrameworkCore;
using ProductsWebAPI.Model;
using System;

namespace ProductsWebAPI.DataBase
{
    public class ProductContext(DbContextOptions<ProductContext> options) : DbContext(options)
    {
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(c => c.Id);
        }
    }
}
