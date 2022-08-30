using System;
using System.Collections.Generic;

namespace week2
{
    class Program
    {
        #region exercise 1
        #endregion
        #region exercise 2


      

        #endregion
        static void Main(string[] args)
        {
            //minSortStack minStack = new minSortStack();
            //minStack.push(25);
            //minStack.push(10);
            //minStack.push(2);
            //minStack.push(15);
            //minStack.push(30);
            //minStack.push(3);
            //Console.WriteLine(minStack.pop());
            //Console.WriteLine(minStack.pop());
            //Console.WriteLine(minStack.pop());
            //Console.WriteLine(minStack.pop());
            //Console.WriteLine(minStack.pop());
            //Console.WriteLine(minStack.pop());

            //LruCache lrucache = new LruCache(4);
            //lrucache.add(1, "dfghjk");
            //lrucache.add(2, "jhgfd");
            //lrucache.get(1);
            //lrucache.add(3, "sdfghj");
            //lrucache.add(4, "sdfghjj");
            //lrucache.get(1);
            //lrucache.get(1);
            //lrucache.get(1);
            //lrucache.get(2);
            //lrucache.get(1);
            //lrucache.get(4);
            //lrucache.add(5, "jhgfd");
            //Console.WriteLine(lrucache.get(3));

            //SetOfStacks setOfStacks = new SetOfStacks(3);
            //setOfStacks.push(1);
            //setOfStacks.push(2);
            //setOfStacks.push(3);
            //setOfStacks.push(4);
            //setOfStacks.push(5);
            //Console.WriteLine(setOfStacks.pop());
            Box b1 = new Box(40, 30, 20);
            Box b2 = new Box(30, 25, 25);
            Box b3 = new Box(20, 15, 10);
            Box b4 = new Box(60, 50, 40);
            Box b5 = new Box(30, 30, 30);
            Box b6 = new Box(10, 10, 10);
            Box b7 = new Box(40, 30, 50);

            List<Box> list = new List<Box>();
            list.Add(b1);
            list.Add(b2);
            list.Add(b3);
            list.Add(b4);
            list.Add(b5);
            list.Add(b6);
            list.Add(b7);
           


            BoxList boxlist = new BoxList(list);
            Console.WriteLine(  boxlist.sumHight());
          

        }
    }
}