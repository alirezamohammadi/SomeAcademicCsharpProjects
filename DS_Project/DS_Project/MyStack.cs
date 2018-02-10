using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedListLibrary;

namespace DS_Project
{
    public class MyStack
    {
        private CircularList Stack;
        public MyStack()
        {
            Stack = new CircularList();
        }
        public int Length
        {
            get
            {
                return Stack.Lenght;
            }
        }
        public void pushBack(object obj)
        {
            Stack.InsertAtBack(obj);
        }
        public object popBack()
        {
            return Stack.RemoveFromBack();
        }
        public object this[int index]
        {
            set
            {
                Stack[index] = value;
            }
            get
            {
                return Stack[index];
            }
        }
        public object RemoveAt(int index)
        {
            return Stack.RemoveAt(index);
        }
    }
}
