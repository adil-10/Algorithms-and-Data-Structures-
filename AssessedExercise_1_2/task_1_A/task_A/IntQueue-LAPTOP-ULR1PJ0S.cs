using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_A
{
    class IntQueue
    {

        private readonly int maxsize = 20;
        private string[] store;
        private int head = 0;
        private int tail = 0;
        private int numItems;

        public IntQueue()
        {
            store = new string[maxsize];
        }


        public IntQueue(int size)
        {
            maxsize = size;
            store = new string[maxsize];
        }

        public void Enqueue(string value)
        {
            numItems++;
            store[tail] = value;
            if (++tail == maxsize)
            {
                tail = 0;
            }
        }


        public string Dequeue()
        {
            string headItem;
            numItems--;
            headItem = store[head];

            if (++head == maxsize)
            {
                head = 0;
            }
            return headItem;
        }
        public int Peek()
        {
            return 0;

            /*string headItem;

            headItem = store[head];

            if (++head == maxsize)
            {
                head = 0;
            }
            return headItem;*/
        }

        public bool IsEmpty()
        {
            return head == 0;
            
            
        }

        public bool IsFull()
        {
            if(numItems == maxsize)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public int count()
        {
            return head;
        }
    } 

}
