// using System;
// class Program
// {
//     static void Main(string[] args)
//     {
//         int[] Sarray = new int[5] {85, 90, 78, 92, 88};
//         Array.Sort(Sarray);
//         foreach (int value in Sarray)
//         {
//             Console.WriteLine(value);
//         }
//     }
// }




// using System;

// namespace ConsoleApp
// {
//     class Employee
//     {
//         public string Name { get; set; }
//         public int Id { get; set; }
//         public string Department { get; set; }
//         public int Salary { get; set; }
//         public string Position { get; set; }
//         public DateTime DateOfJoining { get; set; }

//         public void GetEmployeeData()
//         {
//             Console.Write("Enter Employee Name: ");
//             Name = Console.ReadLine();

//             Console.Write("Enter Employee Id: ");
//             Id = Convert.ToInt32(Console.ReadLine());

//             Console.Write("Enter Employee Department: ");
//             Department = Console.ReadLine();

//             Console.Write("Enter Employee Salary: ");
//             Salary = Convert.ToInt32(Console.ReadLine());

//             Console.Write("Enter Employee Position: ");
//             Position = Console.ReadLine();

//             Console.Write("Enter Employee Date Of Joining (dd-MM-yyyy): ");
//             DateOfJoining = DateTime.Parse(Console.ReadLine());
//         }

//         public void DisplayEmployeeData()
//         {
//             Console.WriteLine("\n--- Employee Details ---");
//             Console.WriteLine($"Name: {Name}");
//             Console.WriteLine($"Id: {Id}");
//             Console.WriteLine($"Department: {Department}");
//             Console.WriteLine($"Salary: {Salary}");
//             Console.WriteLine($"Position: {Position}");
//             Console.WriteLine($"Date Of Joining: {DateOfJoining.ToShortDateString()}");
//         }
//     }

//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Employee emp = new Employee();
//             emp.GetEmployeeData();
//             emp.DisplayEmployeeData();
//         }
//     }
// }



// using System;

// class ODLExamplel
// {
//     public static void Main(){
//       string[] stringArray= new string[5] { "Csharp", "ASP.net", "EntityFramework", "ADO.net", "WCF" };  
//       Array.Sort(stringArray);
//       foreach (string str in stringArray)
//         {
//             Console.Write(str + " ");
//          }
//     }
     

// }

// using System;
// class ODlExercise{
//     int a= 10;
//     int b= 20;
//     public void addition(){
//         int sum= a+b;
//         Console.Write("Sum =" +sum);
//         }
//     public void substraction(){
//         int sub= a-b;
//         Console.Write();
//         }
//     public void multiply(){
//         int multi= a*b;
//         Console.Write();
//         }
//     public void division(){
//         int div= a/b;
//         Console.Write();
//         }

// }

// using System;

// class ODLExercise
// {
//     int num1;
//     int num2;

//     // Constructor to take input
//     public ODLExercise()
//     {
//         Console.Write("Enter first number: ");
//         num1 = Convert.ToInt32(Console.ReadLine());

//         Console.Write("Enter second number: ");
//         num2 = Convert.ToInt32(Console.ReadLine());
//     }

//     public void Addition()
//     {
//         int sum = num1 + num2;
//         Console.WriteLine("The sum of {0} and {1} is: {2}", num1, num2, sum);
//     }

//     public void Subtraction()
//     {
//         int difference = num1 - num2;
//         Console.WriteLine("The difference between {0} and {1} is: {2}", num1, num2, difference);
//     }

//     public void Multiplication()
//     {
//         int product = num1 * num2;
//         Console.WriteLine("The product of {0} and {1} is: {2}", num1, num2, product);
//     }

//     public void Division()
//     {
//         if (num2 != 0)
//         {
//             double quotient = (double)num1 / num2;
//             Console.WriteLine("The quotient of {0} divided by {1} is: {2}", num1, num2, quotient);
//         }
//         else
//         {
//             Console.WriteLine("Division by zero is not allowed.");
//         }
//     }
// }

// class Demo
// {
//     public static void Main()
//     {
//         ODLExercise exercise = new ODLExercise();

//         exercise.Addition();
//         exercise.Subtraction();
//         exercise.Multiplication();
//         exercise.Division();

//         Console.ReadLine(); // keeps console open
//     }
// }

// using System;
// class ODLExercise{
//     private static int number;
//     public static int Number{ get{return number;}}
//         static ODL
//         Exercise(){
//             Random r = new Random();
//             number = r.Next();
//         }
// }

// class Program{
//     static void Main(string[]args)
//     {
//         Console.WriteLine("Static Number = " + ODLExercise.Number);
//     }
// }

// using System;

// namespace ConsoleApp
// {
//     class Product
//     {
//         // Properties
//         public string Name { get; set; }
//         public int Id { get; set; }
//         public string Brand { get; set; }
//         public string ISOStandard { get; set; }
//         public int Quantity { get; set; }
//         public DateTime ExpDate { get; set; }

//         // Default Constructor
//         public Product()
//         {
//             Name = string.Empty;
//             Brand = string.Empty;
//             ISOStandard = string.Empty;
//         }

//         // Parameterized Constructor
//         public Product(string name, int id, string brand, int quantity, DateTime expDate, string isoStandard)
//         {
//             Name = name;
//             Id = id;
//             Brand = brand;
//             Quantity = quantity;
//             ExpDate = expDate;
//             ISOStandard = isoStandard;
//         }

//         // Method to take input from user
//         public void GetProductData()
//         {
//             Console.WriteLine("Enter Product Name:");
//             Name = Console.ReadLine() ?? "";

//             Console.WriteLine("Enter Product ID:");
//             Id = Convert.ToInt32(Console.ReadLine());

//             Console.WriteLine("Enter Brand:");
//             Brand = Console.ReadLine() ?? "";

//             Console.WriteLine("Enter Quantity:");
//             Quantity = Convert.ToInt32(Console.ReadLine());

//             Console.WriteLine("Enter Expiry Date (yyyy-MM-dd):");
//             ExpDate = Convert.ToDateTime(Console.ReadLine());

//             Console.WriteLine("Enter ISO Standard:");
//             ISOStandard = Console.ReadLine() ?? "";
//         }

//         // Method to display product info
//         public void DisplayInfo()
//         {
//             Console.WriteLine("\n----- Product Details -----");
//             Console.WriteLine($"Name: {Name}");
//             Console.WriteLine($"ID: {Id}");
//             Console.WriteLine($"Brand: {Brand}");
//             Console.WriteLine($"ISO Standard: {ISOStandard}");
//             Console.WriteLine($"Quantity: {Quantity}");
//             Console.WriteLine($"Expiry Date: {ExpDate:yyyy-MM-dd}");
//         }
//     }

//     class Program
//     {
//         static void Main(string[] args)
//         {
//             // Example 1: Using Parameterized Constructor
//             Product prod1 = new Product(
//                 "Milk",
//                 101,
//                 "Amul",
//                 50,
//                 new DateTime(2026, 3, 15),
//                 "ISO9001"
//             );

//             prod1.DisplayInfo();

//             Console.WriteLine("\n----------------------------------\n");

//             // Example 2: Using Default Constructor + User Input
//             Product prod2 = new Product();
//             prod2.GetProductData();
//             prod2.DisplayInfo();

//             Console.ReadLine();
//         }
//     }
// }

// Static Constructor

// using System;
// class ODLExercise
// {
//     private static int number;
//     public static int Number { get { return number; } }
//     static ODLExercise()
//     {
//         Random r=new Random();
//         number=r.Next();
    
//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         Console.WriteLine("Static Number =" + ODLExercise.Number);
        
//     }
// }


