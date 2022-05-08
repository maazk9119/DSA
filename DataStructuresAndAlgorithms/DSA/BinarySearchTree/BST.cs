using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.BinarySearchTree
{
    internal class Node
    {
        public Node left;
        public Node right;
        public int data;

        public Node(int data)
        {
            this.data = data;
            Initialize();
        }

        private void Initialize()
        {
            left = null;
            right = null;
        }
    }

    internal class BST
    {
        private Node root;

        public BST()
        {
            root = null;
        }

        public void Add(int data)
        {
            root = Add(root, data);
        }

        private Node Add(Node node, int data)
        {
            if(node == null)
            {
                return new Node(data);
            }
            else if(data < node.data)
            {
                node.left = Add(node.left, data);
            }
            else
            {
                node.right = Add(node.right, data);
            }

            return node;
        }


        public void PrintLevelWise()
        {
            BFS(root);
        }

        private void BFS(Node root)
        {
            Queue<Node> queue = new Queue<Node>();
            Stack<Node> stack = new Stack<Node>();

            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                Node node = queue.Dequeue();
                
                if(node != null)
                {
                    stack.Push(node);
                    queue.Enqueue(node.right);
                    queue.Enqueue(node.left);
                }
            }

            while(stack.Count > 0)
            {
                Console.Write(stack.Pop().data+" ");
            }
        }

    }
}
