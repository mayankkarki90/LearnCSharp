using System;

namespace LearnCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list1 = new List<string> { "item 1", "item 2" };
            List<string> list2 = [.. list1, "item 3",];

            var node = new Node(1,
                new Node(2,
                    new Node(4), new Node(5)),
                new Node(3,
                    new Node(6), new Node(7)));
            new BreathFirstTraversal().Traverse1(node);

            Console.Read();
        }
    }
}