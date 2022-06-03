using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.BellmanFordAlgo
{
    internal class Edge
    {
        public int source, destination, cost;

        public Edge(int source, int destination, int cost)
        {
            this.source = source;
            this.destination = destination;
            this.cost = cost;
        }
    }

    internal class Graph
    {
        private Edge[] edges;
        private int[] predecessor;

        private int vertice;
        private int edge;
        private int edgeCount;


        public Graph(int vertice, int edge)
        {
            this.vertice = vertice;
            this.edge = edge;
            this.edges = new Edge[this.edge];
            this.predecessor = new int[this.vertice];
            edgeCount = 0;
        }


        public void AddDirectedEdges(int source, int destination, int cost = 0)
        {
            if (source >= 0 && source < this.vertice && destination >= 0 && destination < this.vertice)
            {
                edges[edgeCount] = new Edge(source, destination, cost);
                edgeCount++;
            }
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
            while (path.Count > 0)
            {
                Console.Write(path.Pop() + "  ");
            }
        }

        public bool BellmanfordAlgorithm(int source, int destination, out int[] distanceVector)
        {
            distanceVector = new int[this.vertice];

            //Intialize
            for (int i = 0; i < this.vertice; i++)
            {
                distanceVector[i] = int.MaxValue;
            }

            distanceVector[source] = 0;
            predecessor[source] = int.MinValue;

            //Relax all edges V-1 times
            for (int i = 1; i < this.vertice; i++)
            {
                for (int j = 0; j < this.edgeCount; j++)
                {
                    if (distanceVector[edges[j].destination] > distanceVector[edges[j].source] + edges[j].cost)
                    {
                        distanceVector[edges[j].destination] = distanceVector[edges[j].source] + edges[j].cost;
                        predecessor[edges[j].destination] = edges[j].source;
                    }
                }
            }

            //Check for negative-weight cycle
            for (int j = 0; j < this.edgeCount; j++)
            {
                if (distanceVector[edges[j].destination] > distanceVector[edges[j].source] + edges[j].cost)
                {
                    distanceVector[edges[j].destination] = distanceVector[edges[j].source] + edges[j].cost;
                    predecessor[edges[j].destination] = edges[j].source;
                }
            }

            PrintShortestPath(destination);

            return true;
        }

    }
}
