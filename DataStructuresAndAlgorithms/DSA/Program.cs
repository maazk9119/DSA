// See https://aka.ms/new-console-template for more information
using DSA.BreadthFirstSearch;
using DSA.DepthFirstSearch;
using DSA.KMP;
using DSA.NaiveAlgo;

Console.WriteLine("Hello, World!");


Console.WriteLine("DFS Traverse 2D array");
DFS.Algorithm(DFS.matrix);


Console.WriteLine("\n\nBFS Traverse 2D array");
BFS.Alogrithm(BFS.matrix);


Console.WriteLine("\n\nKMP Algorithm:");
KMP.Algorithm(KMP.Text, KMP.Pattern);


Console.WriteLine("\nNaive Algorithm:");
Naive.Alogrithm(Naive.Text, Naive.Pattern);
Console.ReadLine();