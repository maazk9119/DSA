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

    }
}
