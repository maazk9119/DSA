using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.DijkstraAlgo
{
    internal class Dijkstra
    {
        private int[,] _costMatrix;
        private bool[] _visited;
        private int vertices;
        private int infinity = int.MaxValue;

        public Dijkstra(int vertices)
        {
            this.vertices = vertices-2; //vertices = edges + (edges - vertices)
            this._costMatrix = new int[this.vertices, this.vertices];
            this._visited = new bool[this.vertices];

            Initialize();
        }

        private void Initialize()
        {
            for(int i = 0; i < vertices; i++)
            {
                for(int j = 0; j < vertices; j++)
                {
                    if(_costMatrix[i, j] == 0)
                    {
                        _costMatrix[i, j] = infinity;
                    }
                }

                _visited[i] = false;
            }
        }

        public void AddEdge(int source, int destination, int cost = 0)
        {
            if(source >= 0 && source < vertices && destination >= 0 && destination < vertices)
            {
                _costMatrix[source, destination] = cost;
            }
        }

        public int[] GetDirectedNeighbour(int source)
        {
            List<int> neighbours = new List<int>();

            for(int i=0; i<vertices; i++)
            {
                if(_costMatrix[source, i] != int.MaxValue && _costMatrix[source, i] > 0)
                {
                    neighbours.Add(i);
                }
            }


            return neighbours.ToArray();
        }

        public void PrintShortestPath(int goalnode, int[] predecessor)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(goalnode);

            int parent = predecessor[goalnode];

            while(parent != -1)
            {
                stack.Push(parent);
                parent = predecessor[parent];
            }

            while(stack.Count > 0)
            {
                int element = stack.Pop();
                Console.Write(" {0}", element);
            }
        }
        public int[] Algorithm(int startNode)
        {
            int[] distanceVector = new int[vertices];
            int[] predecessor = new int[vertices];

            for(int i=0; i<vertices; i++)
            {
                distanceVector[i] = _costMatrix[startNode, i];
            }

            distanceVector[startNode] = 0;
            predecessor[startNode] = -1;
            int nextNode = 0;


            while (_visited.Select(x => x).Contains(false))
            {
                int min_distance = int.MaxValue;

                //always min
                for (int i = 0; i < vertices; i++)
                {
                    if (distanceVector[i] < min_distance && _visited[i] == false)
                    {
                        min_distance = distanceVector[i];
                        nextNode = i;
                    }
                }

                _visited[nextNode] = true;
                int[] neighbour = GetDirectedNeighbour(nextNode);

                //relax neighbours
                foreach(var n in neighbour)
                {
                    if(distanceVector[n] >  min_distance + _costMatrix[nextNode, n])
                    {
                        distanceVector[n] = min_distance + _costMatrix[nextNode, n];
                        predecessor[n] = nextNode;
                    }
                }
            }

            return predecessor;
        }
    }
}
