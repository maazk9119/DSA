using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.BellmanFordAlgo
{
    internal class Bellmanford
    {
        int[,] adjMatrix;
        int vertice;
        int[] predecessor;

        public Bellmanford(int vertice)
        {
            this.vertice = vertice;
            this.adjMatrix = new int[this.vertice, this.vertice];
            this.predecessor = new int[this.vertice];

            this.Initialize();
        }

        private void Initialize()
        {
            for (int i = 0; i < this.vertice; i++)
            {
                for (int j = 0; j < this.vertice; j++)
                {
                    this.adjMatrix[i, j] = int.MaxValue;
                }

                this.predecessor[i] = 0;
            }
        }

        public void AddDirectedEdges(int source, int destination, int cost = 0)
        {
            if (source >= 0 && source < this.vertice && destination >= 0 && destination < this.vertice)
            {
                adjMatrix[source, destination] = cost;
            }
        }

        public int[] getNeighbour(int v)
        {
            List<int> neighbours = new List<int>();

            for (int i = 0; i < this.vertice; i++)
            {
                if (adjMatrix[v, i] != int.MaxValue)
                {
                    neighbours.Add(i);
                }
            }

            return neighbours.ToArray();
        }

        private void PrintShortestPath(int destination)
        {
            Stack<int> path = new Stack<int>();
            path.Push(destination);

            int parent = predecessor[destination];
            while (parent != int.MinValue)
            {
                path.Push(parent);
                parent = predecessor[parent];
            }

            Console.Write("Path:");
            while(path.Count > 0)
            {
                Console.Write(path.Pop() +"  ");
            }

            Console.WriteLine("\n");
        }
        public bool BellmanfordAlgorithm(int source, int destination ,out int[] distanceVector)
        {
            distanceVector = new int[this.vertice];         

            //Intialize
            for (int i = 0; i < this.vertice; i++)
            {
                distanceVector[i] = this.adjMatrix[source, i];
            }

            distanceVector[source] = 0;
            predecessor[source] = int.MinValue;

            //Relax all edges V-1 times
            for (int i = 1; i < this.vertice; i++)
            {
                for (int j = 0; j < this.vertice; j++)
                {
                    int[] neigh = getNeighbour(j);

                    foreach (var n in neigh)
                    {
                        if (distanceVector[n] > distanceVector[j] + adjMatrix[j, n])
                        {
                            distanceVector[n] = distanceVector[j] + adjMatrix[j, n];
                            predecessor[n] = j;
                        }
                    }
                }
            }

            //Check for negative-weight cycle
            for (int j = 0; j < this.vertice; j++)
            {
                int[] neigh = getNeighbour(j);

                foreach (var n in neigh)
                {
                    if (distanceVector[n] > distanceVector[j] + adjMatrix[j, n])
                    {
                        Console.WriteLine("Graph Contain Negative weight");
                        return false;
                    }
                }
            }

            PrintShortestPath(destination);

            return true;
        }
    }
}          
