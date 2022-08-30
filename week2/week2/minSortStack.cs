using System;
using System.Collections.Generic;
using System.Text;

namespace week2
{
    public class minSortStack
    {
       private Stack<int> stack ;
       private Stack<int> temp;
        public minSortStack()
        {
            stack = new Stack<int>();
            temp = new Stack<int>();
        }
        public void push(int val)
        {
            if(stack.Count==0)
            {
                stack.Push(val);
                return;
            }
            while (stack.Count > 0 && stack.Peek() < val)
            {
                temp.Push(stack.Pop());
            }
            stack.Push(val);
            while (temp.Count>0)
            {
                stack.Push(temp.Pop());
            }
        }
        public int pop()
        {
           return stack.Pop();
        }
        public int peek()
        {
            return stack.Peek();
        }

        public bool isEmpty()
        {
            return stack.Count == 0;
        }
    }
}
