using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.DepthFirstSearch
{
    /// <summary>
    /// Find the lenght of maximun Island 
    /// </summary>
    internal class Island
    {
       public static  int[,] M = new int[,] {{ 1, 1, 0, 0, 0 },
                                             { 0, 1, 0, 0, 1 },
                                             { 1, 0, 1, 1, 1 },
                                             { 0, 0, 0, 0, 0 },
                                             { 1, 0, 1, 0, 1 }};


        static int rows = M.GetLength(0);
        static int cols = M.GetLength(1);

        public static int GetMaxIslandLength()
        {
            bool[,] visited = new bool[rows, cols];
            int maxLength = 0;

            for (int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    if(M[i, j] == 1 && !visited[i, j])
                    {
                        int length = DFS(i, j, visited, 1);
                        if(length > maxLength)
                            maxLength = length;
                    }
                }
            }
            


            return maxLength;
        }

        private static int DFS(int row, int col, bool[,] visited, int length)
        {
            int[] Nrow = {-1, -1, -1, 0, 0, 1, 1, 1 };
            int[] Ncol = { -1, 0, 1, -1, 1, -1, 0, 1 };

            Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
            stack.Push(new Tuple<int, int>(row, col));
            visited[row, col] = true;

            while(stack.Count > 0)
            {
                Tuple<int, int> tuple = stack.Pop();
                int Trow = tuple.Item1;
                int Tcol = tuple.Item2;

                for (int i = 0; i < 8; i++)
                {
                    int nbrRow = Trow + Nrow[i];
                    int nbrCol = Tcol + Ncol[i];
                    if (ValidNeighbour(nbrRow, nbrCol, visited))
                    {
                        length++;
                        stack.Push(new Tuple<int, int>(nbrRow, nbrCol));
                        visited[nbrRow, nbrCol] = true;
                    }
                }
            }

            return length;
        }

        private static bool ValidNeighbour(int row, int col, bool[,] visited)
        {
            return (row >= 0 && row < rows) && (col>=0 && col < cols) && (!visited[row, col]) && M[row, col] == 1;
        }
    }
}
