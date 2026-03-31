// 16 feb
// using System;
// class Program
// {
//     static void Main(string[] args)
//     {
//         int marks=85;
//         Console.WriteLine("Marks: " + marks);
//         object objmarks=marks; //boxing
//         Console.WriteLine("Object Marks: " + objmarks);
//         int unboxmarks=(int)objmarks; //unboxing
//         Console.WriteLine("Unboxed Marks: " + unboxmarks);
//         unboxmarks=unboxmarks+5; //modifying unboxed value
//         Console.WriteLine("Modified Unboxed Marks: " + unboxmarks);
//     }
// }

// using System;
// class Program
// {
//     static void Main(string[] args)
//     {
//         DateTime? dt = null;
//         dt=DateTime.Now;
//         object o=dt;
//         DateTime? dt2 = o as DateTime?;
//         if (dt2 != null)
//         {
//             Console.WriteLine(dt2.Value.ToString());}
//             Console.ReadLine();

        
//     }
// }




// using System;
// class Program
// {
//     static void Main(string[] args)
//     {
//         int? j=null;
//         int? k=54;
//         int resultt1=j ?? 0;
//         int resultt2= k ?? 0;
//         Console.WriteLine("resultt1={0},resultt2={1}", resultt1, resultt2 );
//         Console.ReadLine();
//     }
// }



 




// using System;

// class SwitchSelect
// {
//     public static void Main()
//     {
//         string myInput;

// int myInt;

// begin:

// Console.Write("Please enter a number between 1 and 3: "); 
// myInput= Console.ReadLine();

// myInt= Int32.Parse(myInput);

//         //switch with integer type Switch (myInt)
//         switch (myInt)
//         {
//             case 1:

// Console.WriteLine("Your number is {0}", myInt); break;

// case 2:

// Console.WriteLine("Your number is {0}", myInt);

// break;

// case 3:

// Console.WriteLine("Your number is {0}:", myInt);

// break;
// default:

// Console.WriteLine("Your number {0} is not between 1 and 3:", myInt);
//     break;
//         }

//     }
// }

    

// using System;

// class Program
// {
//     static void Main()
//     {
//         Console.Write("Enter first letter: ");
//         char letter1 = Convert.ToChar(Console.ReadLine());

//         Console.Write("Enter second letter: ");
//         char letter2 = Convert.ToChar(Console.ReadLine());

//         Console.Write("Enter third letter: ");
//         char letter3 = Convert.ToChar(Console.ReadLine());

//         Console.WriteLine("Reversed Order: {0} {1} {2}", letter3, letter2, letter1);
//     }
// }