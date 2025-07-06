Using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RetailInventoryLab6
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
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RetailInventoryLab6Db;Trusted_Connection=True;");
        }
    }

    //  Main Program
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new RetailDbContext();
            context.Database.EnsureCreated();

            //  Insert sample data if empty
            if (!context.Products.Any())
            {
                context.Products.AddRange(new List<Product>
                {
                    new Product { Name = "Laptop", Price = 490000, Stock = 150 },
                    new Product { Name = "Mouse", Price = 500, Stock = 100 },
                    new Product { Name = "Keyboard", Price = 1500, Stock = 50 }
                });
                context.SaveChanges();
                Console.WriteLine(" Sample data inserted.");
            }

            Console.WriteLine("\n Initial Products:");
            DisplayProducts(context);

            //  Update: Increase stock of "Mouse" by 50
            var mouse = context.Products.FirstOrDefault(p => p.Name == "Mouse");
            if (mouse != null)
            {
                mouse.Stock += 50;
                context.SaveChanges();
                Console.WriteLine($"\n Updated stock for Mouse to {mouse.Stock}");
            }

            //  Delete: Remove "Keyboard"
            var keyboard = context.Products.FirstOrDefault(p => p.Name == "Keyboard");
            if (keyboard != null)
            {
                context.Products.Remove(keyboard);
                context.SaveChanges();
                Console.WriteLine("\nDeleted product: Keyboard");
            }

            Console.WriteLine("\nFinal Product List After Update & Delete:");
            DisplayProducts(context);
        }

        static void DisplayProducts(RetailDbContext context)
        {
            var products = context.Products.ToList();
            foreach (var p in products)
            {
                Console.WriteLine($" {p.Name} - ₹{p.Price} ({p.Stock} in stock)");
            }
        }
    }
}