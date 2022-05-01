using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.KMP
{
    internal class KMP
    {
        public static string Text = "aabbaamaabbmaazaabb";
        public static string Pattern = "maaz";

        public static void Algorithm(string text, string pattern)
        {
            Print();

            int[] piTable = new int[pattern.Length];
            int i = 0;
            int j = 0;

            initializePiTable(piTable);

            while (i < text.Length)
            {
                if (text[i] == pattern[j])
                {
                    i++;
                    j++;
                }
                if (j == pattern.Length)
                {
                    Console.WriteLine("Pattern Matching Found at:"+ (i - j));
                    j = piTable[j - 1];
                }
                else if (i < text.Length && text[i] != pattern[j])
                {
                    if(j != 0)
                    {
                        j = piTable[j - 1];
                    }
                    else
                    {
                        i++;
                    }
                }

            }


            void initializePiTable(int[] piTable)
            {
                piTable[0] = 0;
                int k = 0;
                int l = 1;

                while (l < pattern.Length)
                {
                    if(pattern[k] == pattern[l])
                    {
                        k++;
                        piTable[l] = k;
                        l++;
                    }
                    else
                    {
                        if(k != 0)
                        {
                            k = piTable[k - 1];
                        }
                        else
                        {
                            l++;
                        }
                    }
                }
            }

            void Print()
            {
                Console.WriteLine("Text is:"+Text);
                Console.WriteLine("Pattern is:" + pattern);
            }
        }
    }
}
