using System;
using System.Collections;
using System.Collections.Generic;


namespace NChildtree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inserting nodes");


            var ntree = new NTree();
            ntree.AddRoot(new NTreeNodeFactory.NTreeNode(0, 3));
            ntree.GetRoot().AddNode(new NTreeNodeFactory.NTreeNode(1, 3));
            ntree.GetRoot().AddNode(new NTreeNodeFactory.NTreeNode(2, 3));
            ntree.GetRoot().AddNode(new NTreeNodeFactory.NTreeNode(3, 3));
            ntree.GetRoot().GetChild(0).AddNode(new NTreeNodeFactory.NTreeNode(15, 3));
            ntree.GetRoot().GetChild(0).AddNode(new NTreeNodeFactory.NTreeNode(17, 3));
            ntree.GetRoot().GetChild(0).AddNode(new NTreeNodeFactory.NTreeNode(20, 3));
            ntree.GetRoot().GetChild(1).AddNode(new NTreeNodeFactory.NTreeNode(24, 3));
            ntree.GetRoot().GetChild(1).AddNode(new NTreeNodeFactory.NTreeNode(29, 3));
            ntree.GetRoot().GetChild(1).AddNode(new NTreeNodeFactory.NTreeNode(31, 3));


            Console.WriteLine("Iterating though tree with BFS:");
            foreach (var elem in ntree.GetRoot().BreadthFirstSearch())
            {
                Console.WriteLine(elem != null ? elem.GetValue() : "NULL");
            }


            Console.WriteLine("Iterating though tree with DFS:");
            foreach (var elem in ntree.GetRoot().DepthFirstSearch())
            {
                Console.WriteLine(elem != null ? elem.GetValue() : "NULL");
            }


            Console.WriteLine("Printing breadth first:");
            ntree.GetRoot().PrintBreathFirst();
            Console.WriteLine("Printing depth first:");
            ntree.GetRoot().PrintDepthFirst();


            Console.WriteLine("Elements of level 1:");
            foreach (var elem in ntree.GetRoot().GetElementsByLevel(1))
                Console.WriteLine(elem != null ? elem.GetValue() : "NULL");


            Console.WriteLine("Elements of node by value 2:");
            foreach (var elem in ntree.GetRoot().GetElementsByValue(2))
                Console.WriteLine(elem != null ? elem.GetValue() : "NULL");


            Console.WriteLine($"Does tree contain node value 1: {ntree.GetRoot().Contains(1)}");


            Console.WriteLine("Removing first element of level 1");
            ntree.GetRoot().RemoveNode(0);


            Console.WriteLine($"Does tree contain node value 1: {ntree.GetRoot().Contains(1)}");
        }
    }


    public class NTree
    {
        public NTree() { maxChildren = int.MaxValue; }
        // Root node of tree
        public NTree(int maxNumChildren) { maxChildren = maxNumChildren; }

        // The maximum number of child nodes that a parent node may contain
        protected NTreeNodeFactory.NTreeNode root = null;     


        protected int maxChildren = 0;
        public void AddRoot(NTreeNodeFactory.NTreeNode node) { root = node; }
        public NTreeNodeFactory.NTreeNode GetRoot() { return (root); }
        public int MaxChildren { get { return (maxChildren); } }
    }




    public class NTreeNodeFactory
    {
        public NTreeNodeFactory(NTree root) { maxChildren = root.MaxChildren; }
        private int maxChildren = 0; public int MaxChildren { get { return (maxChildren); } }
        // Nested Node class
        public NTreeNode CreateNode(IComparable value) { return (new NTreeNode(value, maxChildren)); }     


        public class NTreeNode
        {
            public NTreeNode(IComparable value, int maxChildren)
            {
                if (value != null) { nodeValue = value; }
                childNodes = new NTreeNode[maxChildren];
            }


            protected IComparable nodeValue = null;
            protected NTreeNode[] childNodes = null;


            public int NumOfChildren { get { return (CountChildren()); } }
            public int CountChildren() { int currCount = 0; for (int index = 0; index <= childNodes.GetUpperBound(0); index++) { if (childNodes[index] != null) { ++currCount; currCount += childNodes[index].CountChildren(); } } return (currCount); }
            public int CountImmediateChildren() { int currCount = 0; for (int index = 0; index <= childNodes.GetUpperBound(0); index++) { if (childNodes[index] != null) { ++currCount; } } return (currCount); }
            public NTreeNode[] Children { get { return (childNodes); } }
            public NTreeNode GetChild(int index) { return (childNodes[index]); }
            public IComparable GetValue() { return (nodeValue); }
            public void AddNode(NTreeNode node) { int numOfNonNullNodes = CountImmediateChildren(); if (numOfNonNullNodes < childNodes.Length) { childNodes[numOfNonNullNodes] = node; } else { throw (new Exception("Cannot add more children to this node.")); } }


            public IEnumerable<NTreeNode> GetElementsByValue(IComparable value)
            {
                foreach (var elem in BreadthFirstSearch())
                {
                    var val = elem.GetValue();
                    if (val != null && val.CompareTo(value) == 0)
                        return elem.Children;
                }


                return null;
            }


            public IEnumerable<NTreeNode> GetElementsByLevel(int level)
            {
                if (level == 0)
                {
                    yield return this;
                    yield break;
                }


                level--;


                for (int index = 0; index < childNodes.Length; index++)
                {
                    if (childNodes[index] != null)
                    {
                        if (level == 0)
                            yield return childNodes[index];
                        else
                        {
                            foreach (var elem in childNodes[index].GetElementsByLevel(level - 1))
                                yield return elem;
                        }
                    }
                }
            }


            public bool Contains(IComparable value)
            {
                foreach (var elem in BreadthFirstSearch())
                {
                    var val = elem.GetValue();
                    if (val != null && val.CompareTo(value) == 0)
                        return true;
                }


                return false;
            }


            public IEnumerable<NTreeNode> BreadthFirstSearch()
            {
                Queue row = new Queue();
                row.Enqueue(this);
                while (row.Count > 0)
                {
                    NTreeNode currentNode = (NTreeNode)row.Dequeue();


                    yield return currentNode;

                    for (int index = 0; index < currentNode.CountImmediateChildren(); index++)
                    {
                        if (currentNode.Children[index] != null)
                        {
                            row.Enqueue(currentNode.Children[index]);
                        }
                    }
                }
            }


            public void PrintDepthFirst()
            {
                Console.WriteLine("this: " + nodeValue.ToString());
                for (int index = 0; index < childNodes.Length; index++)
                {
                    if (childNodes[index] != null)
                    {
                        Console.WriteLine("\tchildNodes[" + index + "]:  " + childNodes[index].nodeValue.ToString());
                    }
                    else
                    {
                        Console.WriteLine("\tchildNodes[" + index + "]:  NULL");
                    }
                }
                for (int index = 0; index < childNodes.Length; index++)
                {
                    if (childNodes[index] != null)
                    {
                        childNodes[index].PrintDepthFirst();
                    }
                }
            }


            public void PrintBreathFirst()
            {
                foreach (var elem in BreadthFirstSearch())
                {
                    Console.WriteLine(elem != null ? elem.GetValue() : "NULL");
                }
            }


            public IEnumerable<NTreeNode> DepthFirstSearch()
            {
                yield return this;
                foreach (var elem in DepthFirstSearchInternal())
                    yield return elem;
            }


            private IEnumerable<NTreeNode> DepthFirstSearchInternal()
            {
                for (int index = 0; index < childNodes.Length; index++)
                {
                    if (childNodes[index] != null)
                    {
                        yield return childNodes[index];
                        foreach (var elem in childNodes[index].DepthFirstSearchInternal())
                            yield return elem;
                    }
                }
            }


            public void RemoveNode(int index)
            {


                if (index < childNodes.GetLowerBound(0) || index > childNodes.GetUpperBound(0))
                {
                    throw (new ArgumentOutOfRangeException("index", index, "Array index out of bounds."));
                }
                else if (index < childNodes.GetUpperBound(0))
                {
                    Array.Copy(childNodes, index + 1, childNodes, index, childNodes.Length - index - 1);
                }
                childNodes.SetValue(null, childNodes.GetUpperBound(0));
            }
        }
    }
}