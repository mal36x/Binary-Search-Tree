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
                            if (data == "int")
                            {
                                treeInt = new Tree<int>();
                            }
                            else
                            {
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
                                Tree<int> emptyTree = new Tree<int>(treeInt);
                                emptyTree.printT();

                                emptyTree.InsertItem(Convert.ToInt32(inputs[1]));
                                Console.Write("Print Copy plus new value");
                                emptyTree.printT();
                                Console.Write("Print Original without new value");
                                treeInt.printT();

                            }
                            else
                            {
                                Tree<Item> emptyTree = new Tree<Item>(treeItem);
                                Item newItems = new Item(Convert.ToInt32(inputs[1]), inputs[2], Convert.ToDouble(inputs[3]));
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

                            if (data == "int")
                            {
                                Console.Write("*** Start Copy Operator = Test ***");
                                Tree<int> emptyTree = new Tree<int>(treeInt);
                                Console.Write("Print Copy without new Value");
                                emptyTree.printT();
                                emptyTree.InsertItem(Convert.ToInt32(inputs[1]));

                                Console.WriteLine("Print Copy plus new value");
                                emptyTree.printT();
                                Console.WriteLine("Print Original without new value");
                                treeInt.printT();

                            }
                            else
                            {
                                Console.Write("*** Start Copy Operator = Test ***");
                                Tree<Item> emptyTree = new Tree<Item>(treeItem);
                                Console.Write("Print Copy without new Value");
                                emptyTree.printT();
                                Item newItem = new Item(Convert.ToInt32(inputs[1]), inputs[2], Convert.ToDouble(inputs[3]));

                                emptyTree.InsertItem(newItem);
                                Console.WriteLine("Print Copy plus new value");
                                emptyTree.printT();
                                Console.WriteLine("Print Original without new value");
                                treeItem.printT();
                            }


                            Console.WriteLine("Operator= -- successful");
                        }
                        catch
                        {
                            Console.WriteLine("Operator= -- Failed: assignment operator");
                        }
                        Console.WriteLine("*** End Operator= Test ***");
                        break;

                    case "+":
                        Console.Write("InsertItem(");
                        try
                        {
                            if (data == "int")
                            {
                                Console.WriteLine( inputs[1] + ")");
                                treeInt.InsertItem(Convert.ToInt32(inputs[1]));

                            }
                            else
                            {
                                Item newItem = new Item(Convert.ToInt32(inputs[1]), inputs[2], Convert.ToDouble(inputs[3]));
                                treeItem.InsertItem(newItem);
                                Console.WriteLine(newItem);
                            }
                        }
                        catch
                        {

                        }
                        break;
                    case "-":
                        Console.Write("DeleteItem(" + inputs[1] + ")");
                        try
                        {

                            if (data == "int")
                            {
                                treeInt.DeleteItem(Convert.ToInt32(inputs[1]));
                                Console.WriteLine( "Deleted " + inputs[1]);
                            }
                            else
                            {
                                Item item = new Item(Convert.ToInt32(inputs[1]), "", -1);
                                treeItem.DeleteItem(item);
                                Console.WriteLine("Deleted " + inputs[1]);

                            }
                        }
                        catch
                        {
                            Console.WriteLine( "-- Failed to delete");
                            
                        }


                        break;
                    case "p":
                        if (data == "int")
                        {
                            treeInt.printT();
                        }
                        else
                        {
                            treeItem.printT();
                        }

                        break;
                    case "s":
                        if (data == "int")
                        {
                            Console.WriteLine("Size() -- " + treeInt.Length);
                        }
                        else
                        {
                            Console.WriteLine("Size() -- " + treeItem.Length);
                        }

                        break;
                    case "m":
                        if (data == "int")
                        {
                            treeInt.MakeEmpty();
                        }
                        else
                        {
                            treeItem.MakeEmpty();
                        }
                        break;
                    case "<":
                        Console.Write("Min() -- ");
                        try
                        {
                            if (data == "int")
                            {
                                Console.WriteLine(treeInt.Min());
                            }
                            else
                            {
                                Console.WriteLine(treeItem.Min());
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Failed");
                        }

                        break;
                    case ">":
                        Console.Write("Max() -- ");
                        try
                        {
                            if (data == "int")
                            {
                                Console.WriteLine(treeInt.Max());
                            }
                            else
                            {
                                Console.WriteLine(treeItem.Max());
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Failed");
                        }

                        break;
                    case "l":
                        Console.Write("TotalLevels() -- ");
                        try
                        {
                            if (data == "int")
                            {
                                Console.WriteLine(treeInt.TotalLevels());
                            }
                            else
                            {
                                Console.WriteLine(treeItem.TotalLevels());
                            }

                        }
                        catch
                        {
                            Console.WriteLine("Failed");
                        }

                        break;
                    case "?":
                        Console.Write("Level('" + inputs[1] + "') -- ");
                        try
                        {
                            if (data == "int")
                            {
                                Console.WriteLine(treeInt.Level(Convert.ToInt32(inputs[1])));
                            }
                            else
                            {
                                Item item = new Item(Convert.ToInt32(inputs[1]), "", -1);
                                Console.WriteLine(treeItem.Level(item));

                            }
                        }
                        catch
                        {
                            Console.WriteLine( "Failed");
                        }
                        break;
                    case "^":
                        Console.Write("Parent('" + inputs[1] + "') -- ");
                        try
                        {
                            if (data == "int")
                            {
                                Console.WriteLine(treeInt.Parent(Convert.ToInt32(inputs[1])));
                            }
                            else
                            {
                                Item item = new Item(Convert.ToInt32(inputs[1]), "", -1);
                                Console.WriteLine(treeItem.Parent(item));
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Failed");
                        }
                        break;

                }
            }
        }



    }


}