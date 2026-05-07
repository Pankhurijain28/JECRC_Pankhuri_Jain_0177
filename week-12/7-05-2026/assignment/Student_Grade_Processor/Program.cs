using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public int[] Grades { get; set; }

    public double Average()
    {
        return Grades.Average();
    }

    public int Highest()
    {
        return Grades.Max();
    }

    public int Lowest()
    {
        return Grades.Min();
    }
}

class Program
{
    static void Main()
    {
        // Student data
        List<Student> students = new List<Student>
        {
            new Student { Name = "John", Grades = new int[] { 85, 90, 78, 92 } },
            new Student { Name = "Sarah", Grades = new int[] { 95, 88, 91, 89 } },
            new Student { Name = "Mike", Grades = new int[] { 70, 65, 80, 75 } },
            new Student { Name = "Emma", Grades = new int[] { 88, 92, 94, 96 } }
        };

        Console.WriteLine("--- Student Grade Report ---\n");

        // Display student statistics
        foreach (var student in students)
        {
            Console.WriteLine($"{student.Name}: " +
                $"Average = {student.Average():F2}, " +
                $"Highest = {student.Highest()}, " +
                $"Lowest = {student.Lowest()}");
        }

        // -------------------------------
        // Top Performer
        // -------------------------------
        var topPerformer = students
            .OrderByDescending(s => s.Average())
            .First();

        Console.WriteLine($"\nTop Performer: {topPerformer.Name} " +
            $"(Average: {topPerformer.Average():F2})");

        // -------------------------------
        // Students with all grades >= 80
        // -------------------------------
        Console.WriteLine("\nStudents with all grades >= 80:\n");

        foreach (var student in students)
        {
            if (student.Grades.All(g => g >= 80))
            {
                Console.WriteLine($"{student.Name} " +
                    $"({string.Join(",", student.Grades)})");
            }
        }

        // -------------------------------
        // Unique Grade Values
        // -------------------------------
        HashSet<int> uniqueGrades = new HashSet<int>();

        foreach (var student in students)
        {
            foreach (int grade in student.Grades)
            {
                uniqueGrades.Add(grade);
            }
        }

        Console.WriteLine("\nUnique Grade Values Across All Students:\n");

        var sortedGrades = uniqueGrades.OrderBy(g => g);

        Console.WriteLine(string.Join(",", sortedGrades));

        Console.WriteLine($"\nTotal unique grades: {uniqueGrades.Count}");
    }
}