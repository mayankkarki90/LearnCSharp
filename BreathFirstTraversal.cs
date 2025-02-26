using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnCSharp
{
    internal record Node(int value, Node? LeftChild = default, Node? RightChild = default);

    internal class BreathFirstTraversal
    {
        /*
         * Consider a tree like
         *          1
         *      2       3
         *    4   5   6   7
         * Print output as
         * 1
         * 23
         * 4567
         *
         * var node = new Node(1,
                new Node(2,
                    new Node(4), new Node(5)),
                new Node(3,
                    new Node(6), new Node(7)));
         */
        public void Traverse1(Node node)
        {
            Queue<(Node node, int level)> nodesQueue = new();
            nodesQueue.Enqueue((node, 1));
            int currentLevel = 1;

            //Loop until there is any node in the queue
            //And with every iteration dequeue node and enqueue child nodes
            //Show value of dequeued node and add newLine if there is change in levels
            while (nodesQueue.Count > 0)
            {
                (var currentNode, int level) = nodesQueue.Dequeue();
                if (currentLevel < level)
                {
                    currentLevel++;
                    Console.WriteLine();
                }

                Console.Write(currentNode.value);
                if (currentNode.LeftChild != null)
                {
                    nodesQueue.Enqueue((currentNode.LeftChild, level + 1));
                }

                if (currentNode.RightChild != null)
                {
                    nodesQueue.Enqueue((currentNode.RightChild, level + 1));
                }
            }
        }

    }
}
