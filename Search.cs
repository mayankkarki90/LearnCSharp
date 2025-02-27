using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace LearnCSharp
{
    internal class Search
    {
        /// <summary>
        /// Search the array linearly.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="numberToFind">The number to find.</param>
        /// <returns></returns>
        public static int LinearSearch(int[] array, int numberToFind)
        {
            //Inbuilt method for linear search
            // Array.FindIndex(array, x => x == numberToFind);

            for (var i = 0; i < array.Length; i++)
            {
                if (array[i] == numberToFind)
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// Search the array using binary search algorithm which requires
        /// input array to be sorted
        /// </summary>
        /// <param name="array">The sorted array.</param>
        /// <param name="numberToFind">The number to find.</param>
        /// <returns></returns>
        public static int BinarySearch(int[] array, int numberToFind)
        {
            //Inbuilt way to do binary search
            //Array.BinarySearch(array, numberToFind);

            int low = 0;
            int high = array.Length - 1;

            while (low <= high)
            {
                //int mid = (low + high) / 2;

                //int mid = low + (high - low) / 2;
                //To prevent memory overflow because of adding 2 big numbers use
                //the above condition which produces the same result

                int mid = low + ((high - low) >> 1);
                //Each right shift divides the number by 2.
                //And each left shift multiplies the number by 2.
                
                //After calculating mid index, check if value at mid index is same as number to find.
                //If mid value is less than number to find, then set low as mid + 1
                //Else if mid value is greater than number to find, then set high as mid - 1
                if (numberToFind == array[mid])
                    return mid;

                if (numberToFind > array[mid])
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            return -1;
        }
    }

    [MemoryDiagnoser]
    public class SearchBenchmark
    {
        private static readonly int[] Numbers = Enumerable.Range(1, 100000).ToArray();

        [Params(12345, 778999)]
        public static int NumberToFind { get; set; }

        [Benchmark()]
        public int LinearSearch()
        {
            return Search.LinearSearch(Numbers, NumberToFind);
        }

        [Benchmark()]
        public int BinarySearch()
        {
            return Search.BinarySearch(Numbers, NumberToFind);
        }
    }
}
