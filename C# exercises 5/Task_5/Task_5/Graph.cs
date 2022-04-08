using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5
{
    public class Graph<T> where T : IComparable
    {

        // list of all the nodes in the graph. Use LinkedList from C#
        private LinkedList<GraphNode<T>> nodes;


        // constructor – set nodes to new empty list
        public Graph()
        {
            nodes = new LinkedList<GraphNode<T>>();
        }


        // only returns true if the graph’s list of nodes is empty
        public bool IsEmptyGraph()
        {
            return nodes.Count == 0;
        }


        // returns the total number of nodes present in the graph
        public int NumNodesGraph()
        {
            return nodes.Count;

        }


        // only returns true if node is present in the graph
        public bool ContainsGraph(GraphNode<T> node)
        {
            // to be completed. Hint: Search through the full list of nodes (search of the node is based on the id)

            foreach (GraphNode<T> n in nodes)
            {
                if (node != null)
                {
                    if (n.ID.CompareTo(node.ID) == 0)
                    {

                        return true;
                    }
                    else
                    {
                        return false;

                    }
                }
                return false;
            }
            return false;

        }


        // add a new node (with this “id”) to the list of nodes of the graph
        public void AddNode(T id)
        {
            nodes.AddLast(new GraphNode<T>(id));

        }


        //returns the node with this id
        public GraphNode<T> GetNodeByID(T id)
        {
            foreach (GraphNode<T> n in nodes)
            {
                if (id.CompareTo(n.ID) == 0) return n;
            }
            return null;
        }



        // return true if “to” is adjacent to “from”

        public bool IsAdjacent(GraphNode<T> from, GraphNode<T> to)
        {
            foreach (GraphNode<T> n in nodes)
            {
                if (n.ID.CompareTo(from.ID) == 0)
                {
                    if (from.GetAdjList().Contains(to.ID))
                    {
                        return true;
                    }
                }
            }

            return false;
        }



        // Add a directed edge between the node with id "from" and the node with id “to” 
        public void AddEdge(T from, T to)
        {
            GraphNode<T> n1 = GetNodeByID(from);
            GraphNode<T> n2 = GetNodeByID(to);


            if (n1 != null & n2 != null)
            {
                n1.AddEdge(n2);
            }
            else
                Console.WriteLine("Node/s not found in the graph. Cannot add the edge");

        }


    } //end class

}
