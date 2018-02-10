using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_Project
{
    public class TwoWayListNode
    {
        // automatic read & write property Data
        public object Data { get; set; }

        // automatic property Next
        public TwoWayListNode Next { get; set; }
        public TwoWayListNode Back { get; set; }


        // constructor to create TwoWayListNode that refers to dataValue
        // and is last node in list
        public TwoWayListNode(object dataValue)
                : this(dataValue, null,null)
        {
        } // end default constructor

        // constructor to create TwoWayListNode that refers to dataValue
        // and refers to next TwoWayListNode in List
        public TwoWayListNode(object dataValue, TwoWayListNode nextNode, TwoWayListNode backNode)
        {
            Data = dataValue;
            Next = nextNode;
            Back = backNode;
        } // end constructor
    } // end class TwoWayListNode

    public class TwoWayLinkedList
    {
        private TwoWayListNode firstNode;
        private TwoWayListNode lastNode;
        int lenght;

        // construct empty List
        public TwoWayLinkedList()
        {
            lenght = 0;//At first lenght value is 0.
            firstNode = lastNode = null;
        } // end default constructor

        //Lenght property to get lenght value
        public int Lenght
        {
            get { return lenght; }
        }

        //indexer implementation to use list like array.
        public object this[int index]
        {
            set
            {
                if (index >= 0 && index <= lenght)
                {
                    TwoWayListNode current = firstNode;
                    for (int i = 0; i < index; i++)
                        current = current.Next;
                    current.Data = value;
                }
                else
                    throw new IndexOutOfRangeException();
            }

            get
            {
                if (index >= 0 && index <= lenght)
                {
                    TwoWayListNode current = firstNode;
                    for (int i = 0; i < index; i++)
                        current = current.Next;
                    return current.Data;
                }
                else
                    throw new IndexOutOfRangeException();
            }
        }


        // Insert object at front of List. If List is empty, 
        // firstNode and lastNode will refer to same object.
        // Otherwise, firstNode refers to new node.
        public void InsertAtFront(object insertItem)
        {
            if (IsEmpty())
                firstNode = lastNode = new TwoWayListNode(insertItem);

            else
                firstNode = new TwoWayListNode(insertItem, firstNode, null);

            lenght++;//lenght increasment after adding an element.
        } // end method InsertAtFront





        // Insert object at end of List. If List is empty, 
        // firstNode and lastNode will refer to same object.
        // Otherwise, lastNode's Next property refers to new node.
        public void InsertAtBack(object insertItem)
        {
            if (IsEmpty())
                firstNode = lastNode = new TwoWayListNode(insertItem);

            else
                lastNode = lastNode.Next = new TwoWayListNode(insertItem, null, lastNode);

            lenght++;//lenght increasment after adding an element.
        } // end method InsertAtBack

        // remove first node from List
        public object RemoveFromFront()
        {
            if (IsEmpty())
                throw new EmptyListException();

            object removeItem = firstNode.Data; // retrieve data

            // reset firstNode and lastNode references
            if (firstNode == lastNode)
                firstNode = lastNode = null;

            else {
                firstNode = firstNode.Next;
                firstNode.Back = null;

            }

            lenght--;
            return removeItem; // return removed data
        } // end method RemoveFromFront



        // remove last node from List
        public object RemoveFromBack()
        {
            if (IsEmpty())
                throw new EmptyListException();

            object removeItem = lastNode.Data; // retrieve data

            // reset firstNode and lastNode references
            if (firstNode == lastNode)
                firstNode = lastNode = null;
            else
            {
                TwoWayListNode current = firstNode;

                // loop while current.Next is not lastNode
                while (current.Next != lastNode)
                    current = current.Next; // move to next node

                // current is new lastNode
                lastNode = current;
                current.Next = null;
            } // end else

            lenght--;
            return removeItem; // return removed data
        } // end method RemoveFromBack

        // return true if List is empty
        public bool IsEmpty()
        {
            return firstNode == null;
        } // end method IsEmpty

        // output List contents
        public void Display()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Empty ");
            } // end if
            else
            {
                Console.Write("The list is: ");

                TwoWayListNode current = firstNode;

                // output current node data while not at end of list
                while (current != null)
                {
                    Console.Write(current.Data + " ");
                    current = current.Next;
                } // end while

                Console.WriteLine("\n");
            } // end else
        } // end method Display
    }



    // class EmptyListException declaration
    public class EmptyListException : Exception
    {
        // parameterless constructor
        public EmptyListException()
            : base("The list is empty")
        {
            // empty constructor
        } // end EmptyListException constructor

        // one-parameter constructor
        public EmptyListException(string message)
            : base(message)
        {
            // empty constructor
        } // end EmptyListException constructor

        // two-parameter constructor
        public EmptyListException(string exception, Exception inner)
            : base(exception, inner)
        {
            // empty constructor
        } // end EmptyListException constructor
    } // end class EmptyListException
}
