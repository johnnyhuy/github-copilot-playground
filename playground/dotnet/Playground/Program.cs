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
        // TODO: Create a list of 10 exotic fruit products priced at less than $20.00
        var

        // TODO: Filter the list of products to only those priced at less than $5.00

        foreach (var product in filteredProducts)
        {
            Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");
        }
    }
}