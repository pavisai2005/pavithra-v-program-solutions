using System;
using System.Collections.Generic;
using System.Linq; // Required for LINQ extensions like Where, ToList

// 1. Define the Product Class
public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    public int StockQuantity { get; set; }

    public Product(int id, string name, string description, decimal price, string category, int stock)
    {
        ProductId = id;
        Name = name;
        Description = description;
        Price = price;
        Category = category;
        StockQuantity = stock;
    }

    public void DisplayProduct()
    {
        Console.WriteLine($"ID: {ProductId}, Name: {Name}, Price: {Price:C}, Category: {Category}, Stock: {StockQuantity}");
        Console.WriteLine($"  Description: {Description}");
    }
}

// 2. E-commerce Platform Search Functionality
public class ECommerceSearch
{
    private List<Product> _products;

    public ECommerceSearch(List<Product> products)
    {
        _products = products;
    }

    // Main search method that can take various parameters
    public List<Product> SearchProducts(
        string searchTerm = null,
        string category = null,
        decimal? minPrice = null,
        decimal? maxPrice = null,
        bool inStockOnly = false)
    {
        // Start with all products
        IEnumerable<Product> results = _products;

        // Apply search term filter (case-insensitive)
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            results = results.Where(p =>
                p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                p.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        // Apply category filter (case-insensitive)
        if (!string.IsNullOrWhiteSpace(category))
        {
            results = results.Where(p =>
                p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
        }

        // Apply minimum price filter
        if (minPrice.HasValue)
        {
            results = results.Where(p => p.Price >= minPrice.Value);
        }

        // Apply maximum price filter
        if (maxPrice.HasValue)
        {
            results = results.Where(p => p.Price <= maxPrice.Value);
        }

        // Apply in-stock filter
        if (inStockOnly)
        {
            results = results.Where(p => p.StockQuantity > 0);
        }

        return results.ToList(); // Convert the filtered results back to a List
    }

    // Helper method to display search results
    public void DisplaySearchResults(List<Product> results)
    {
        if (results == null || !results.Any())
        {
            Console.WriteLine("No products found matching your criteria.");
            return;
        }

        Console.WriteLine($"Found {results.Count} product(s):");
        foreach (var product in results)
        {
            product.DisplayProduct();
            Console.WriteLine("--------------------");
        }
    }
}

// 3. Main Program to demonstrate the search function
public class Program
{
    public static void Main(string[] args)
    {
        // Populate some sample products
        List<Product> availableProducts = new List<Product>
        {
            new Product(1, "Laptop Pro", "Powerful laptop for professionals.", 1200.00m, "Electronics", 15),
            new Product(2, "Gaming Mouse X", "High precision gaming mouse.", 55.99m, "Electronics", 50),
            new Product(3, "Mechanical Keyboard", "Durable keyboard with tactile keys.", 99.50m, "Electronics", 0), // Out of stock
            new Product(4, "Coffee Maker Deluxe", "Brew perfect coffee every time.", 75.00m, "Home Appliances", 20),
            new Product(5, "Blender 2000", "High-speed blender for smoothies.", 120.00m, "Home Appliances", 10),
            new Product(6, "Wireless Earbuds", "Noise-cancelling wireless earbuds.", 150.00m, "Electronics", 30),
            new Product(7, "Smart Speaker Mini", "Voice-controlled smart speaker.", 49.99m, "Electronics", 0), // Out of stock
            new Product(8, "Adventure Backpack", "Durable backpack for hiking.", 85.00m, "Outdoor", 25)
        };

        ECommerceSearch searchEngine = new ECommerceSearch(availableProducts);

        Console.WriteLine("--- Search Scenario 1: Search by term 'laptop' ---");
        List<Product> results1 = searchEngine.SearchProducts(searchTerm: "laptop");
        searchEngine.DisplaySearchResults(results1);

        Console.WriteLine("\n--- Search Scenario 2: Search by category 'Electronics' and in stock ---");
        List<Product> results2 = searchEngine.SearchProducts(category: "Electronics", inStockOnly: true);
        searchEngine.DisplaySearchResults(results2);

        Console.WriteLine("\n--- Search Scenario 3: Search by price range ($50 - $100) ---");
        List<Product> results3 = searchEngine.SearchProducts(minPrice: 50.00m, maxPrice: 100.00m);
        searchEngine.DisplaySearchResults(results3);

        Console.WriteLine("\n--- Search Scenario 4: Search for 'mouse' in 'Electronics' category ---");
        List<Product> results4 = searchEngine.SearchProducts(searchTerm: "mouse", category: "Electronics");
        searchEngine.DisplaySearchResults(results4);

        Console.WriteLine("\n--- Search Scenario 5: Search for 'smart' and in stock ---");
        List<Product> results5 = searchEngine.SearchProducts(searchTerm: "smart", inStockOnly: true);
        searchEngine.DisplaySearchResults(results5); // Should find nothing as Smart Speaker is out of stock

        Console.WriteLine("\n--- Search Scenario 6: Search for an non-existent product ---");
        List<Product> results6 = searchEngine.SearchProducts(searchTerm: "XYZ Product");
        searchEngine.DisplaySearchResults(results6);
    }
}