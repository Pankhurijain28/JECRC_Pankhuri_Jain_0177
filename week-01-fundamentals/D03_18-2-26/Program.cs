//18 feb
// using System;
// namespace AccessModifierDemo{
//     class UsingAccessModifier{
//         public void PublicMethod(){
//             Console.WriteLine("Its public");
//         }
//         private void PrivateMethod(){
//             Console.WriteLine("Its private");
//         }
//         protected void protectedMethod(){
//             Console.WriteLine("Its protected");
//         }
//         internal void internalMethod(){
//             Console.WriteLine("its internal");
//         }
//     }
//     class Test{
//     static void Main(String[]args){
//         UsingAccessModifier obj= new UsingAccessModifier();
//         obj.PublicMethod();
//         obj.internalMethod();
//     }
// }

// }

// inheritance

// using System;
// namespace InheritanceDemo{
//     public class Person{
//         private string name;
//         private int age;

//         public void GetInformation(){
//             Console.WriteLine("Enter your name");
//             name= Console.ReadLine();
//             Console.WriteLine("Enter age");
//             age=int.Parse(Console.ReadLine());
//         }
//         public void DisplayInformation(){
//             Console.WriteLine("Welcome to .Net Training Mr/ms {0}, and your age is {1}" , name, age);
//         }
//     }
//     public class Employee:Person
//     {
//         public string Companyname;
//         private int EmployeeID;
//         protected int EmployeeScore;

//         public void GetEmployeeinformation(){
//             Console.WriteLine("enter your companyname");
//             Companyname = Console.ReadLine();
//             Console.WriteLine("enter employee id");
//             EmployeeID= int.Parse(Console.ReadLine());
//             Console.WriteLine("enter employee score");
//             EmployeeScore= int.Parse(Console.ReadLine());
//         }
//         public void DisplayCompany(){
//             Console.WriteLine("welcome to this company {0},and yojur id is {1} and your score is {2}" , Companyname, EmployeeID, EmployeeScore);
//         }
//     }
//     public class GradeLevel:Employee{
//         public void CheckEligible(){
//             Console.WriteLine("every employee should have above 150");
//             if(EmployeeScore>150)
//                 Console.WriteLine("you are eligible");
//             else
//                 Console.WriteLine("you are not eligible");
//         }
//     }
//     public class TestProgram{
//         static void Main(string[]args)
//         {
//             GradeLevel cap= new GradeLevel();
//             cap.GetInformation();
//             cap.GetEmployeeinformation();
//             Console.WriteLine("\nEmployeeinformation:");
//             cap.DisplayCompany();
//             cap.DisplayInformation();
//             cap.CheckEligible();
//         }
//     }
// }

//Polymorphism

// using System;

// class Car
// {
//     public string Name;
//     public int NumberOfDoors;
//     public Car()
//     {
//         Name = "NoName" ; 
//         NumberOfDoors = 3;
//     }
   
// public Car(string name, int numberOfDoors){
//     Name = name;
//     NumberOfDoors = numberOfDoors;
// }
// public Car(string name){
//     Name = name;
//     NumberOfDoors = 0;
// }

// public Car(int numberOfDoors){
//     Name = " ";
//     NumberOfDoors = numberOfDoors;
// }
// class ODLExce
// {
//     static void Main(string[]args)
//     {
//         Car c1 = new Car();
//         Car c2 = new Car(3);
//         Car c3 = new Car("MyName");
//         Car c4 = new Car("MyName", 4);
//         Console.WriteLine(c1.NumberOfDoors);
//         Console.WriteLine(c1.Name);
//     }
// }
// }

// method overhiding(compile time polymorphism)
// class GroupAgent{
//     public void show(){
//         Console.WriteLine("GroupAgent Created !!!");
//         Console.ReadLine();
//     }
// }
// class Agent: GroupAgent{
//     public new void show(){
//         Console.WriteLine("GroupAgent Created !!!!");
//         Console.ReadLine();
//     }
// }

// class ODLExercise
// {
//     public static void Main(){
//         GroupAgent a1 = new GroupAgent();
//         a1.show();
//         Agent b1= new Agent();
//         b1.show();
//         GroupAgent a2 = new Agent();
//         a2.show();
//     }
// }

// sealed method
// using System;
// class GroupAgent{
//     public void show(){
//         Console.WriteLine("GroupAgent Created !!!");
//         Console.ReadLine();
//     }
// }
// class Agent: GroupAgent{
//     public sealed override void show(){
//         Console.WriteLine("Agent Created !!!!");
//         Console.ReadLine();
//     }
// }
// class Booking: Agent
// {
//     public override void show(){
//         Console.WriteLine("Booking Created!!!!");
//         Console.ReadLine();
//     }
// }


