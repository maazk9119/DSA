using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.BreadthFirstSearch
{
    internal class BFS
    {
        public static int[,] matrix = {{ -1, 2, 3 },
                                       { 0, 9, 8  },
                                       { 1, 0, 1  }};


        public static void Alogrithm(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            bool[,] visited = new bool[rows, cols];
            int[] nbrRows = { -1, 0, 0, 1 };
            int[] nbrCols = { 0, -1, 1, 0 };

            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(new Tuple<int, int>(0, 0));

            while(queue.Count > 0)
            {
                Tuple<int, int> curr = queue.Dequeue();
                int currrow = curr.Item1;
                int currcol = curr.Item2;

                if(IsValid(visited, currrow, currcol))
                {
                    Console.Write("{0} ",matrix[currrow, currcol]);
                    visited[currrow, currcol] = true;

                    for(int k=0; k<4; k++)
                    {
                        queue.Enqueue(new Tuple<int, int>(currrow + nbrRows[k], currcol + nbrCols[k]));
                    }
                }    
            }

            bool IsValid(bool[,] visited, int row, int col)
            {
                return (row >= 0) && (row < rows) &&
                       (col >= 0) && (col < cols) &&
                       (!visited[row, col]);
            }

        }

    }
}
