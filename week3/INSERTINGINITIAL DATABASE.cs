using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RetailInventoryLab4
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
            //  SQL Server Connection
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RetailInventoryLab4Db;Trusted_Connection=True;");
        }
    }

    //  Program Entry
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new RetailDbContext();
            context.Database.EnsureCreated();

            //  Check if database is empty
            if (!context.Products.Any())
            {
                var initialProducts = new List<Product>
                {
                    new Product { Name = "Monitor", Price = 19000, Stock = 150 },
                    new Product { Name = "Printer", Price = 8000, Stock = 18 },
                    new Product { Name = "Webcam", Price = 2900, Stock = 29 }
                };

                //  Add data
                context.Products.AddRange(initialProducts);
                context.SaveChanges();

                Console.WriteLine(" Initial data inserted");
            }
            else
            {
                Console.WriteLine(" Data already exists. Skipping insertion.");
            }

            // Display all products
            Console.WriteLine("\n Current Products in Inventory:");
            foreach (var product in context.Products)
            {
                Console.WriteLine($"{product.Name} - ₹{product.Price} ({product.Stock} in stock)");
            }
        }
    }
}