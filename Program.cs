using System;
using BenchmarkDotNet.Running;

namespace LearnCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<string> list1 = new List<string> { "item 1", "item 2" };
            //List<string> list2 = [
            //.. list1, "item 3", ];

            //var node = new Node(1,
            //    new Node(2,
            //        new Node(4), new Node(5)),
            //    new Node(3,
            //        new Node(6), new Node(7)));
            //new BreathFirstTraversal().Traverse1(node);

            //int[] sortedArray = { 2, 5, 7, 9, 13, 17, 30 };
            //int numberToFind = 17;
            //int resultIndex = Search.BinarySearch(sortedArray, numberToFind);
            //if (resultIndex == -1)
            //{
            //    Console.WriteLine("Can't find number");
            //}
            //else Console.WriteLine("Number found at index " + resultIndex);

            //BenchmarkRunner.Run<SearchBenchmark>();

            //ArrayLearn arr = new ArrayLearn();
            var employeeViewModel = new EmployeeViewModel();
            Console.WriteLine(employeeViewModel[0].Name);
            Console.WriteLine(employeeViewModel[1].Name);
            Console.WriteLine(employeeViewModel[2].Name);

            var car = new Car();
            var byke = new Byke();

            car.FuelType();
            car.NoOfCylinders();

            byke.FuelType();
            byke.NoOfCylinders();

            Vehicle newByke = new Byke();
            newByke.FuelType();//This will call base class method because instance is
                               //created with Base class and new is used on derived class

            var exam = new
            {
                Level = 1,
                Questions = new[] {
                new { Text = "A", Answer = 23 },
                new { Text = "B", Answer = 35 }
               }
            };

            //Non Destructive mutation, exam will not change but a new anonymous
            //instance is creates with same values
            var examWithNewLevel = exam with { Level = 2 };
            
            
            Console.Read();
        }
    }
}