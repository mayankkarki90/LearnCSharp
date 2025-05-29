using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnCSharp
{
    internal class ArrayLearn
    {
        private int[] arr1 = new int[10];
        private int[] arr2 = [ 1, 3 ];
        private int[,] arr3 = { { 1, 3 }, { 2, 4 } };
        //multi-dimension array
        private int[,,] arr4 = { { { 1, 3 }, { 2, 4 } }, { { 5, 7 }, { 6, 8 } } };
        private int[][] arr5 = new int[10][];
        //Jagged array, can have different no of columns in each row
        private int[][] arr6 = new int[2][];

        public ArrayLearn()
        {
            arr6[0] = [1, 2];
            arr6[1] = [3, 4, 5];

            var rank = arr4.Rank;
        }

    }
}
