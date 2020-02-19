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
        public int Length = 0;


        public Tree()
        {

        }

        public Tree(Tree<T> tree)
        {
            this.Length = tree.Length;
            CopyTree(root, tree.root);
        }

        private void CopyTree(Node<T> node, Node<T> copyNode)
        {



            if (copyNode.Right != null)
            {
                if (copyNode.Value is int)
                {
                    node.Right = new Node<T>(copyNode.Value);
                    CopyTree(node.Right, copyNode.Right);
                }
                else
                {
                    Item itemVal = node.Right.Value as Item;
                    Item cloned = itemVal.Clone();
                    node.Right = new Node<T>((T)Convert.ChangeType(cloned,typeof(T)));
                    CopyTree(node.Right, copyNode.Right);
                }
                
            }
            if(copyNode.Left != null){
                if (copyNode.Value is int)
                {
                    node.Left = new Node<T>(copyNode.Value);
                    CopyTree(node.Right, copyNode.Left);
                }
                else
                {
                    Item itemVal = node.Left.Value as Item;
                    Item cloned = itemVal.Clone();
                    node.Left = new Node<T>((T)Convert.ChangeType(cloned,typeof(T)));
                    CopyTree(node.Left, copyNode.Left);
                }
            }
        }

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
            else
            {
                Item item = itemType as Item;
                Item nodeint = node.Value as Item;
                if (item.ItemId < nodeint.ItemId)
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
                if (item.ItemId > nodeint.ItemId)
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

        public void InsertItem(T item)
        {
            Insert(this.root, item);
        }

        public void Delete(Node<T> node, Node<T> parent, T data)
        {
            if(node.Value is int){
                int dataValue = Convert.ToInt32(data);
                int nodeValue = Convert.ToInt32(node.Value);
                if(nodeValue == dataValue){
                    DeleteNode(node,parent);
                }
                if(node.Left !=null){
                    int leftData = Convert.ToInt32(node.Left.Value);
                    if(dataValue < leftData){
                        Delete(node.Left, node, data);
                    }
                    if(dataValue == leftData){
                        DeleteNode(node.Left,node);
                    }
                }
                if(node.Right !=null){
                    int rightData = Convert.ToInt32(node.Right.Value);
                    if(dataValue > rightData){
                        Delete(node.Right, node, data);
                    }
                    if(dataValue == rightData){
                        DeleteNode(node.Left,node);
                    }
                }
            }else{
                Item dataValue =data  as Item;
                Item nodeValue =node.Value as Item;
                if(nodeValue == dataValue){
                    DeleteNode(node,parent);
                }
                if(node.Left !=null){
                    Item leftData = node.Left.Value as Item;
                    if(dataValue.ItemId < leftData.ItemId){
                        Delete(node.Left, node, data);
                    }
                    if(dataValue.ItemId == leftData.ItemId){
                        DeleteNode(node.Left,node);
                    }
                }
                if(node.Right !=null){
                    Item rightData = node.Right.Value as Item;
                    if(dataValue.ItemId > rightData.ItemId){
                        Delete(node.Right, node, data);
                    }
                    if(dataValue.ItemId == rightData.ItemId){
                        DeleteNode(node.Left,node);
                    }
                }
            }
        }
        public void DeleteItem(T data)
        {
            Delete(this.root, null, data);
        }

        public void DeleteNode(Node<T> node, Node<T> parent)
        {
            if (node.Left == null && node.Right == null)
            {//no childern
                if (root == node)
                {//is the root
                    root = null;
                }
                else if (parent.Right == node)
                {
                    parent.Right = null;
                }
                else if (parent.Left == node)
                {
                    parent.Left = null;
                }
            }
            else if (node.Right == null)
            {//only has a node on the left
                if (parent.Left == node)
                {
                    parent.Left = node.Left;
                }
                else
                {
                    parent.Right = node.Left;
                }
            }
            else if (node.Left == null)
            {//only has a node on the right
                if (parent.Right == node)
                {
                    parent.Right = node.Right;
                }
                else
                {
                    parent.Left = node.Right;
                }
            }
            else
            {

            }
        }

        public void printT()
        {
            List<T> preorder = new List<T>();
            List<T> inorder = new List<T>();
            List<T> postorder = new List<T>();

            PreOrder(root, preorder);
            InOrder(root, inorder);
            PostOrder(root, postorder);

            Console.Write("Print() \n-- Inorder = { ");

            foreach (T Value in inorder)
            {
                Console.Write(" "+ Value);
            }

            Console.WriteLine(" }");

            Console.Write("-- PreOrder = { ");

            foreach (T Value in preorder)
            {
                Console.Write( " " + Value);
            }

            Console.WriteLine(" }");

            Console.Write("-- PostOrder = { ");

            foreach (T Value in postorder)
            {
                Console.Write(" "+ Value);
            }

            Console.WriteLine(" }");
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

        public T Max()
        {

            return GetMostLeft(this.root).Value;
        }

        public T Min()
        {
            return GetMostRight(this.root).Value;
        }

        public Node<T> GetMostLeft(Node<T> node)
        {
            if (node.Left == null)
            {
                return node;
            }
            else
            {
                return GetMostLeft(node.Left);
            }
        }

        public Node<T> GetMostRight(Node<T> node)
        {
            if (node.Right == null)
            {
                return node;
            }
            else
            {
                return GetMostRight(node.Right);
            }
        }

        public void MakeEmpty()
        {
            this.root = null;
            this.Length = 0;
        }

        public int TotalLevels()
        {
            return GetLevel(this.root);
        }

        public int Level(T data)
        {
            return 0;
        }

        public int GetItemLevel(T data, Node<T> node)
        {

            if (data is int)
            {
                if (Convert.ToInt32(data) == Convert.ToInt32(node.Value))
                {
                    return 0;
                }
                else if (Convert.ToInt32(data) < Convert.ToInt32(node.Value))
                {
                    return GetItemLevel(data, node.Left) + 1;
                }
                else
                {
                    return GetItemLevel(data, node.Right) + 1;
                }


            }
            else
            {
                Item item = data as Item;
                Item nodeData = node.Value as Item;
                if (item.ItemId == nodeData.ItemId)
                {
                    return 0;
                }
                else if (item.ItemId < nodeData.ItemId)
                {
                    return GetItemLevel(data, node.Left) + 1;
                }
                else
                {
                    return GetItemLevel(data, node.Right) + 1;
                }
            }

        }

        public T Parent(T data)
        {
            return GetParentNode(data, root).Value;
        }

        public Node<T> GetParentNode(T data, Node<T> node)
        {
            if (node == null || (node.Left == null && node.Right == null))
            {
                return null;
            }
            if (data is int)
            {
                int intData = Convert.ToInt32(data);
                int nodeData = Convert.ToInt32(node.Value);
                if (node.Right != null)
                {
                    int rightData = Convert.ToInt32(node.Right.Value);
                    if (rightData == intData)
                    {
                        return node;
                    }
                    if (intData > nodeData)
                    {
                        return GetParentNode(data, node.Right);
                    }
                    return null;
                }
                if (node.Left != null)
                {
                    int leftData = Convert.ToInt32(node.Left.Value);
                    if (leftData == intData)
                    {
                        return node;
                    }
                    if (intData < nodeData)
                    {
                        return GetParentNode(data, node.Left);
                    }
                    return null;
                }
                return null;
            }
            else
            {
                Item intData = data as Item;
                Item nodeData = node.Value as Item;
                if (node.Right != null)
                {
                    Item rightData = node.Right.Value as Item;
                    if (rightData == intData)
                    {
                        return node;
                    }
                    if (intData.ItemId > nodeData.ItemId)
                    {
                        return GetParentNode(data, node.Right);
                    }
                    return null;
                }
                if (node.Left != null)
                {
                    Item leftData = node.Left.Value as Item;
                    if (leftData.ItemId == intData.ItemId)
                    {
                        return node;
                    }
                    if (intData.ItemId < nodeData.ItemId)
                    {
                        return GetParentNode(data, node.Left);
                    }
                    return null;
                }
                return null;
            }
        }


        private int GetLevel(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                int leftLevel = GetLevel(node.Left);
                int rightLevel = GetLevel(node.Right);
                if (leftLevel > rightLevel)
                {
                    return leftLevel + 1;
                }
                else
                {
                    return rightLevel + 1;
                }
            }
        }

    }
}