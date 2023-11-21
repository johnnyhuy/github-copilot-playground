using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Apple", Price = 1.00m },
            new Product { Id = 2, Name = "Banana", Price = 0.50m },
            new Product { Id = 3, Name = "Cherry", Price = 0.75m }
        };

        var filteredProducts = products.Where(p => p.Price < 1.00m)
                                       .OrderBy(p => p.Name)
                                       .ToList();

        foreach (var product in filteredProducts)
        {
            Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");
        }
    }
}