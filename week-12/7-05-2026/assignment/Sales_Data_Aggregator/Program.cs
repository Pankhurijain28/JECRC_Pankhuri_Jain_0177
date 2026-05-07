using System;
using System.Collections.Generic;
using System.Linq;

class Sale
{
    public string ProductId { get; set; }
    public string Region { get; set; }
    public int Amount { get; set; }
}

class Program
{
    static void Main()
    {
        // Sales data
        List<Sale> sales = new List<Sale>
        {
            new Sale { ProductId = "P001", Region = "North", Amount = 1500 },
            new Sale { ProductId = "P001", Region = "South", Amount = 2000 },
            new Sale { ProductId = "P002", Region = "North", Amount = 3000 },
            new Sale { ProductId = "P001", Region = "East", Amount = 2500 },
            new Sale { ProductId = "P002", Region = "South", Amount = 1800 },
            new Sale { ProductId = "P003", Region = "North", Amount = 1200 },
            new Sale { ProductId = "P001", Region = "West", Amount = 2200 },
            new Sale { ProductId = "P002", Region = "West", Amount = 2800 },
            new Sale { ProductId = "P003", Region = "South", Amount = 900 },
            new Sale { ProductId = "P002", Region = "East", Amount = 3200 }
        };

        int threshold = 2000;

        Console.WriteLine("--- Sales Report by Product and Region ---\n");

        // -------------------------------
        // Group sales by Product
        // -------------------------------
        var productGroups = sales.GroupBy(s => s.ProductId);

        foreach (var product in productGroups)
        {
            Console.WriteLine($"Product {product.Key}:\n");

            foreach (var sale in product)
            {
                Console.WriteLine($"  {sale.Region}: ${sale.Amount}");
            }

            int total = product.Sum(x => x.Amount);
            double average = product.Average(x => x.Amount);
            int min = product.Min(x => x.Amount);
            int max = product.Max(x => x.Amount);

            Console.WriteLine($"\n  Total: ${total}, Average: ${average:F2}");
            Console.WriteLine($"  Min: ${min}, Max: ${max}\n");
        }

        // -------------------------------
        // Best Selling Product by Region
        // -------------------------------
        Console.WriteLine("Best Selling Product by Region:\n");

        var regionGroups = sales.GroupBy(s => s.Region);

        foreach (var region in regionGroups)
        {
            var bestProduct = region
                .OrderByDescending(x => x.Amount)
                .First();

            Console.WriteLine($"{region.Key}: {bestProduct.ProductId} (${bestProduct.Amount})");
        }

        // -------------------------------
        // Underperforming Products
        // -------------------------------
        Console.WriteLine($"\nUnderperforming Products (< ${threshold} average):\n");

        foreach (var product in productGroups)
        {
            double avg = product.Average(x => x.Amount);

            if (avg < threshold)
            {
                Console.WriteLine($"{product.Key} (${avg:F2})");
            }
        }
    }
}