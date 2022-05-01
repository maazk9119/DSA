using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.SortingAlgos
{
    internal class Insertionsort
    {
        public static int[] arr = { 4, 3, 2, 7, 5, 1 };

        public static void Algorithm(int[] arr)
        {
            for(int i = 1; i < arr.Length; i++)
            {
                int j = i;
                while(j > 0)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                    }
                    else
                    {
                        break;
                    }

                    j--;
                }
            }
            
            for(int j = 0; j < arr.Length; j++)
            {
                Console.Write("{0} ", arr[j]);
            }
        }
    }
}
