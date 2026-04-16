using MakeupAPI.Models;

namespace MakeupAPI.Data
{
    public static class ProductData
    {
        public static List<Product> Products = new List<Product>
        {
            new Product { 
                Id = 1, 
                Name = "Maybelline Fit Me",
                Category = "Foundation",
                Price = 599, 
                Quantity = 10 },
            new Product { 
                Id = 2, 
                Name = "Lakme Blush", 
                Category = "Blush", 
                Price = 450, 
                Quantity = 15 },
            new Product { 
                Id = 3, 
                Name = "MAC Lipstick", 
                Category = "Lipstick", 
                Price = 1200, 
                Quantity = 50 },
            new Product { 
                Id = 4, 
                Name = "NARS Blush", 
                Category = "Blush", 
                Price = 1500, 
                Quantity = 80 },
            new Product { Id = 5, 
            Name = "Dior Lipstick", 
            Category = "Lipstick", 
            Price = 2000, 
            Quantity = 30 },
            new Product { 
                Id = 6, 
                Name = "Miss DIor ", 
                Category = "Perfume", 
                Price = 5599, 
                Quantity = 10 },
            new Product { 
                Id = 7, 
                Name = "Lakme Masqara", 
                Category = "Masqara", 
                Price = 460, 
                Quantity = 15 },
            new Product { 
                Id = 8, 
                Name = "Swiss Beauty Lipstick", 
                Category = "Lipstick", 
                Price = 120, 
                Quantity = 500 }
        };
    }
}