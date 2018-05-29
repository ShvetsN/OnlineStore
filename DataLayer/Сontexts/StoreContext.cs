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
                WithMany(c => c.Products).HasForeignKey(c => c.CategoryId); //.OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ProductOrder>()
            .HasKey(t => t.Id);

            modelBuilder.Entity<ProductOrder>()
                .HasOne(sc => sc.Order)
                .WithMany(s => s.Products)
                .HasForeignKey(sc => sc.OrderId);

            modelBuilder.Entity<ProductOrder>()
                .HasOne(sc => sc.Product)
                .WithMany(s => s.Orders)
                .HasForeignKey(sc => sc.ProductId);

            modelBuilder.Entity<Category>().HasKey(c => c.Id);
        }
    }
}
