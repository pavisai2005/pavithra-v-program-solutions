using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RetailInventoryEFCLILab
{
    //  Model
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }

    //  DbContext
    public class RetailDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //  SQL Server LocalDB connection
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RetailInventoryLab3Db;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  Seed Data
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Laptop", Price = 480000, Stock = 20 },
                new Product { ProductId = 2, Name = "Mouse", Price = 1500, Stock = 200 },
                new Product { ProductId = 3, Name = "Keyboard", Price = 10000, Stock = 500 }
            );
        }
    }

    //  Program Entry
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new RetailDbContext();
            context.Database.EnsureCreated();

            Console.WriteLine(" Product Inventory:");
            foreach (var product in context.Products)
            {
                Console.WriteLine($"{product.Name} - ₹{product.Price} ({product.Stock} in stock)");
            }
        }
    }
}