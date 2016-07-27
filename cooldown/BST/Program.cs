using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BST
{
    class Program
    {
        static void Main(string[] args)
        {
            string x = string.Empty;
            BST btree = new BST();

            do {
                x = Console.ReadLine();
                var errorCounter = Regex.Matches(x, @"[a-zA-Z]").Count;
                if ((errorCounter == 0) && (x.Length > 0))
                {
                    btree.Add(Convert.ToInt32(x));
                }
                else
                {
                    //print:
                    if (x == "print")
                    {
                        Console.WriteLine("printing the bst");
                        btree.print();
                        Console.WriteLine("--------------");
                    }
                    else if (x == "delete")
                    {
                        Console.WriteLine("Delete the Root (r) or a Node (n)?");
                        string y = Console.ReadLine();
                        if (y == "r")
                        {
                            btree.delete();
                        }
                        else if (y == "n")
                        {
                            Console.WriteLine("ID of the Node:");
                            string z = Console.ReadLine();
                            var errorCounter2 = Regex.Matches(z, @"[a-zA-Z]").Count;
                            if (errorCounter2 == 0)
                            {
                                btree.delete(Convert.ToInt32(z), ref btree.nodo);
                            }
                            else { Console.WriteLine("needs to be a number!"); }
                        }
                    }
                    else if (x == "search")
                    {
                        Console.Write("Value to search for:");
                        string y = Console.ReadLine();
                        var errorCounter2 = Regex.Matches(y, @"[a-zA-Z]").Count;
                        if (errorCounter2 == 0)
                        {
                            btree.FoundUnder = btree.nodo.Value.ToString();
                            var founded = btree.search(Convert.ToInt32(y), ref btree.nodo);
                            if (founded)
                                Console.WriteLine("Founded at " + btree.FoundUnder);
                            else
                                Console.WriteLine("not found!");

                        }
                    }


                }
            } while (x != "quit");
        }
    }

    // definition
    public class node
    {
        public int Value;
        public node left;
        public node right;
    }

    class BST
    {
        // definition:
        public node nodo = new node() { Value = 0, left = null, right = null};
        public string FoundUnder = String.Empty;

        // constructor
        public BST()
        {
        }
        
        // insert
        #region "insert into tree"
        public void Add(int valor)
        {
            // insert the value in the btree

            // check if the node has been init with its first value, if not then insert...
            if (nodo.Value == 0)
            {
                nodo.Value = valor;
                return;
            }

            //compare to see on what direction I'm going (left || right):
            if (valor == nodo.Value)
                return; //value is already inserted, avoiding duplicate on the parent node

            if (valor < nodo.Value)
            { // going left
                // if left is null
                if (nodo.left == null)
                {
                    nodo.left = new node() { Value = valor, left = null, right = null };
                    return;
                }
                else
                {
                    Add2(valor, ref nodo.left); // the needy greedy for the inserting

                }
            }
            else
            { // going right
              // if right is null
                if (nodo.right == null)
                {
                    nodo.right = new node() { Value = valor, left = null, right = null };
                    return;
                }
                else
                {
                    Add2(valor, ref nodo.right); // the needy greedy for the inserting
                }

            }

        }

        //recursion function:
        private void Add2(int valor, ref node nodo2)
        {
            // get the node (left || right) and keep finding until you can find a spot to add the new value
            if (nodo2 != null && nodo2.Value == 0)
            {
                nodo2.Value = valor;
                return;
            }

            if (valor < nodo2.Value)
            {
                // going to the left side
                if (nodo2.left == null)
                {
                    nodo2.left = new node() { Value = valor, left = null, right = null };
                    return;
                }
                else
                {
                    // this node exists, need to go deeper, maybe
                    // the recursive starts
                    Add2(valor, ref nodo2.left);
                }
            }
            else
            {
                // going to the right side
                if (nodo2.right == null)
                {
                    nodo2.right = new node() { Value = valor, left = null, right = null };
                    return;
                }
                else
                {
                    // this node exists, need to go deeper, maybe
                    // the recursive starts
                    Add2(valor, ref nodo2.right);
                }
            }

        }

        #endregion "insert into tree

        // print
        #region "print the tree"

        public void print()
        {
            String ForPrinting = String.Empty;
            int counter = 0;
            if (nodo != null && nodo.Value > 0)
            {
                ForPrinting = string.Format("Root Node -> [ {0}", nodo.Value.ToString());
                if (nodo.left == null && nodo.right == null)
                {
                    // you are at the end of that path

                    //closing the printing for the root node:
                   // if (counter == 0)
                   // {
                        ForPrinting += "]";
                   // }
                    Console.WriteLine(ForPrinting);
                    return;
                }
                if (nodo.left != null)
                {
                    ForPrinting += string.Format("-(P( {0} ,",nodo.left.Value);
                }
                if ((nodo.left != null) && (nodo.right != null))
                {
                    ForPrinting += string.Format("{0})", nodo.right.Value);
                }
                else if ((nodo.left == null) && (nodo.right != null))
                {
                    ForPrinting += string.Format("-(P( , {0}", nodo.right.Value);

                   
                }
                //closing the printing for the root node:
                //if (counter == 0)
                //{
                    ForPrinting += ")]";
                //}
                counter++;
                Console.WriteLine(ForPrinting);
                // what happen with children and children of children?
                if (nodo.left !=null && (nodo.left.left !=null || nodo.left.right != null) || (nodo.right !=null &&(nodo.right.left != null || nodo.right.right != null)))
                    print2(ref nodo, ref counter, ref nodo);

            }
        }
        // recursive:
        private void print2(ref node nodo2, ref int counter, ref node startingNode)
        {
            string PrintChild = String.Empty;

            if (nodo2.left == null && nodo2.right == null)
            {
                // you are at the end of that path
                return;
            }
            Console.Write("L" + counter.ToString() + " ( ");

            if (nodo2.left != null)
                Console.Write(nodo2.left.Value + " ,");
            else
                Console.Write("( ,");

            if (nodo2.right != null)
                Console.WriteLine(nodo2.right.Value + " )"); 
            else
                Console.Write( " )");
   
            counter++;
         
            if (nodo2.left != null) print2(ref nodo2.left, ref counter, ref startingNode);

            if (nodo2.right != null)
            {
                // if starting to go on the right side for printing I need to reset the counter to level 2
                try {
                    if (nodo2.right.Value == startingNode.right.Value && nodo2.right.left == startingNode.right.left && nodo2.right.right == startingNode.right.right)
                        counter = 2;
                }
                catch (Exception ex) { }
                print2(ref nodo2.right, ref counter, ref startingNode);
            }
           
        }

        #endregion

        // delete
        #region "delete the nodes"

        public void delete()
        {
            // Root (everything):
            // value of the node:
            node nodo = new node() { Value = 0, left = null, right = null };
            this.nodo = null;
            this.nodo = nodo;

        }
       
        public void delete(int nodeID, ref node nodo)
        {
            // first check matches
            if (nodo.Value == nodeID)
            {
                Console.WriteLine("lo encontre!");
                delete(ref nodo);
                return;
            }

            if (nodeID < nodo.Value && (nodo.left != null && nodo.left.Value == nodeID))
            {
                delete(ref nodo.left);
            }
            else if (nodeID < nodo.Value && nodo.left != null)
            {
                delete(nodeID, ref nodo.left);
            }
            else if (nodo.right != null && nodo.right.Value == nodeID)
            {
                delete(ref nodo.right);
            }
            else if(nodo.right !=null){
                delete(nodeID, ref nodo.right);
            }
            else
            {
                Console.WriteLine("not found!");
                return;
            }
                
        }

        private void delete(ref node DeleteNodo)
        {
            DeleteNodo = null;
        }
        #endregion

        // search
        #region "search the node"

        public Boolean search(int nodeID, ref node nodo)
        {
            bool founded = false;

            if (nodo.Value == nodeID)
            { // done
                return true;
            }
            if (nodo.Value > nodeID)
            {// goes to the left
                if (nodo.left != null)
                {
                    this.FoundUnder += " > " + nodo.left.Value;
                    founded = search(nodeID, ref nodo.left);
                }
               
            }
            else
            {// the goes to the right
                if (nodo.right != null)
                {
                    this.FoundUnder += " > " + nodo.right.Value;
                    founded = search(nodeID, ref nodo.right);
                }
               
            }

            return founded;

        }

        #endregion
    }
}
