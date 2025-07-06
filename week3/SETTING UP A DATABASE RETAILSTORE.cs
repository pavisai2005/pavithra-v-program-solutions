using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RetailInventoryWithMigrations
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }

    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; } = "";
        public string City { get; set; } = "";
    }

    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem>? Items { get; set; }
    }

    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
    }

    public class RetailDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RetailInventoryDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Laptop", Price = 480000, Stock = 20 },
                new Product { ProductId = 2, Name = "Mouse", Price = 1500, Stock = 200 },
                new Product { ProductId = 3, Name = "Keyboard", Price = 10000, Stock = 500 }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, Name = "Anu", City = "Chennai" },
                new Customer { CustomerId = 2, Name = "Pav", City = "krishnagiri" }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, CustomerId = 1, OrderDate = DateTime.Now.AddDays(-2) },
                new Order { OrderId = 2, CustomerId = 2, OrderDate = DateTime.Now.AddDays(-10) }
            );

            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { OrderItemId = 1, OrderId = 1, ProductId = 1, Quantity = 1 },
                new OrderItem { OrderItemId = 2, OrderId = 1, ProductId = 2, Quantity = 2 },
                new OrderItem { OrderItemId = 3, OrderId = 2, ProductId = 3, Quantity = 3 }
            );
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using var context = new RetailDbContext();
            context.Database.EnsureCreated();

            Console.WriteLine(" Products:");
            foreach (var product in context.Products)
                Console.WriteLine($" {product.Name} - ₹{product.Price} (Stock: {product.Stock})");

            Console.WriteLine("\n Customers:");
            foreach (var customer in context.Customers)
                Console.WriteLine($" {customer.Name} - {customer.City}");

            Console.WriteLine("\n Orders:");
            var orders = context.Orders.Include(o => o.Customer).ToList();
            foreach (var order in orders)
                Console.WriteLine($"Order #{order.OrderId} by {order.Customer?.Name} on {order.OrderDate.ToShortDateString()}");

            Console.WriteLine("\n Quantity Sold:");
            var orderItems = context.OrderItems
                .GroupBy(oi => oi.ProductId)
                .Select(g => new
                {
                    Product = context.Products.Find(g.Key),
                    Total = g.Sum(x => x.Quantity)
                });

            foreach (var item in orderItems)
                Console.WriteLine($"{item.Product?.Name}: {item.Total} sold");
        }
    }
}