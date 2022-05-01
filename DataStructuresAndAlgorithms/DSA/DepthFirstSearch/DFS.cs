using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.DepthFirstSearch
{
    internal class DFS
    {
        public static int[,] matrix = {{ -1, 2, 3 },
                                       { 0, 9, 8  },
                                       { 1, 0, 1  }};

        public static void Algorithm(int[,] matrix)
        {
            //for neighbours use these matrix
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] NbrRows = new int[] { -1, 0, 0, 1 };
            int[] NbrCols = new int[] { 0, -1, 1, 0 };
            bool[,] visited = new bool[rows, cols];

            Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
            stack.Push(new Tuple<int, int>(0, 0)); //start with first element

            while(stack.Count > 0)
            {
                Tuple<int, int> current = stack.Pop();
                int currRow = current.Item1;
                int currCol = current.Item2;

                if(IsValid(visited, currRow, currCol))
                {
                    Console.Write("{0} ",matrix[currRow, currCol]); //print traverse

                    visited[currRow, currCol] = true;
                    for (int k = 0; k < 4; k++) //for always 4 neighbours
                    {
                        stack.Push(new Tuple<int, int>(currRow + NbrRows[k], currCol + NbrCols[k]));
                    }
                }
            }


            bool IsValid(bool[,] visited, int row, int col) //check valid neighbour 
            { 
                return (row>=0) && (row < rows) &&
                       (col>=0) && (col < cols) &&
                       (!visited[row, col]);
            }
        }
    }
}
