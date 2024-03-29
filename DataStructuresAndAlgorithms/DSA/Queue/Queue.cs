﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Queue
{
    internal class Queue
    {
        private int front;
        private int rear;
        private int size;
        private object[] queue;

        public Queue()
        {
            this.size = 5;
            this.front = 0;
            this.rear = 0;
            queue = new object[size]; //default size
        }

        public void Enqueue(object data)
        {
            if(!IsFull())
            {
                queue[rear] = data;
                rear++;
            }
            else
            {
                Console.WriteLine("Sorry! Queue is Full.");
            }
        }

        public object? Dequeue()
        {
            if(!IsEmpty())
            {
                rear--;
                var element = queue[front];
                
                for(int i = 0; i < rear; i++)
                {
                    queue[i] = queue[i + 1];
                }

                return element;
            }
            else
            {
                Console.WriteLine("Sorry! Queue is Empty.");

                return null;
            }
        }

        public int Count()
        {
            return rear;
        }

        public object? Front()
        {
            if(!IsEmpty())
            {
                return queue[front];
            }
            else
            {
                Console.WriteLine("Sorry! Queue is Empty.");

                return null;
            }
        }

        public bool IsEmpty()
        {
            if(front == 0 && rear == 0)
            {
                return true;
            }

            return false;
        }

        public bool IsFull()
        {
            if(rear == size)
            {
                return true;
            }

            return false;
        }
    }
}
