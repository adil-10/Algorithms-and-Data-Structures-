using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3
{
    class BSTree<T> : BinTree<T> where T : IComparable
    {  //root declared as protected in Parent Class – Binary Tree
        public BSTree()
        {
            root = null;
        }

        public void InsertItem(T item)
        {
            insertItem(item, ref root);
        }

        public void insertItem(T item, ref Node<T> tree)
        {
            if (tree == null)
                tree = new Node<T>(item);

            else if (item.CompareTo(tree.Data) < 0)
                insertItem(item, ref tree.Left);

            else if (item.CompareTo(tree.Data) > 0)
                insertItem(item, ref tree.Right);
        }

        public int HeightRecursive()
        {
            return Height(root);
        }
        protected int Height(Node<T> tree)
        //Return the length in nodes of the longest path in the tree
        {
            if (tree == null)
            {
                return 0;
            }
            else
            {
                return 1 + Math.Max(Height(tree.Left), Height(tree.Right));
            }
        }

        public int CountRecursive()
        {
            return Count(root);
        }
        protected int Count(Node<T> tree)
        //Return the number of nodes contained in the tree
        {
            if (tree == null)
            {
                return 0;
            }
            else
            {
                return 1 + (Count(tree.Left) + Count(tree.Right));
            }
        }

        public Boolean Contains(T item, ref Node<T> tree)
        {
            if (tree == null)
            {
                return false;
            }

            if (tree.Data.CompareTo( item) == 0)
            {
                return true;
            }


            if (item.CompareTo(tree.Data) < 0)
            {
                return Contains(item, ref tree.Left);
            }
            if (item.CompareTo(tree.Data) > 0)
            {
                return Contains(item, ref tree.Right);
            }

            return false;
        }


    }
}
