using EmployeeManagementSystem;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace EmployeeManagementSystem
{
    public class EmployeeService
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeeDB;Integrated Security=True";
        EmployeeModel emp = new EmployeeModel();
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===Employee Management System.===");
                Console.WriteLine("1. View All Employees");
                Console.WriteLine("2. Insert Employees");
                Console.WriteLine("3. Update Employees");
                Console.WriteLine("4. Delete Employees");
                Console.WriteLine("5. Search by Employee ID");
                Console.WriteLine("6. Search by Departement Name");
                Console.WriteLine("7. Exit");

                Console.WriteLine("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {

                    case 1:
                        ViewAllEmployees();
                        break;

                    case 2:
                        InsertEmployee();
                        break;

                    case 3:
                        UpdateEmployee();
                        break;

                    case 4:
                        DeleteEmployee();
                        break;

                    case 5:
                        SearchByID();
                        break;

                    case 6:
                        break;

                    case 7:
                        return;

                    default:
                        Console.WriteLine("`Invalid choice. Please try again.");
                        break;


                }

                Console.WriteLine("\nPress Enter to Continue...");
                Console.ReadLine();

            }

        }

        public void ViewAllEmployees()
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string query = "SELECT Id, Name, Department, Salary FROM Employee";

            using SqlCommand cmd = new SqlCommand(query, conn);
            using SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\n===Employee List ====");

            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetInt32(0)}" +
                $" | Name: {reader.GetString(1)}" +
                $" | Department: {reader.GetString(2)}" +
                $" | Salary: {reader.GetInt32(3)}");
            }
        }

        public void InsertEmployee()
        {
            EmployeeModel emp = new EmployeeModel();

            Console.WriteLine("Insert New Employee");

            Console.WriteLine("Enter Name: ");
            emp.Name = Console.ReadLine();

            Console.WriteLine("Enter Department: ");
            emp.Department = Console.ReadLine();

            Console.WriteLine("Enter Salary: ");
            emp.Salary = Convert.ToInt32(Console.ReadLine());

            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string query = "INSERT INTO Employee (Name, Department, Salary) VALUES (@Name, @Department, @Salary)";

            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Department", emp.Department);
            cmd.Parameters.AddWithValue("@Salary", emp.Salary);

            cmd.ExecuteNonQuery();

            Console.WriteLine("Inserted Successfully!!!");
        }
        public void DeleteEmployee()
        {
            Console.WriteLine("Enter Employee ID");
            int Id = Convert.ToInt32(Console.ReadLine());
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "DElETE FROM Employee WHERE Id=@Id";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", Id);
            int rows= cmd.ExecuteNonQuery();
            Console.WriteLine(rows > 0 ? "Employee Deleted Successfully" : "Employee Not Found");

        }

        public void UpdateEmployee()
        {
            Console.WriteLine("Enter the Employee ID");
            emp.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Employee Name");
            emp.Name = Console.ReadLine(); 
            Console.WriteLine("Enter the Employee Department");
            emp.Department = Console.ReadLine();
            Console.WriteLine("Enter the Employee Salary");
            emp.Salary = Convert.ToInt32(Console.ReadLine());


            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "UPDATE Employee" + "SET Name=@Name, Department=@Department, Salary=@Salary" +
                "WHERE Id=@Id";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Department", emp.Department);
            cmd.Parameters.AddWithValue("@Salary", emp.Salary);
            cmd.Parameters.AddWithValue("@Id", emp.Id);
            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine(rows > 0 ? "Employee Updated Successfully" : "Employee Not Found");

        }
        public void SearchByID()
        {
            Console.WriteLine("Enter Employees ID");
            emp.Id= Convert.ToInt32(Console.ReadLine());
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "SELECT Id, Name, Department, Salary FROM " + "Employee WHERE Id=@Id";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", emp.Id);
            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                emp.Id = reader.GetInt32(0);
                emp.Name = reader.GetString(1);
                emp.Department = reader.GetString(2);
                emp.Salary = reader.GetInt32(3);
                Console.WriteLine($"{emp.Id} | {emp.Name} | {emp.Department} | {emp.Salary} ");
            }
            else
            {
                Console.WriteLine("Employee Not Found !!!");
            }
        }


    }

}
