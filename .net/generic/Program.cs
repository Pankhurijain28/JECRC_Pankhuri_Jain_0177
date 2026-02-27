
//20 feb
//generic collection
//generic interface
// using System;
// namespace GenericDemo
// {
//     class UsingGenerics<T>
// {
//     T obj;
//     public UsingGenerics(T obj1)
//     {
//         this.obj = obj1;
//     }
//     public T Get(){
//         return obj;
//     }
//     public void ShowType(){
//         Console.WriteLine("Type of t is:"+ typeof(T));
//     }
// }}
// class TestGenerics
// {
//     public static void Main(string[] args)
//     {
//         UsingGenerics<int> objdata;
//         objdata = new UsingGenerics<int>(500);
//         objdata.ShowType();
//         UsingGenerics<string> objdatastr;
//         objdatastr = new UsingGenerics <string>("Pankhuri");
//         objdata.ShowType();
//     }
// }

// using System;

// namespace GenericDemo
// {
//     class UsingGenerics<T>
//     {
//         T obj;

//         public UsingGenerics(T obj1)
//         {
//             this.obj = obj1;
//         }

//         public T Get()
//         {
//             return obj;
//         }

//         public void ShowType()
//         {
//             Console.WriteLine("Type of T is: " + typeof(T));
//         }
//     }

//     class TestGenerics
//     {
//         public static void Main(string[] args)
//         {
//             UsingGenerics<int> objdata;
//             objdata = new UsingGenerics<int>(500);
//             objdata.ShowType();

//             UsingGenerics<string> objdatastr;
//             objdatastr = new UsingGenerics<string>("Pankhuri");
//             objdatastr.ShowType();

//             Console.ReadLine();
//         }
//     }
// }

//2nd code

// using System;
// using System.Collections.Generic;

// namespace ProductDemo
// {
//     public class Product
//     {
//         public int Id { get; set; }
//         public string Name { get; set; }
//         public string Description { get; set; }
//         public double Price { get; set; }
//         public bool IsStock { get; set; }
//     }

//     public class ProductCatalog
//     {
//         private List<Product> products;

//         public ProductCatalog()
//         {
//             products = new List<Product>
//             {
//                 new Product { Id = 100, Name = "Laptop", Description = "Electronics", Price = 75000, IsStock = true },
//                 new Product { Id = 101, Name = "Phone", Description = "Electronics", Price = 5000, IsStock = true },
//                 new Product { Id = 102, Name = "Watch", Description = "Electronics", Price = 2000, IsStock = true },
//                 new Product { Id = 103, Name = "MacBook", Description = "Electronics", Price = 100000, IsStock = true }
//             };
//         }

//         public void DisplayProducts()
//         {
//             foreach (var product in products)
//             {
//                 Console.WriteLine("Name: " + product.Name);
//                 Console.WriteLine("Description: " + product.Description);
//                 Console.WriteLine("Price: ₹" + product.Price);
//                 Console.WriteLine("---------------------------");
//             }
//         }
//     }

//     class TestProduct
//     {
//         static void Main(string[] args)
//         {
//             ProductCatalog catalog = new ProductCatalog();
//             catalog.DisplayProducts();

//             Console.ReadLine();
//         }
//     }
// }


using System;
using System.Collections.Generic;
using System.Linq;
namespace ProductDemo{
    public class Product{
        public int Id{ get; set; }
        public string Name{ get; set; }
        public string Description{ get; set; }
        public double Price{ get; set; }
        public bool IsStock{ get; set; }
    } 
    public class ProductCatalog
    {
        private List<Product> products;

        public ProductCatalog()
        {
            // products = new List<Product>{
            //     new Product {Id=100, Name= "Laptop", Description ="Electronics", Price = 75000, IsStock= true},
            //     new Product {Id=100, Name= "phone", Description ="Electronics", Price = 5000, IsStock= true},
            //     new Product {Id=100, Name= "watch", Description ="Electronics", Price = 2000, IsStock= true},
            //     new Product {Id=100, Name= "macbook", Description ="Electronics", Price = 100000, IsStock= true},

            // };
            products = new List<Product>();

        }
        public void AddProduct()
        {
            Product product = new Product();
            Console.WriteLine("Enter Product ID:");
            product.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Product Name:");
            product.Name = Console.ReadLine();
            Console.WriteLine("Enter Product Description:");
            product.Description = Console.ReadLine();
            Console.WriteLine("Enter Product Price:");
            product.Price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Product IsStock:");
            product.IsStock = Convert.ToBoolean(Console.ReadLine());
            products.Add(product);
        }
        public bool DeleteProduct(int id){
            var productid= products.FirstOrDefault(p=> p.Id == id);
            if (productid != null){
                products.Remove(productid);
                return true;
            }
        return true;
        }

        public void DisplayProducts(){
            foreach(var product in products)
            {
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Description);
                Console.WriteLine(product.Price);

            }
        }
    }
    class TestProduct{
        static void Main(string[] args){
            ProductCatalog catalog = new ProductCatalog();
            int choice;

            do{
                Console.WriteLine("\n 1. Add Product");
                Console.WriteLine("\n 2. Display Product");
                Console.WriteLine("\n 3. EXIT ");
                Console.WriteLine("\n  Enter your choices");
                choice= Convert.ToInt32( Console.ReadLine());
                switch(choice){
                case 1: 
                    catalog.AddProduct();
                    break;
                case 2:
                    catalog.DisplayProducts();
                    break;
                case 3:
                    Console.WriteLine("Exiting.....");
                    break;
                case 4:
                    Console.WriteLine("Enter ID to delete:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    bool result = catalog.DeleteProduct(id);

                     if(result)
                        Console.WriteLine("Product Deleted Successfully");
                    else
                        Console.WriteLine("Product Not Found");

                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
                }
            }while(choice !=3);

            // catalog.AddProduct();
            // catalog.DisplayProducts();
        }
    }
}

