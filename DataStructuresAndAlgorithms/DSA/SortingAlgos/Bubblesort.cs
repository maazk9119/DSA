using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.SortingAlgos
{
    internal class Bubblesort
    {
        public static int[] arr = { 1, 2, 3, 5, 7, 6 };

        public static void BasicAlgorithm(int[] arr)
        {
            Console.WriteLine("Basic Bubble Sort");
            for(int i = 0; i < arr.Length; i++)
            {
                for(int j=0; j<arr.Length-1; j++)
                {
                    if(arr[j] > arr[j+1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j+1];
                        arr[j+1] = temp;
                    }
                }
            }

            for(int k = 0; k < arr.Length; k++)
            {
                Console.Write("{0} ", arr[k]);
            }
        }

        public static void ModifiedAlgorithm(int[] arr)
        {
            Console.WriteLine("Modified Bubble Sort:");
            for (int i = 0; i < arr.Length; i++)
            {
                bool flag = true;

                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        flag = false;
                    }
                }

                if (flag)
                {
                    break;
                }
            }

            for (int k = 0; k < arr.Length; k++)
            {
                Console.Write("{0} ", arr[k]);
            }
        }
    }
}
