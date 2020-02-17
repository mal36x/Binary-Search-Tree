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
        int Length = 0;

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
                        Length++;
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
                        Length++;
                    }
                    else
                    {
                        Insert(node.Right, itemType);
                    }

                }

            }

        }

        public void Delete(Node<T> node, Node<T> parent, T data){

        }
        public void DeleteItem(T data){
            Delete(this.root,null, data);
        }

        public void DeleteNode(Node<T> node, Node<T> parent){
            if(node.Left == null && node.Right == null){//no childern
                if(root == node){//is the root
                    root = null;
                }else if(parent.Right == node){
                    parent.Right = null;
                }else if(parent.Left == node){
                    parent.Left = null;
                }  
            }else if(node.Right == null){//only has a node on the left
                if(parent.Left == node){
                    parent.Left = node.Left;
                }else{
                    parent.Right = node.Left;
                }
            }else if(node.Left == null){//only has a node on the right
                if(parent.Right == node){
                    parent.Right = node.Right;
                }else{
                    parent.Left = node.Right;
                }
            }else{

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
        
        public T Max(){

            return GetMostLeft(this.root).Value;
        }

        public T Min(){
            return GetMostRight(this.root).Value;
        }

        public Node<T> GetMostLeft(Node<T> node){
            if(node.Left == null){
                return node;
            }else{
                return GetMostLeft(node.Left);
            }
        }

        public Node<T> GetMostRight(Node<T> node){
            if(node.Right == null){
                return node;
            }else{
                return GetMostRight(node.Right);
            }
        }

        public void MakeEmpty(){
            this.root = null;
            this.Length = 0;
        }
    
        public int TotalLevels(){
            return GetLevel(this.root);
        }

        private int GetLevel(Node<T> node){
            if(node == null){
                return 0;
            }else{
                int leftLevel = GetLevel(node.Left);
                int rightLevel = GetLevel(node.Right);
                if(leftLevel > rightLevel){
                    return leftLevel +1;
                }else{
                    return rightLevel +1;
                }
            }
        }

    }
}