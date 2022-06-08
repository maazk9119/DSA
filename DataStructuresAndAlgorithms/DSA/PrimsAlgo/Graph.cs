using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.PrimsAlgo
{
    internal class Vertice
    {
        public int id;
        public int key;
        public Vertice pi;
        public bool visited;

        public Vertice(int id, int key, Vertice pi, bool visited = false)
        {
            this.id = id;
            this.key = key;
            this.pi = pi;
            this.visited = visited;
        }
    }

    internal class PriorityQueue
    {
        List<Vertice> List;

        public PriorityQueue()
        {
            List  = new List<Vertice>();
        }

        public void enqueue(Vertice v)
        {
            List.Add(v);
        }

        public Vertice extractMin()
        {
            int i = findLoc();
            Vertice v = List[i];
            List.RemoveAt(i);

            return v;
        }

        public bool Contains(int v)
        {
            return List.Select(x => x.id == v).ToList().Count > 0;
        }

        public bool IsEmpty()
        {
            return List.Count == 0;
        }

        private int findLoc()
        {
            Vertice min = List[0];
            int loc = 0;

            for (int i = 1; i < List.Count; i++)
            {
                if (min.key > List[i].key)
                {
                    min = List[i];
                    loc = i;
                }
            }

            return loc;
        }
    }

    internal class Graph
    {
        private int[,] costMatrix;
        private int vertice;

        public Graph(int vertice)
        {
            this.vertice = vertice;
            this.costMatrix = new int[vertice, vertice];

            initialize();
        }

        private void initialize()
        {
            for (int i = 0; i < this.vertice; i++)
            {
                for (int j = 0; j < this.vertice; j++)
                {
                    costMatrix[i, j] = int.MaxValue;
                }
            }
        }

        public void addEdge(int src, int dest, int cost)
        {
            if (src >= 0 && dest >= 0 && src < this.vertice && dest < this.vertice)
            {
                this.costMatrix[src, dest] = cost;
                this.costMatrix[dest, src] = cost;
            }
        }

        private int[] getNeighbour(int v)
        {
            List<int> neighbours = new List<int>();

            for(int i=0; i < this.vertice; i++)
            {
                if(costMatrix[v, i] != int.MaxValue)
                {
                    neighbours.Add(i);
                }
            }

            return neighbours.ToArray();
        }

        private void printMst(Vertice[] v, int s)
        {
            Console.WriteLine("ID     Key    Pi\n=================");
            Console.WriteLine("{0}      {1}      {2}", s, 0, null);
            for (int i=0; i<v.Length;i++)
            {
                if(v[i].pi != null)
                {
                    Console.WriteLine(v[i].id + "      " + v[i].key + "      " + v[i].pi.id);
                }
            }
        }


        public void mstPrim(int r)
        {
            Vertice[] v = new Vertice[this.vertice];
            PriorityQueue q = new PriorityQueue();
 

            //Initialize
            for (int i = 0; i < this.vertice; i++)
            {
                v[i] = new Vertice(i, int.MaxValue, pi: null);
            }

            v[r].key = 0;
            v[r].pi = null;

            //Add to P-queue
            for (int i = 0; i < this.vertice; i++)
            {
                q.enqueue(v[i]);
            }

            while(!q.IsEmpty())
            {
                Vertice u = q.extractMin();
                int[] neigh = getNeighbour(u.id);

                //relax if neighbour is in P-queue and maintain pi(parent)
                foreach(var n in neigh)
                {
                    if(q.Contains(n) && v[n].key > costMatrix[u.id, n])
                    {
                        v[n].key = costMatrix[u.id, n];
                        v[n].pi = new Vertice(u.id, costMatrix[u.id, n], u);
                    }
                }
            }

            printMst(v, r);
        }
    }
}