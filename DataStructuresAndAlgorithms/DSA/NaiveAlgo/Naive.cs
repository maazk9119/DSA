using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.NaiveAlgo
{
    internal class Naive
    {
        public static string Text = "aabbaamaabbmaazaabb";
        public static string Pattern = "maaz";

        public static void Alogrithm(string text, string pattern)
        {
            for(int i = 0; i < text.Length - pattern.Length; i++)
            {
                int j;
                for(j=0; j < pattern.Length; j++)
                {
                    if (text[i + j] != pattern[j])
                        break;
                }

                if(j == pattern.Length)
                    Console.WriteLine("Pattern matching found at:"+i);
            }
        }
    }
}
