using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RetailInventoryLab7
{
    //  Product Model
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
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RetailInventoryLab7Db;Trusted_Connection=True;");
        }
    }

    //  Main Program
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new RetailDbContext();
            context.Database.EnsureCreated();

            //  Seed data if table is empty
            if (!context.Products.Any())
            {
                context.Products.AddRange(new List<Product>
                {
                    new Product { Name = "Laptop", Price = 480000, Stock = 150 },
                    new Product { Name = "Mouse", Price = 1500, Stock = 100 },
                    new Product { Name = "Keyboard", Price = 1000, Stock = 50 },
                    new Product { Name = "Monitor", Price = 12000, Stock = 20 },
                    new Product { Name = "Printer", Price = 9000, Stock = 15 }
                });
                context.SaveChanges();
                Console.WriteLine(" Sample data inserted.\n");
            }

            //  1. All Products
            Console.WriteLine(" All Products:");
            context.Products.ToList().ForEach(p =>
                Console.WriteLine($" {p.Name} - ₹{p.Price} ({p.Stock} in stock)"));

            //  2. Products with Price > ₹1000
            Console.WriteLine("\n Products Priced Over ₹1000:");
            var expensive = context.Products.Where(p => p.Price > 1000).ToList();
            expensive.ForEach(p => Console.WriteLine($"{p.Name} - ₹{p.Price}"));

            //  3. Products Ordered by Price (Ascending)
            Console.WriteLine("\n Products Ordered by Price:");
            var sorted = context.Products.OrderBy(p => p.Price).ToList();
            sorted.ForEach(p => Console.WriteLine($" {p.Name} - ₹{p.Price}"));

            //  4. Select Name + Stock Only
            Console.WriteLine("\n Name and Stock Only:");
            var nameStock = context.Products.Select(p => new { p.Name, p.Stock }).ToList();
            nameStock.ForEach(p => Console.WriteLine($"{p.Name} ({p.Stock} units)"));

            //  5. Group by Stock Range
            Console.WriteLine("\n Grouped by Stock Level:");
            var stockGroups = context.Products
                .GroupBy(p => p.Stock >= 50 ? "High Stock" : "Low Stock")
                .ToList();

            foreach (var group in stockGroups)
            {
                Console.WriteLine($"\n {group.Key}:");
                foreach (var p in group)
                {
                    Console.WriteLine($"    {p.Name} ({p.Stock})");
                }
            }
        }
    }
}