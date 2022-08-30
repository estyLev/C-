using System;
using System.Collections.Generic;
using System.Text;

namespace week2
{
    public class SetOfStacks
    {
        private Stack<Stack<int>> bigStack;
        private int capacity;
        public SetOfStacks(int capacity)
        {
            bigStack = new Stack<Stack<int>>();
            Stack<int> stack = new Stack<int>();
            bigStack.Push(stack);
            this.capacity = capacity;
        }

        public void push(int val)
        {
            if(bigStack.Peek().Count>=capacity)
            {
                Stack<int> stack = new Stack<int>();
                bigStack.Push(stack);
            }
            bigStack.Peek().Push(val);

        }
        public int pop()
        {
            return bigStack.Peek().Pop();
        }
    }

}
