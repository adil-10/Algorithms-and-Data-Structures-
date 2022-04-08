using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_B_2
{
    class LinkListGen<T> where T : IComparable
    {
        private LinkGen<T> list;
        public LinkListGen()
        {
        }

        private int numitems;
        public void AddItem(T item)
        {
                
                list = new LinkGen<T>(item, list);
            
        }
        public void AppendItem(T item)
        {
            //numitems++;
            LinkGen<T> temp = list;
            if (temp == null)
                list = new LinkGen<T>(item);
            else
            {
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }

                temp.Next = new LinkGen<T>(item);
            }
        }

        public void RemoveItem(T item)
        {
            numitems--;
            LinkGen<T> temp = list;
            LinkListGen<T> newList = new LinkListGen<T>();
            while (temp != null)
            {
                if (item.CompareTo(temp.Data) != 0)
                    newList.AddItem(temp.Data);

                temp = temp.Next;
                
            }
            list = newList.list;

        }
        public string DisplayList()
        {
            LinkGen<T> temp = list;
            string buffer = "";
            while (temp != null) // move one link and add head to the buffer
            {
                //store data in buffer as string
                buffer = buffer + " " +temp.Data.ToString();
                //buffer = string.Concat(buffer, "");
                //Console.WriteLine(buffer);

                //need to concat them together
                temp = temp.Next;

            }

            return buffer;
        }
        public int Count()
        {

            return numitems;
        }

        public void InsertInOrder(T item)
        {
            numitems++;
            LinkGen<T> temp = list;
            LinkListGen<T> newList = new LinkListGen<T>();
            bool itemAdded = false;
            if (temp == null)
            {
                newList.AddItem(item);

            }

            else
            {
                while (temp != null)
                {

                    if (item.CompareTo(temp.Data) < 0)
                    {
                        if (itemAdded == false)
                        {
                            newList.AppendItem(item);
                        }

                        newList.AppendItem(temp.Data);
                        itemAdded = true;
                    }

                    else if ((item.CompareTo(temp.Data) >= 0))
                    {

                        newList.AppendItem(temp.Data);
                    }
                    temp = temp.Next;
                }
                if (itemAdded == false)
                {
                    newList.AppendItem(item);
                }
            }
            list = newList.list;
        }
    }
}
// if the items not been added, then add the item and set it to true
