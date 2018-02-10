using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedListLibrary;

namespace DS_Project
{
    public class MyQueue
    {
        private CircularList queue;
        public MyQueue()
        {
            queue = new CircularList();
        }

        public int Lenght
        {
            get
            {
                return queue.Lenght;
            }
        }

        public void Enqueue(object obj)
        {
            queue.InsertAtBack(obj);
        }
        public object Dequeue()
        {
            return queue.RemoveFromFront();
        }

        public object this[int index]
        {
            set
            {
                queue[index] = value;
            }

            get
            {
                return queue[index];
            }
        }
        public object RemoveAt(int index)
        {
            return queue.RemoveAt(index);
        }
    }
}
