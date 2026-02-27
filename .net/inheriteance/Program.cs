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


//19 feb
//interface
// using System;
// namespace InterfaceDemo
// {
//     interface IArea
//     {
//         void CalcArea(double radius);
//     }
//     interface IVolume
//     {
//         void CalcVolume(int radius);
//     }
//     public class CircleCube:IArea, IVolume
//     {
//         public void CalcArea(double radius)
//         {
//             double pie =3.14;
//             double result;
//             result= pie * radius*radius;
//             Console.WriteLine(result);
//         }
//         public void CalcVolume(int side)
//         {
//             int result;
//             result = side* side* side;
//             Console.WriteLine(result);
//         }
//     }
//     class TestApp
//     {
//         public static void Main(string[] args)
//         {
//             CircleCube obj = new CircleCube();
//             double radius;
//             int side;

//             Console.WriteLine("Enter the value of the radius");
//             radius= Convert.ToDouble(Console.ReadLine());
//             obj.CalcArea(radius);
//             Console.WriteLine("Enter the value for side");
//             side = Convert.ToInt32(Console.ReadLine());
//             obj.CalcVolume(side);
//             Console.ReadLine();
//         }
//     }
// }

//abstarct
// methods are override in abstract
// using System;
// namespace AbstractDemo
// {
//     public abstarct class CalcArea
//     {
//         public abstarct void Area(double radius);

//         publid void bFunction()
//         {
//             Console.WriteLine("I amd not an abstarct method");
//         }
//     }
//     interface IVolume
//     {
//         void CalcVolume(int radius);
//     }
//     public class CircleCube : CalcArea, IVolume
//     {
//         public override void Area(double radius)
//         {
//             double pie =3.14;
//             double result;
//             result= pie * radius*radius;
//             Console.WriteLine(result);
//         }
//         public void CalcVolume(int side)
//         {
//             int result;
//             result = side* side* side;
//             Console.WriteLine(result);
//         }
//     }
//     class TestApp
//     {
//         public static void Main(string[] args)
//         {
//             CircleCube obj = new CircleCube();
//             double radius;
//             int side;

//             Console.WriteLine("Enter the value of the radius");
//             radius= Convert.ToDouble(Console.ReadLine());
//             obj.Area(radius);
//             obj.bFunction();
//             Console.WriteLine("Enter the value for side");
//             side = Convert.ToInt32(Console.ReadLine());
//             obj.CalcVolume(side);
//             Console.ReadLine();
//         }
//     }
// }

// task 1 of the day
// using System;

// // Abstract base class
// abstract class DrawingObject
// {
//     public abstract void Draw();
// }

// // Derived class Line
// class Line : DrawingObject
// {
//     public override void Draw()
//     {
//         Console.WriteLine("I'm a Line.");
//     }
// }

// // Derived class Circle
// class Circle : DrawingObject
// {
//     public override void Draw()
//     {
//         Console.WriteLine("I'm a Circle.");
//     }
// }

// // Derived class Square
// class Square : DrawingObject
// {
//     public override void Draw()
//     {
//         Console.WriteLine("I'm a Square.");
//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         // Array of abstract class type
//         DrawingObject[] objects = new DrawingObject[3];

//         objects[0] = new Line();
//         objects[1] = new Circle();
//         objects[2] = new Square();

//         // Calling Draw() using loop
//         foreach (DrawingObject obj in objects)
//         {
//             obj.Draw();
//         }

//         Console.ReadLine();
//     }
// }

//taks 2 : same code using virtual function
// using System;

// // Base class (No need to make it abstract now)
// class DrawingObject
// {
//     // Virtual method with default implementation
//     public virtual void Draw()
//     {
//         Console.WriteLine("Drawing an object...");
//     }
// }

// // Derived class Line
// class Line : DrawingObject
// {
//     public override void Draw()
//     {
//         Console.WriteLine("I'm a Line.");
//     }
// }

// // Derived class Circle
// class Circle : DrawingObject
// {
//     public override void Draw()
//     {
//         Console.WriteLine("I'm a Circle.");
//     }
// }

// // Derived class Square
// class Square : DrawingObject
// {
//     public override void Draw()
//     {
//         Console.WriteLine("I'm a Square.");
//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         // Array of base class type
//         DrawingObject[] objects = new DrawingObject[3];

