using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RetailInventoryLab5
{
    //  Model: Product
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
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RetailInventoryLab5Db;Trusted_Connection=True;");
        }
    }

    //  Program Start
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new RetailDbContext();
            context.Database.EnsureCreated();

            //  Insert sample data if table is empty
            if (!context.Products.Any())
            {
                context.Products.AddRange(new List<Product>
                {
                    new Product { Name = "Laptop", Price = 49000, Stock = 150 },
                    new Product { Name = "Mouse", Price = 500, Stock = 100 },
                    new Product { Name = "Keyboard", Price = 1500, Stock = 50 },
                    new Product { Name = "Monitor", Price = 12000, Stock = 20 }
                });
                context.SaveChanges();
                Console.WriteLine(" Sample data inserted.");
            }

            Console.WriteLine("\n All Products:");
            var allProducts = context.Products.ToList();
            foreach (var p in allProducts)
            {
                Console.WriteLine($" {p.Name} - ₹{p.Price} ({p.Stock} in stock)");
            }

            Console.WriteLine("\n Products priced over ₹1000:");
            var expensiveProducts = context.Products.Where(p => p.Price > 1000).ToList();
            foreach (var p in expensiveProducts)
            {
                Console.WriteLine($" {p.Name} - ₹{p.Price}");
            }

            Console.WriteLine("\n Products sorted by price (descending):");
            var sortedProducts = context.Products.OrderByDescending(p => p.Price).ToList();
            foreach (var p in sortedProducts)
            {
                Console.WriteLine($" {p.Name} - ₹{p.Price}");
            }
        }
    }
}