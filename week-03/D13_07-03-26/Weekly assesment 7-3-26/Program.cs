// Student Eligibility Validation System

// using System;

// public class Student
// {
//     public int StudentId { get; set; }
//     public string Name { get; set; }
//     public int Marks { get; set; }
//     public int Age { get; set; }
//     public int Attendance { get; set; }
// }

// public class EligibilityEngine
// {
//     public void CheckEligibility(Student student, string program, Predicate<Student> rule)
//     {
//         bool result = rule(student);

//         Console.WriteLine("========= ELIGIBILITY CHECK =========");
//         Console.WriteLine("Student Name : " + student.Name);
//         Console.WriteLine("Program      : " + program);
//         Console.WriteLine("Eligible     : " + result);
//         Console.WriteLine("-----------------------------------\n");
//     }
// }

// public class Solution
// {
//     public static void Main()
//     {
//         Student student = new Student
//         {
//             StudentId = 301,
//             Name = "Ananya",
//             Marks = 78,
//             Age = 18,
//             Attendance = 85
//         };

        
//         Predicate<Student> engineeringEligibility =
//             s => s.Marks >= 60;

//         // Medical: Marks >= 70 AND Age >= 17
//         Predicate<Student> medicalEligibility =
//             s => s.Marks >= 70 && s.Age >= 17;

//         // Management: Marks >= 55 AND Attendance >= 75
//         Predicate<Student> managementEligibility =
//             s => s.Marks >= 55 && s.Attendance >= 75;

        
//         EligibilityEngine engine = new EligibilityEngine();
//         engine.CheckEligibility(student, "Engineering", engineeringEligibility);
//         engine.CheckEligibility(student, "Medical", medicalEligibility);
//         engine.CheckEligibility(student, "Management", managementEligibility);
//     }
// }

// Student Performance Analysis System

// using System;
// using System.Collections.Generic;
// using System.Linq;

// public class Student
// {
//     public int StudentId { get; set; }
//     public string Name { get; set; }
//     public int Marks { get; set; }
// }

// public class AnalysisEngine
// {
//     public void AnalyzeStudents(List<Student> students)
//     {
        
//         var passedStudents = students
//             .Where(s => s.Marks >= 50)
//             .Select(s => s.Name);

//         Console.WriteLine("Passed Students:");
//         foreach (var name in passedStudents)
//         {
//             Console.WriteLine(name);
//         }

//         Console.WriteLine();

        
//         var topper = students
//             .OrderByDescending(s => s.Marks)
//             .First();

//         Console.WriteLine("Topper:");
//         Console.WriteLine($"{topper.Name} - {topper.Marks}");
//         Console.WriteLine();

       
//         var sortedStudents = students
//             .OrderByDescending(s => s.Marks)
//             .Select(s => new { s.Name, s.Marks });

//         Console.WriteLine("Students Sorted by Marks:");
//         foreach (var student in sortedStudents)
//         {
//             Console.WriteLine($"{student.Name} - {student.Marks}");
//         }
//     }
// }

// public class Solution
// {
//     public static void Main()
//     {
       
//         List<Student> students = new List<Student>
//         {
//             new Student { StudentId = 101, Name = "Ananya", Marks = 78 },
//             new Student { StudentId = 102, Name = "Ravi", Marks = 45 },
//             new Student { StudentId = 103, Name = "Neha", Marks = 88 },
//             new Student { StudentId = 104, Name = "Arjun", Marks = 67 }
//         };

        
//         AnalysisEngine engine = new AnalysisEngine();

//         engine.AnalyzeStudents(students);
//         Console.WriteLine();
//     }
// }

// Product Inventory Management System

// using System;
// using System.Collections.Generic;
// using System.Linq;

// public class Product
// {
//     public int ProductId { get; set; }
//     public string Name { get; set; }
//     public double Price { get; set; }
//     public int Quantity { get; set; }
// }

// public class InventoryEngine
// {
//     public void AnalyzeInventory(List<Product> products)
//     {
//         var lowStock = products.Where(p => p.Quantity < 10).Select(p => p.Name);

//         Console.WriteLine("Low Stock Products:");
//         foreach (var name in lowStock)
//         {
//             Console.WriteLine(name);
//         }

