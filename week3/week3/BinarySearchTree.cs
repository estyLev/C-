using System;
using System.Collections.Generic;
using System.Text;

namespace week3
{
    public class BinarySearchTree
    {

       public class Node
        {
            public int key;
            public Node left, right, parent;

        }

        // A utility function to create a new BST Node
        public static Node newNode(int item)
        {
            Node temp = new Node();
            temp.key = item;
            temp.left = null;
            temp.right = null;
            temp.parent = null;
            return temp;
        }

        public static void inorder(Node root)
        {
            if (root != null)
            {
                inorder(root.left);
                Console.Write("Node : " + root.key + " , ");
                if (root.parent == null)
                    Console.WriteLine("Parent : NULL");
                else
                    Console.WriteLine("Parent : " +
                                        root.parent.key);
                inorder(root.right);
            }
        }

       public static Node insert(Node node, int key)
        {
            /* If the tree is empty, return a new Node */
            if (node == null) return newNode(key);

            /* Otherwise, recur down the tree */
            if (key < node.key)
            {
                Node lchild = insert(node.left, key);
                node.left = lchild;

                // Set parent of root of left subtree
                lchild.parent = node;
            }
            else if (key > node.key)
            {
                Node rchild = insert(node.right, key);
                node.right = rchild;

                // Set parent of root of right subtree
                rchild.parent = node;
            }

            /* return the (unchanged) Node pointer */
            return node;
        }
        public static void DisplayTree(Node root)
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            InOrderDisplayTree(root);
            Console.WriteLine();
        }
        private static void InOrderDisplayTree(Node current)
        {
            if (current != null)
            {
                InOrderDisplayTree(current.left);
                Console.Write("({0}) ", current.key);
                InOrderDisplayTree(current.right);
            }
        }
    }
}
