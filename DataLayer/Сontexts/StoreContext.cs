using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;

namespace DataLayer.Contexts
{
    public class StoreContext: DbContext

    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasOne(c => c.Category).
                WithMany(c => c.Products).HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<ProductOrder>()
           .HasKey(t => new { t.ProductId, t.OrderId });

            modelBuilder.Entity<ProductOrder>().HasOne(c => c.Product).
                WithMany(c => c.Orders).HasForeignKey(c => c.OrderId);

            modelBuilder.Entity<ProductOrder>().HasOne(c => c.Order).
                WithMany(c => c.Products).HasForeignKey(c => c.ProductId);
        }
    }
}
