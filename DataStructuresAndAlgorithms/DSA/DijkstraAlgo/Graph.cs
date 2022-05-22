using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.DijkstraAlgo
{
    internal class Vertice
    {
        public int id;
        public int distance;
        public bool _visited;

        public Vertice(int id, int distance)
        {
            this.id = id;
            this.distance = distance;
            this._visited = false;
        }
    }

    internal class PriorityQueue
    {
        private List<Vertice> list;

        public PriorityQueue()
        {
            list = new List<Vertice>();
        }


        public void Enqueue(Vertice e)
        {
            list.Add(e);
        }

        public Vertice ExractMin()
        {
            int loc = this.FindLoc();
            Vertice v = list[loc];

            list.RemoveAt(loc);

            return v; 
        }


        public bool IsEmpty()
        {
            return this.list.Count == 0;
        }


        private int FindLoc()
        {
            Vertice min = list[0];
            int loc = 0;

            if(list.Count < 0)
            {
                return -1;
            }


            for(int i=1; i< list.Count; i++)
            {
                if(min.distance  >= list[i].distance)
                {
                    loc = i;
                    min = list[i];
                }
            }

            return loc;
        }

    }

    public class Graph
    {
        private int[,] adjMatrix;
        private int vertices;

        public Graph(int vertice)
        {
            this.vertices = vertice;
            adjMatrix = new int[vertice, vertice];
        }

        public void AddDirectedEdge(int source, int destination, int cost = 0)
        {
            if (source >= 0 && source < vertices && destination >= 0 && destination < vertices)
            {
                adjMatrix[source, destination] = cost;
            }
        }

        public int[] GetDirectedNeighbour(int source)
        {
            List<int> neighbours = new List<int>();

            for (int i = 0; i < vertices; i++)
            {
                if (adjMatrix[source, i] > 0)
                {
                    neighbours.Add(i);
                }
            }

            return neighbours.ToArray();
        }


        public void DijkstraSingleSourceShortestPath(int source)
        {
            PriorityQueue pq = new PriorityQueue();
            Vertice[] distanceVector = new Vertice[vertices];

            for (int i = 0; i < vertices; i++)
            {
                distanceVector[i] = new Vertice(i, int.MaxValue);
            }

            distanceVector[source].distance = 0;
            distanceVector[source]._visited = true;

            for (int i = 0; i < vertices; i++)
            {
                pq.Enqueue(distanceVector[i]);
            }

            while (!pq.IsEmpty())
            {
                Vertice v = pq.ExractMin();
                int[] neighbour = this.GetDirectedNeighbour(v.id);

                foreach (var n in neighbour)
                {
                    if (distanceVector[n].distance > v.distance + adjMatrix[v.id, n])
                    {
                        distanceVector[n].distance = v.distance + adjMatrix[v.id, n];
                    }
                }
            }

            foreach (var i in distanceVector)
            {
                Console.WriteLine("{0}->{1}", i.id, i.distance);
            }
        }

    }
}
