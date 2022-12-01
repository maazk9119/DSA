using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving.Sortings
{
    internal class Sorting
    {
        internal static void Main()
        {

        }

        /// <summary>
        /// Problem Statement: 
        /// Given an array nums of size n, return the majority element.
        /// The majority element is the element that appears more than ⌊n / 2⌋ times.
        /// You may assume that the majority element always exists in the array.
        /// Follow-up: Could you solve the problem in linear time and in O(1) space?
        /// </summary>
        /// <returns></returns>
        internal int MajorityElements(int[] nums)
        {
            nums = new int[] { 2, 2, 1, 1, 1, 2, 2 }; //default input

            int maxIndex = 0;
            int maxCount = 1;

            if (nums.Length == 1)
            {
                return nums[0];
            }

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[maxIndex] == nums[i])
                {
                    maxCount++;
                }
                else
                {
                    maxCount--;
                }


                if (maxCount == 0)
                {
                    maxCount = 1;
                    maxIndex = i;
                }
            }

            return nums[maxIndex];
        }
    }


}
