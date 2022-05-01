// See https://aka.ms/new-console-template for more information
using DSA.BreadthFirstSearch;
using DSA.DepthFirstSearch;
using DSA.KMP;
using DSA.LinkedList;
using DSA.NaiveAlgo;
using DSA.SortingAlgos;

Console.WriteLine("Hello, World!");


Console.WriteLine("DFS Traverse 2D array");
DFS.Algorithm(DFS.matrix);


Console.WriteLine("\n\nBFS Traverse 2D array");
BFS.Alogrithm(BFS.matrix);


Console.WriteLine("\n\nKMP Algorithm:");
KMP.Algorithm(KMP.Text, KMP.Pattern);


Console.WriteLine("\nNaive Algorithm:");
Naive.Alogrithm(Naive.Text, Naive.Pattern);


Console.WriteLine("\n\nSingly LinkedList:");
SinglyLinkedList list = new SinglyLinkedList();
list.InsertAtEnd(1);
list.InsertAtFirst(2);
list.InsertAtEnd(3);
list.InsertAtEnd(4);
list.InsertAtFirst(5);
list.Print();
list.Update(3, 6);
Console.WriteLine();
list.Print();
Console.WriteLine();
list.FindMiddleElement();
list.Delete(5);
list.Print();
Console.WriteLine();
list.FindMiddleElement();
list.ReserverPrint();


Console.WriteLine("\n\nBubble Sort:");
Bubblesort.ModifiedAlgorithm(Bubblesort.arr);


Console.ReadLine();
