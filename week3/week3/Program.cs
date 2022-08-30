using System;
using System.Collections.Generic;
using static week3.BinarySearchTree;

namespace week3
{
    class Program
    {

        #region exercise1
        public static int next(Node node)
        {
            Node point;
           
            if (node.right != null)
            {
                point = node.right;
                while (point.left != null)
                    point = point.left;
                return point.key;
            }
            if (node.parent != null && node.parent.right == node)
            {
                point = node.parent;
                while (point.parent != null && point.parent.right == point)
                {
                    point = point.parent;
                }
                if (point.parent == null)
                    return node.key;
                return point.parent.key;
            }
            if (node.parent != null && node.parent.left == node)
                return node.parent.key;
            return node.key;
        }
        #endregion
        #region exercise2
        public static Node minimalHight(int[] arr, int l, int r)
        {
            if (l == r)
                return null;
            Node node = BinarySearchTree.newNode(arr[(r + l) / 2]);
            node.left = minimalHight(arr, l, (r + l) / 2);
            node.right = minimalHight(arr, (r + l) / 2 + 1, r);
            return node;
        }
        #endregion
        #region exercise3
        public static List<List<Node>> listFromTree(Node root)
        {
            Queue<Node> parentsQueue = new Queue<Node>();
            Queue<Node> childsQueue = new Queue<Node>();
            parentsQueue.Enqueue(root);

            List<List<Node>> res = new List<List<Node>>();

            while (parentsQueue.Count != 0)
            {
                List<Node> list = new List<Node>();

                while (parentsQueue.Count != 0)
                {
                    Node node = parentsQueue.Dequeue();
                    list.Add(node);
                    if (node.left != null)
                    {
                        childsQueue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        childsQueue.Enqueue(node.right);
                    }
                }

                res.Add(list);
                while (childsQueue.Count != 0)
                {
                    parentsQueue.Enqueue(childsQueue.Dequeue());
                }


            }
            return res;
        }
        #endregion
        #region exercise4

        //1 with a parent pointer
        public static Node searchParentWithParentPointer(Node root, Node node1, Node node2)
        {
            Node point = node1;

            if (searchNode(point, node2))
                return node1.parent;

            while (point != null)
            {
                if (point == node2)
                    return point.parent;

                if (point.parent.right == point)
                {
                    if (searchNode(point.parent.left, node2))
                        return point.parent;
                }
                else
                {
                    if (searchNode(point.parent.right, node2))
                        return point.parent;
                }
                point = point.parent;

            }
            return root;

        }
        public static bool searchNode(Node root, Node node)
        {
            if (root == null)
                return false;
            if (root == node)
                return true;
            return searchNode(root.left, node) || searchNode(root.right, node);

        }
        //2 with a parent pointer
        public static Node searchParent(Node root, Node node1, Node node2)
        {
            Node point = root;
            Node prev = root;
            bool node1InLeft;
            bool node2InLeft;
            bool node1InRight;
            bool node2InRight;
            while (point != null)
            {
                node1InLeft = searchNode(point.left, node1);
                node2InLeft = searchNode(point.left, node2);
                node1InRight = searchNode(point.right, node1);
                node2InRight = searchNode(point.right, node2);
                if (node2InLeft && node1InLeft)
                {
                    prev = point;
                    point = point.left;
                }
                else if (node2InRight && node1InRight)
                {
                    prev = point;
                    point = point.right;
                }
                else if ((node1InLeft || node2InLeft) && (node1InRight || node2InRight))
                    return point;
                else
                    return prev;

            }
            return root;

        }
        #endregion
        #region exercise5
        public static void printAllArrays(Node root)
        {
            if (root != null)
            {
                Console.Write(root.key + ", ");
                leftRight(root.left);
                leftRight(root.right);
                rightLeft(root.left);
                rightLeft(root.right);
            }

        }
        public static void leftRight(Node node)
        {
            if (node != null)
            {
                Console.Write(node.key + ", ");
                leftRight(node.left);
                leftRight(node.right);
            }

        }
        public static void rightLeft(Node node)
        {
            if (node != null)
            {
                Console.Write(node.key + ", ");
                rightLeft(node.right);
                rightLeft(node.left);
            }

        }
        #endregion
        static void Main(string[] args)
        {
            Node root = BinarySearchTree.newNode(40);
            BinarySearchTree.insert(root, 60);
            BinarySearchTree.insert(root, 45);
            BinarySearchTree.insert(root, 35);
            BinarySearchTree.insert(root, 25);
            BinarySearchTree.insert(root, 50);
            BinarySearchTree.insert(root, 30);
            BinarySearchTree.insert(root, 22);

            BinarySearchTree.inorder(root);
            // Console.WriteLine(next(root));

            //==============================

            //int[] arr = { 3, 6, 7, 15, 19, 25, 40 };
            //Node node = minimalHight(arr,0, arr.Length);
            //BinarySearchTree.DisplayTree(node);

            //===============================

            //List<List<Node>> res = listFromTree(root);
            //foreach (var list in res)
            //{
            //    foreach (var node in list)
            //    {
            //        Console.Write(node.key + " =>");
            //    }
            //    Console.WriteLine();
            //}

            //================================

            //Console.WriteLine(searchParentWithParentPointer(root, root.left.left.left, root.right.left).key);
            //Console.WriteLine(searchParent(root, root.left.left.left, root.left).key);

            //================================

            printAllArrays(root);

        }
    }
}
