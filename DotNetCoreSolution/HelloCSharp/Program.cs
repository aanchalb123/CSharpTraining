using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.classes;

namespace HelloCSharp
{
   public class Program
   {

      //Delegates 
      //function delegates, which will takes a reference of a function with an return type
      delegate double Function(double x);


      //enum - it is a set of constant values
      public enum fruits
      {
         apple,
         mango,
         banana,
         carrot
      };

      //struct
      public struct Point
      {
         public double X { get; }
         public double Y { get; }
         public Point(double x, double y) => (X, Y) = (x, y);
      }

      static void Main(string[] args)
      {
         Console.WriteLine("Hello");

         Employee emp = new Employee(12, "Aanchal", "Dhanbad");
         Console.WriteLine(emp.GetEmployees());


         //-----------boxing unboxing------------//
         int no = 123;
         Object obj = no;   //boxing
         int i = (int)obj;    //unboxing
         Console.WriteLine("obj is ", obj);
         Console.WriteLine("i is ", i);


         //-------------try catch ----------------//
         try
         {
            var s = new Stack<int>();
            s.Push(4);    //stack contains 4
            s.Push(7);    //stack contains 4, 7
            Console.WriteLine(s.Pop());   //stack contains 4
            Console.WriteLine(s.Pop()); //stack is empty
            Console.WriteLine(s.Pop());     //throws exception
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message.ToString());
         }

         finally { Console.WriteLine("Finally block"); }

         //---------List to print cities-----------//
         List<string> cities = new List<string>();
         cities.Add("Durgapur");
         cities.Add("Kolkata");
         cities.Add("Pune");
         foreach (var c in cities)
         {
            Console.WriteLine(c);
         }

         //-------------IEnumerable--------------------//
         int[] scores = { 10, 20, 30, 40 };
         IEnumerable<int> scores2 = from score in scores
                                    where score > 20
                                    select score;
         foreach (var score in scores2)
         {
            Console.WriteLine(score);
         }

         //----------method based expression------------//
         IEnumerable<string> myCity = cities.Where(c => c == "Kolkata");
         foreach (var city in myCity)
         {
            Console.WriteLine(city);
         }


         //implementation of delegates, f is representing a function delegate.
         static double[] Apply(double[] a, Function f)
         {
            var result = new double[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
               result[i] = f(a[i]);
            }
            return result;
         }
         double[] d = { 0.0, 0.5, 1.0, 2.5 };
         double[] d2 = Apply(d, (x) => x * x);
         foreach (var item in d2)
         {
            Console.WriteLine(item);
         }

         Console.ReadLine();
      }
   }
}
