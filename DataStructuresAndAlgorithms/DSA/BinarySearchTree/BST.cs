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
            if (node == null)
            {
                return new Node(data);
            }
            else if (data < node.data)
            {
                node.left = Add(node.left, data);
            }
            else
            {
                node.right = Add(node.right, data);
            }

            return node;
        }

        public Node Find(int data)
        {
            Node n = this.Find(root, data);
            return n;
        }
        private Node Find(Node node, int data)
        {
            if (node == null)
            {
                return null;
            }
            else
            {
                if(data == node.data)
                {
                    return node;
                }
                else if(data > node.data)
                {
                    node = Find(node.right, data);
                }
                else
                {
                    node = Find(node.left, data);
                }     
            }

            return node;
        }

        public void InOrder()
        {
            InOrder(root);
        }

        private void InOrder(Node node)
        {
            if(node == null)
            {
                return;
            }

            InOrder(node.left);
            Console.Write(node.data + " ");
            InOrder(node.right);
        }

        public void PreOrder()
        {
            PreOrder(root);
        }

        private void PreOrder(Node node)
        {
            if (node == null)
            {
                return;
            }

            Console.Write(node.data + " ");
            PreOrder(node.left);
            PreOrder(node.right);
        }

        public void PostOrder()
        {
            PostOrder(root);
        }

        private void PostOrder(Node node)
        {
            if(node == null)
            {
                return ;
            }

            PostOrder(node.left);
            PostOrder(node.right);
            Console.Write(node.data + " ");
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
