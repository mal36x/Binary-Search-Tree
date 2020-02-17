using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public class Node<T>
    {

        //have to call all constr name of class
        public Node(T data)
        {
            Value = data;
        }

        public T Value;
        public Node<T> Left;
        public Node<T> Right;

    }
    public class Tree<T>
    {

        Node<T> root;


        public void Insert(Node<T> node, T itemType)
        {
            if (root == null)
            {
                root = new Node<T>(itemType);

            }
            else if (itemType is int)
            {
                int item = Convert.ToInt32(itemType);
                int nodeint = Convert.ToInt32(node.Value);
                if (item < nodeint)
                {
                    if (node.Left == null)
                    {
                        node.Left = new Node<T>(itemType);
                    }
                    else
                    {
                        Insert(node.Left, itemType);
                    }

                }
                if (item > nodeint)
                {
                    if (node.Right == null)
                    {
                        node.Right = new Node<T>(itemType);
                    }
                    else
                    {
                        Insert(node.Right, itemType);
                    }

                }

            }

        }

        public void printT()
        {
            List <T> preorder = new List <T>(); 
            List <T> inorder = new List <T>(); 
            List <T> postorder = new List <T>();

            PreOrder(root, preorder);
            InOrder(root, inorder);
            PostOrder(root, postorder);

            Console.Write("Print() \n-- Inorder = { ");

            foreach(T Value in inorder){
                Console.WriteLine(inorder);
            }
        }

        public void PreOrder(Node<T> tree, List<T> preorder)
        {
            if (tree != null)
            {
                preorder.Add(tree.Value);
                PreOrder(tree.Left, preorder);
                PreOrder(tree.Right, preorder);
            }
        }
        public void PostOrder(Node<T> tree, List<T> postorder)
        {
            if (tree != null)
            {

                PostOrder(tree.Left, postorder);

                PostOrder(tree.Right, postorder);
                postorder.Add(tree.Value);
            }
        }
        public void InOrder(Node<T> tree, List<T> inorder)
        {
            if (tree != null)
            {

                InOrder(tree.Left, inorder);

                inorder.Add(tree.Value);
                InOrder(tree.Right, inorder);
            }

        }
        public void Add(T input)
        {

        }
    }
}