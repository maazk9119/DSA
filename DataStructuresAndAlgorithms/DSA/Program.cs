// See https://aka.ms/new-console-template for more information
using DSA.BreadthFirstSearch;
using DSA.DepthFirstSearch;
using DSA.KMP;

Console.WriteLine("Hello, World!");


Console.WriteLine("DFS Traverse 2D array");
DFS.Algorithm(DFS.matrix);


Console.WriteLine("\nBFS Traverse 2D array");
BFS.Alogrithm(BFS.matrix);


Console.WriteLine("\nKMP Algorithm:");
KMP.Algorithm(KMP.Text, KMP.Pattern);

Console.ReadLine();