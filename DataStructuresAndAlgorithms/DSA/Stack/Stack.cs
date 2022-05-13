using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Stack
{
    internal class Stack
    {
        #region Variable
        private int size;
        private int index;
        private object[] stack;
        #endregion


        #region Constructors
        public Stack()
        {
            size = 5; //default size
            index = 0;
            stack = new object[size];
        }

        public Stack(int size)
        {
            this.size = size;
            stack = new object[size];
        }
        #endregion


        #region Methods
        public void Push(object data)
        {
            if(!IsFull())
            {
                stack[index] = data;
                index++;
            }
            else
            {
                throw new Exception("Sorry! stack is full.");
            }
        }

        public object Pop()
        {
            if(!IsEmpty())
            {
                index--;
                var element = stack[index];
                return element;
            }
            else
            {
                throw new Exception("Sorry! Stack is Empty.");
            }
        }

        public object Peek()
        {
            if(!IsEmpty())
            {
                return stack[index];
            }
            else
            {
                throw new Exception("No Element is present!");
            }
        }

        public int Count()
        {
            return index;
        }

        public bool IsEmpty()
        {
            if(index == 0)
            {
                return true;
            }

            return false;
        }

        public bool IsFull()
        {
            if(index >= size)
            {
                return true;
            }

            return false;
        }
        #endregion
    }
}
