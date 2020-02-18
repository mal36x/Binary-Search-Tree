using System;
using System.Collections.Generic;
namespace BST
{
    class Program
    {
        static void Main(string[] args)
        {


            string[] files = System.IO.File.ReadAllLines(@"C:\Users\Malcolm\testprojects\p03input2.txt");
            string data = null;
            Tree<int> treeInt = null;
            Tree<Item> treeItem = null;
            foreach (string lines in files)
            {

                string[] inputs2 = lines.Split(" ");
                List<string> inputs = new List<string>(inputs2);
                int i;
                for (i = 0; i < inputs.Count; i++)
                {

                    if (inputs[i] == "")
                    {
                        inputs.RemoveAt(i);
                        i--;

                    }
                }

                switch (inputs[0])
                {

                    case "#":
                        Console.Write(lines);
                        break;

                    case "c":
                        data = inputs[1];
                        Console.WriteLine("Constructor() -- BSTree<" + data + ">");

                        try
                        {
                            if(data == "int"){
                                treeInt = new Tree<int>();
                            }else{
                                treeItem = new Tree<Item>();
                            }
                            
                        }
                        catch
                        {
                            Console.Write("Failed");
                        }

                        break;

                    case "d":
                        Console.Write("Destructor()-- BSTree" + data + ">");
                        treeInt = null;
                        treeItem = null;
                        break;

                    case "!":
                        try
                        {
                            Console.Write("*** Start Copy Constructor Test***");
                            Console.Write("Print Copy without new value");

                            if (data == "int")
                            {
                                Tree <int> emptyTree = new Tree<int>(treeInt);
                                emptyTree.printT();
                                
                                emptyTree.Insert(tree, inputs[1]);
                                Console.Write("Print Copy plus new value");
                                emptyTree.printT();
                                Console.Write("Print Original without new value");
                                treeInt.printT();

                            }
                            else
                            {
                                Tree <Item> emptyTree = new Tree<Item>(treeItem);
                                Item newItems = new Item();
                                emptyTree.InsertItem(newItems);
                                Console.Write("Print Copy plus new value");
                                emptyTree.printT();
                                Console.Write("Print Original without new value");
                                treeItem.printT();
                            }
                            
                            Console.WriteLine("CopyConstructor -- successful");


                        }
                        catch
                        {
                            Console.Write("Copy Constructor -- Failed: copy constructor");
                        }

                        Console.Write("*** End Copy Constructor Test ***");

                        break;

                    case "=":

                        try
                        {
                            Console.Write("*** Start Copy Operator = Test ***");
                            Node<string> emptyTree = new Node<string>(tree);
                            Console.Write("Print Copy without new Value");
                            emptyTree.printT();
                            if (data == "int")
                            {
                                emptyTree.Insert(inputs[1]);

                            }
                            else
                            {
                                newItems = new item  //stuff ...........i dont know what you did
                                emptyTree.insertItem(******);
                            } else
                            {
                                 newItems = new Item(******);
                                emptyTree.insertItem(newItems);
                            }
                            Console.WriteLine("Print Copy plus new value");
                            emptyTree.print();
                            Console.WriteLine("Print Original without new value");
                            tree.print();
                            Console.WriteLine("Operator= -- successful");
                        }
                        catch
                        {
                            Console.WriteLine("Operator= -- Failed: assignment operator");
                      }
                        Console.WriteLine("*** End Operator= Test ***");
                    break;

                    case "+":
                         addOutput = "InsertItem(";
                        try
                        {
                            if (data == "int")
                            {
                                addOutput += inputs[1] + ")";
                                tree.insertItem(parseInt(inputs[1]));

                                Console.WriteLine(addOutput)
    
                        }
                            else
                            {
                                 newItems = new Item(******);
                                tree.insertItem(newItems);

                                Console.WriteLine(addOutput)
                           }
                        }
                        catch
                        {
                            addOutput += "-- Failed";
                           Console.WriteLine(addOutput);

                        }
                        break;
                    case "-":
                        output = "DeleteItem(" + inputs[1] + ")";
                    try
                        {

                            if (data == "int")
                            {
                                tree.deleteItem(*****);
                                output += "Deleted " + inputs[1];
                            }
                            else
                            {
                                let item = new Item(parseInt(inputs[1]), "", -1);
                                tree.deleteItem(item);
                                output += "Deleted " + inputs[1];

                            }
                            Console.WriteLine(output);
                        }
                        catch
                        {
                            output += "-- Failed to delete";
                            Console.WriteLine(output);
                        }


                        break;
                    case "p":
                        if(data == "int"){
                            treeInt.printT();
                        }else{
                            treeItem.printT();
                        }
                        
                        break;
                    case "s":
                        if(data == "int"){
                            Console.WriteLine("Size() -- " + treeInt.Length);
                        }else{
                            Console.WriteLine("Size() -- " + treeItem.Length);
                        }
                        
                        break;
                    case "m":
                        if(data == "int"){
                            treeInt.MakeEmpty();
                        }else{
                            treeItem.MakeEmpty();
                        }
                        break;
                    case "<":
                        output2 = "Min() -- ";
                        try
                        {
                            //output2 += JSON.stringify(tree.min());
                            Console.WriteLine(output2);
                        }
                        catch
                        {
                            output2 += "Failed"
                           Console.WriteLine(output2);
                        }

                        break;
                    case ">":
                         output3 = "Max() -- ";
                        try
                        {
                           // output3 += JSON.stringify(tree.max());
                            Console.WriteLine(output3);
                        }
                        catch
                        {
                            output3 += "Failed";
                            Console.WriteLine(output3);
                        }

                        break;
                    case "l":
                         output4 = "TotalLevels() -- ";
                        try
                        {
                            output4 += tree.totalLevels();
                            Console.WriteLine(output4);
                        }
                        catch
                        {
                            output4 += "Failed";
                            Console.WriteLine(output4);
                        }

                        break;
                    case "?":
                         output5 = "Level('" + inputs[1] + "') -- ";
                        try
                        {
                            if (data == "int")
                            {
                                output5 += tree.level(inputs[1]);
                            }
                            else
                            {
                                 item = new Item(parseInt(inputs[1]), "", -1)
                               output5 += tree.level(item);
                            }
                        }
                        catch
                        {
                            output5 += "Failed";
                        }
                        Console.WriteLine(output5);
                    case "^":
                         output6 = "Parent('" + inputs[1] + "') -- ";
                        try
                        {
                            if (data == "int")
                            {
                               // output6 += tree.parent(parseInt(inputs[1]));
                            }
                            else
                            {
                                //item = new Item(parseInt(inputs[1]), "", -1)
                               output6 += tree.parent(item);
                            }
                        }
                        catch
                        {
                            output6 += "Failed";
                        }
                        Console.WriteLine(output6);

                }
            }
        }



    }


}
        }
    }
}
