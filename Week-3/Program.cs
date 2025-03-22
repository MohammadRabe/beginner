
using System.Collections.Generic;
using System.Collections;
using System;
namespace OOP
{
    internal class Program
    {
        #region  1-Generic Swap Function
        //static void Swap<T>(ref T a, ref T b)
        //{
        //    T temp = a;
        //    a = b;
        //    b = temp;
        //}
        //static void Main(string[] args)
        //{
        //    int a = 10, b = 20;
        //    Console.WriteLine($"Before Swapping a = {a}, b = {b}");
        //    Swap(ref a, ref b);
        //    Console.WriteLine($"After Swapping a = {a}, b = {b}");

        //    Console.WriteLine("==================================");
        //    string first = "First", second = "Second";
        //    Console.WriteLine($"Before Swapping first = {first}, second = {second}");
        //    Swap(ref first, ref second);
        //    Console.WriteLine($"After Swapping first = {first}, second = {second}");

        //}
        #endregion
        #region 2- Dictionary
        //static void DispGrade(Dictionary<string,double> grades,string name)
        //{
        //    if(grades.ContainsKey(name))
        //        Console.WriteLine(grades[name]);
        //    else
        //        Console.WriteLine("No such a name");
        //}
        //static void Main(string[] args)
        //{
        //    Dictionary<string,double> stdGrade = new Dictionary<string,double>();
        //    stdGrade.Add("Mohammed",9.5);
        //    stdGrade.Add("Hazem",8.8);
        //    stdGrade["Ahmed"] = 9.1;
        //    stdGrade["Kareem"] = 9.5;
        //    DispGrade(stdGrade,"Mohammed");
        //}
        #endregion
        #region 3- Queue
        //static void Main(string[] args)
        //{
        //    Queue<string> customers = new Queue<string>();
        //    customers.Enqueue("Mohammed Rabie");
        //    customers.Enqueue("Hamdy Mahmoud");
        //    customers.Enqueue("Yousef Sameh");

        //    while(customers.Count > 0)
        //    {
        //        Console.WriteLine(customers.Dequeue());
        //    }
        //}
        #endregion
    }
}