//         objects[0] = new Line();
//         objects[1] = new Circle();
//         objects[2] = new Square();

//         // Calling Draw() using loop (Runtime Polymorphism)
//         foreach (DrawingObject obj in objects)
//         {
//             obj.Draw();
//         }

//         Console.ReadLine();
//     }
// }

//delegates
//is a refrence type used to encapsulate- hold the methoda reference in an object
//has specigic signature and return types
//type safe funtion pointer

//multicasting
//with multicast delegates can be combied with the addition operator(+)
// using System;
// namespace DelegateDemo
// {
    
//     public delegate void ArtithmeticOperation(int x, int y);

//     class UsingDelegates{

//     static void AddSimple()
//     {
//         Console.WriteLine(" ");
//     }
//     static void Add(int x, int y)
//     {
//         Console.WriteLine(x+y);
//     }
//     static void Sub(int x, int y)
//     {
//         Console.WriteLine(x-y);
//     }
//     static void Multi(int x, int y)
//     {
//         Console.WriteLine(x*y);
//     }
//     static void Div(int x, int y)
//     {
//         Console.WriteLine(x/y);
//     }
//     static void Main(string[] args)
//     {
//         ArtithmeticOperation obj = new ArtithmeticOperation(Add);
//         obj += new ArtithmeticOperation(Sub);
//         obj -= new ArtithmeticOperation(Multi);
//         obj += new ArtithmeticOperation(Div);
//         obj += new ArtithmeticOperation(Multi);

//         obj(45, 30);
//         // ArtithmeticOperation obj1 = new ArtithmeticOperation(Sub);
//         // obj(45, 30);
//         Console.ReadLine();
//     }
//     }
// }

// task 3
// using System;

// // Step 1: Create delegate
// delegate void NotificationSender(string message);

// // Step 2: Create Notifiers class
// class Notifiers
// {
//     public static void SendEmail(string message)
//     {
//         Console.WriteLine("Email sent: " + message);
//     }

//     public static void SendSMS(string message)
//     {
//         Console.WriteLine("SMS sent: " + message);
//     }

//     public static void SendPushNotification(string message)
//     {
//         Console.WriteLine("Push Notification sent: " + message);
//     }
// }

// // Step 3: Create NotificationManager class
// class NotificationManager
// {
//     public void NotifyUser(string message, NotificationSender sender)
//     {
//         sender(message); // invoking delegate
//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         NotificationManager manager = new NotificationManager();

//         manager.NotifyUser("Welcome User", Notifiers.SendEmail);
//         manager.NotifyUser("Your OTP is 1234", Notifiers.SendSMS);
//         manager.NotifyUser("New Offer Available", Notifiers.SendPushNotification);

//         Console.ReadLine();
//     }
// }

// public void NotifyUser(string message, NotificationSender sender)
// {                                                                           // extra code by sir
//     // Decouple logic
//     sender(message);
// }


// namespace NotificationSystem
// {
//     public delegate NotificationSender(string message);
//     public class Notifiers{
//         public static void SendEmail(string message)
//         {
//             Console.WriteLine(message);
//         }
//         public static void SendSMS(string message)
//         {
//             Console.WriteLine(message);
//         }
//         public static void SendPushNotification(string message)
//         {
//             Console.WriteLine(message);
//         }
        
//     }
//     public class NotificationManager
//     {
//         public void NotificationUser(string message, NotificationSender sender)
//         {
//             sender(message);
//         }

//     }
//     class TestNotification
//     {
//         static void Main(string[] args)
//         {
//             NotificationManager manager = new NotificationManager();
//             manager.NotificationUser("order shipped", Notifiers.SendEmail);
//             manager.NotificationUser("order shipped", Notifiers.SendSMS);
//             manager.NotificationUser("order shipped", Notifiers.SendPushNotification);
//         }
//     }
// }

//arraylist
//changes to size can be made in the runtime
// using System.Collections;
// namespace ArrayListDemo
// {
//     class UsingArrayList
//     {
//         static void Main(string[] args)
//         {
//             ArrayList listdata = new ArrayList();
//             listdata.Add(100);
//             listdata.Add(102);
//             listdata.Add(103);
//             listdata.Add(104);
//             listdata.Add("Dotnet");
//             foreach (object i in listdata)
//             {
//                 Console.WriteLine(i);
//             }
//             ArrayList listdata2 = new ArrayList();
//             listdata.Add(200);
//             listdata.Add(202);
//             listdata.Add(203);
//             listdata.Add(204);
//             listdata.Add("Java");
//             foreach (object i in listdata2)
//             {
//                 Console.WriteLine(i);
//             }
//             listdata.AddRange(listdata2);
//             foreach (object i in listdata)
//             {
//                 Console.WriteLine(i);
//             }
//             string order = " Order#1001 | Laptop | Dell | 75000 ";

