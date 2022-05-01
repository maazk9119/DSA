using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.SortingAlgos
{
    internal class Selectionsort
    {
        public static int[] arr = { 4, 3, 2, 7, 5, 1 };

        public static void Algorithm(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int min = i;

                for(int j= i+1; j < arr.Length; j++)
                {
                    if(arr[min] > arr[j])
                    {
                        int temp = arr[j];
                        arr[j] = arr[min];
                        arr[min] = temp;
                    }
                }

            }
            
            for(int i= 0; i < arr.Length; i++)
            {
                Console.Write("{0} ", arr[i]);
            }
        }
    }
}
