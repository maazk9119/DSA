using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.SortingAlgos
{
    internal class Mergesort
    {
        public static int[] arr = { 4, 3, 2, 1 };

        public static void MergeSort(int[] arr, int p, int r)
        { 
            if(p < r)
            {
                int q = p + (r - p) / 2;
                MergeSort(arr, p, q);
                MergeSort(arr, q + 1, r);
                Merge(arr, p, q, r);
            }
        }



        private static void Merge(int[] arr, int p, int q, int r)
        {
            int leftArrayLength = q - p + 1;
            int rightArrayLength = r - q;

            int[] leftArray = new int[leftArrayLength];
            int[] rightArray = new int[rightArrayLength];

            int i = 0, j = 0;
            for(i=0; i<leftArrayLength; i++)
            {
                leftArray[i] = arr[p+i];
            }

            for(j=0; j<rightArrayLength; j++)
            {
                rightArray[j] = arr[q + 1 + j];
            }

            i = 0; j = 0; int k= p;

            while(i<leftArrayLength && j<rightArrayLength)
            {
                if(leftArray[i] <= rightArray[j])
                {
                    arr[k] = leftArray[i];
                    i++;
                    k++;
                }
                else
                {
                    arr[k] = rightArray[j];
                    j++;
                    k++;
                }
            }

            while(i < leftArrayLength)
            {
                arr[k] = leftArray[i];
                i++;
                k++;
            }

            while(j < rightArrayLength)
            {
                arr[k] = rightArray[j];
                j++;
                k++;
            }
        }
    }
}