//             Console.WriteLine(order);
//             string trimOrder=order.Trim();
//             Console.WriteLine(trimOrder);

//             Console.WriteLine(order.Length);
//             Console.WriteLine(trimOrder.Length);

//             string[] parts = trimOrder.Split('|');
//             Console.WriteLine("After Split");
//             foreach(var item in parts)
//             {
//                 Console.Write(item.Trim());
//             }
//         }
       
//     }
// }

//task 4
// using System;

// // Abstract base class
// abstract class OrderProcessor
// {
//     // Properties
//     public int OrderId { get; set; }
//     public double Amount { get; set; }

//     // Abstract Methods
//     public abstract void ProcessPayment();
//     public abstract void GenerateInvoice();
//     public abstract void SendNotification();

//     // Concrete Method
//     public void DisplayOrderDetails()
//     {
//         Console.WriteLine("Order ID: " + OrderId);
//         Console.WriteLine("Amount: ₹" + Amount);
//     }
// }

// // Derived Class
// class OnlineOrder : OrderProcessor
// {
//     public override void ProcessPayment()
//     {
//         Console.WriteLine("Processing online payment via UPI/Card...");
//     }

//     public override void GenerateInvoice()
//     {
//         Console.WriteLine("Generating digital invoice (PDF)...");
//     }

//     public override void SendNotification()
//     {
//         Console.WriteLine("Sending order confirmation email...");
//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         // Parent reference, Child object
//         OrderProcessor order = new OnlineOrder();

//         // Assign values
//         order.OrderId = 101;
//         order.Amount = 2500.75;

//         // Call methods
//         order.DisplayOrderDetails();
//         order.ProcessPayment();
//         order.GenerateInvoice();
//         order.SendNotification();

//         Console.ReadLine();
//     }
// }

//exception handling
// using System;
// class ExcDemo1
// {
//     public static void Main()
//     {
//         int[] nums = new int[4];
//         try
//         {
//             Console.WriteLine("Before exception is generated");
//             for ( int i = 0; i <10; i++)
//             {
//                 nums[i]= i;
//                 Console.WriteLine("nums[{0}] : {1}", i, nums[i]);
//             }
//             Console.WriteLine("this wont be displayed");
//         }
//         catch (IndexOutOfRangeException)
//         {
//             Console.WriteLine("Index out-of-bounds!");

//         }
//         Console.WriteLine("After catch statement");
//     }
// }

// multiple catch statements
// using System;
// class ExcDemo2
// {
//     public static void Main()
//     {
//         int[] numer = { 4,8,16,32,64,128,256,512};
//         int[] denom = {2,0,4,4,0,8};
//         for (int i=0; i < numer.Length; i++)
//         {
//             try{
//                 Console.WriteLine(numer[i] + " / " + denom[i] + " is "+ numer[i] / denom[i]);
//             }
//             catch (DivideByZeroException)
//             {
//                 Console.WriteLine("cant divide bt zero");
//             }
//             catch (IndexOutOfRangeException)
//             {
//                 Console.WriteLine("no match found");
//             }
//         }
//     }
// }

// nested try block
// using System;
// class NestTrys
// {
//     pub
// }


//user defined exception
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

// namespace CustomExceptionExampleCode{
//     class MyException: Exception{
//         public MyException (string Message) : base ( Message){}
//         public MyException(){}
//         public MyException(string Message, Exception inner) : base(Message, inner){}
//     }
// }

// class Program{
//     static void Main (string[] args){
//         int a = 50;
//         int b = 10;
//         int k = a/b ;
//         try{
//             if ( k <10){
//                 throw new MyException("value of k is less than 10");

//             }
            
//             }
//             catch (MyException e){
//                 Console.WriteLine("Caught my exception");
//                 Console.WriteLine(e.Message);
            
//         }
//         Console.Read();
//     }
// }
