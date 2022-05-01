using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LinkedList
{
    internal class Node
    {
        public Node next;
        public int Data;

        public Node(int data)
        {
            this.Data = data;
            next = null; 
        }
    }
    internal class SinglyLinkedList
    {
        Node head;
        Node tail;

        public SinglyLinkedList()
        {
            head = null;
            tail = null;
        }

        public void InsertAtEnd(int data)
        {
            Node newNode = new Node(data);

            if(tail == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.next = newNode;
                tail = newNode;
            }
        }

        public void InsertAtFirst(int data)
        {
            Node newNode = new Node(data);

            if(head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.next = head;
                head = newNode;
            }

        }

        public void Update(int oldData, int newData)
        {
            Node n = Find(oldData);
            
            if(n != null)
            {
                n.next.Data = newData;
            }
            else
            {
                Console.Write("\n{0} Data not Found!", oldData);
            }
        }

        public Node Find(int data)
        {
            var temp = head;
            while(temp.next != null)
            {
                if(temp.next.Data == data)
                    return temp;

                temp = temp.next;
            }

            return null;
        }

        public void Delete(int data)
        {
            if (head.Data == data)
            {
                Node node = head.next;
                head = null;
                head = node;
            }
            else
            {
                Node n = Find(data);
                if(n != null)
                {
                    Node temp = n;
                    n.next = n.next.next;
                    temp = null;
                }
            }
        }

        public void FindMiddleElement()
        {
            if(head != null)
            {
                Node slow = head;
                Node fast = head;
                while (slow.next != null && fast!=null && fast.next != null)
                {
                    slow = slow.next;
                    fast = fast.next.next;
                }

                Console.WriteLine("Middle Element is:" + slow.Data);
            }
            else
            {
                Console.WriteLine("Head is null");
            }
        }

        public void Print()
        {
            var temp = head;

            while(temp != null)
            {
                Console.Write("{0} ",temp.Data);

                temp = temp.next;
            }
        }

        public void ReserverPrint()
        {
            Stack<Node> stack = new Stack<Node>();
            Node temp = head;
            
            while(temp!=null)
            {
                stack.Push(temp);

                temp = temp.next;
            }
            
            while(stack.Count > 0)
            {
                Console.Write("{0} ",stack.Pop().Data);
            }
        }
    }
}
