using System;

namespace LearnCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello, World!");

            List<string> list1 = new List<string> { "item 1", "item 2" };
            List<string> list2 = [.. list1, "item 3",];
        }
    }
}