//         Console.WriteLine();

//         var sortedProducts = products.OrderBy(p => p.Price);

//         Console.WriteLine("Products Sorted by Price:");
//         foreach (var p in sortedProducts)
//         {
//             Console.WriteLine($"{p.Name} - {p.Price}");
//         }

//         Console.WriteLine();

//         var totalValue = products.Sum(p => p.Price * p.Quantity);

//         Console.WriteLine("Total Inventory Value:");
//         Console.WriteLine($"Rs {totalValue}");
//     }
// }

// public class Solution
// {
//     public static void Main()
//     {
//         List<Product> products = new List<Product>
//         {
//             new Product { ProductId = 201, Name = "Laptop", Price = 60000, Quantity = 5 },
//             new Product { ProductId = 202, Name = "Mouse", Price = 800, Quantity = 25 },
//             new Product { ProductId = 203, Name = "Keyboard", Price = 1500, Quantity = 8 },
//             new Product { ProductId = 204, Name = "Monitor", Price = 12000, Quantity = 12 }
//         };

//         InventoryEngine engine = new InventoryEngine();
//         engine.AnalyzeInventory(products);
//         Console.WriteLine();

//     }
// }

// Employee Promotion Validation System

// using System;

// public class Employee
// {
//     public int EmployeeId { get; set; }
//     public string Name { get; set; }
//     public int Experience { get; set; }
//     public double Salary { get; set; }
//     public int PerformanceRating { get; set; }
// }

// public class PromotionEngine
// {
//     public void Validate(Employee employee, string department, Predicate<Employee> rule)
//     {
//         bool result = rule(employee);

//         Console.WriteLine("========= PROMOTION VALIDATION =========");
//         Console.WriteLine("Employee Name : " + employee.Name);
//         Console.WriteLine("Department    : " + department);
//         Console.WriteLine("Eligible      : " + result);
//         Console.WriteLine("--------------------------------------");
//         Console.WriteLine();
//     }
// }

// public class Solution
// {
//     public static void Main()
//     {
//         Employee employee = new Employee
//         {
//             EmployeeId = 501,
//             Name = "Ravi",
//             Experience = 5,
//             Salary = 65000,
//             PerformanceRating = 4
//         };

//         Predicate<Employee> TechnicalPromotionRule = e => e.Experience >= 3;
//         Predicate<Employee> HRPromotionRule = e => e.Experience >= 2 && e.PerformanceRating >= 4;
//         Predicate<Employee> ManagementPromotionRule = e => e.Experience >= 5 && e.Salary >= 60000;

//         PromotionEngine engine = new PromotionEngine();

//         engine.Validate(employee, "Technical", TechnicalPromotionRule);
//         engine.Validate(employee, "HR", HRPromotionRule);
//         engine.Validate(employee, "Management", ManagementPromotionRule);
//     }
// }

// Employee Salary Analytics System 

using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public double Salary { get; set; }
}

public class AnalyticsEngine
{
    public void Analyze(List<Employee> employees)
    {
        Console.WriteLine("High Salary Employees:");
        employees.Where(e => e.Salary >= 50000)
                 .Select(e => e.Name)
                 .ToList()
                 .ForEach(Console.WriteLine);

        Console.WriteLine();

        Console.WriteLine("Employees Sorted by Salary:");
        employees.OrderByDescending(e => e.Salary)
                 .Select(e => $"{e.Name} - {e.Salary}")
                 .ToList()
                 .ForEach(Console.WriteLine);

        Console.WriteLine();

        var avgSalary = employees.Average(e => e.Salary);

        Console.WriteLine("Average Salary:");
        Console.WriteLine($"Rs {(int)avgSalary}");
    }
}

public class Solution
{
    public static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { EmployeeId = 301, Name = "Ramesh", Salary = 45000 },
            new Employee { EmployeeId = 302, Name = "Suresh", Salary = 52000 },
            new Employee { EmployeeId = 303, Name = "Kavya", Salary = 68000 },
            new Employee { EmployeeId = 304, Name = "Anita", Salary = 39000 }
        };

        AnalyticsEngine engine = new AnalyticsEngine();
        engine.Analyze(employees);
        Console.WriteLine();

    }
}