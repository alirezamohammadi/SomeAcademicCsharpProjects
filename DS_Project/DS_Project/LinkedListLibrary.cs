// ListNode, List and EmptyListException class declarations.
using System;

namespace LinkedListLibrary
{
    // class to represent one node in a list
    class ListNode
    {
        // automatic read & write property Data
        public object Data { get; set; }

        // automatic property Next
        public ListNode Next { get; set; }

        // constructor to create ListNode that refers to dataValue
        // and is last node in list
        public ListNode(object dataValue)
                : this(dataValue, null)
        {
        } // end default constructor

        // constructor to create ListNode that refers to dataValue
        // and refers to next ListNode in List
        public ListNode(object dataValue, ListNode nextNode)
        {
            Data = dataValue;
            Next = nextNode;
        } // end constructor
    } // end class ListNode

    // class List declaration
    public class List
    {
        private ListNode firstNode;
        private ListNode lastNode;
        int lenght;

        // construct empty List
        public List()
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
                    ListNode current = firstNode;
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
                    ListNode current = firstNode;
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
                firstNode = lastNode = new ListNode(insertItem);

            else
                firstNode = new ListNode(insertItem, firstNode);

            lenght++;//lenght increasment after adding an element.
        } // end method InsertAtFront





        // Insert object at end of List. If List is empty, 
        // firstNode and lastNode will refer to same object.
        // Otherwise, lastNode's Next property refers to new node.
        public void InsertAtBack(object insertItem)
        {
            if (IsEmpty())
                firstNode = lastNode = new ListNode(insertItem);

            else
                lastNode = lastNode.Next = new ListNode(insertItem);

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

            else
                firstNode = firstNode.Next;

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
                ListNode current = firstNode;

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


        public object RemoveByValue(object value)
        {
            ListNode current = firstNode;

            if (IsEmpty())
                throw new EmptyListException();

            if (value.Equals(firstNode.Data))
            {
                object removeItem = firstNode.Data;
                firstNode = firstNode.Next;
                lenght--;
                return removeItem;
            }

            else if (value.Equals(lastNode.Data))
            {
                while (current.Next != lastNode)
                    current = current.Next;
                object removeItem = lastNode.Data;
                lastNode = current;
                current.Next = null;
                lenght--;
                return removeItem;
            }
            else {
                while (!value.Equals(current.Next.Data))
                    current = current.Next;

                object removeItem = current.Next.Data;
                current.Next = current.Next.Next;
                lenght--;
                return removeItem;
            }
        }


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

                ListNode current = firstNode;

                // output current node data while not at end of list
                while (current != null)
                {
                    Console.Write(current.Data + " ");
                    current = current.Next;
                } // end while

                Console.WriteLine("\n");
            } // end else
        } // end method Display
    } // end class List

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



    public class CircularList
    {
        private ListNode firstNode;
        private ListNode lastNode;
        int lenght;

        // construct empty List
        public CircularList()
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
                    ListNode current = firstNode;
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
                    ListNode current = firstNode;
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
            {
                firstNode = lastNode = new ListNode(insertItem, firstNode);
            }
            else
            {
                firstNode = new ListNode(insertItem, firstNode);
            }

            lenght++;//lenght increasment after adding an element.
        } // end method InsertAtFront

        // Insert object at end of List. If List is empty, 
        // firstNode and lastNode will refer to same object.
        // Otherwise, lastNode's Next property refers to new node.
        public void InsertAtBack(object insertItem)
        {
            if (IsEmpty())
                firstNode = lastNode = new ListNode(insertItem, firstNode);

            else
                lastNode = lastNode.Next = new ListNode(insertItem, firstNode);

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

            else
                firstNode = firstNode.Next;

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
                ListNode current = firstNode;

                // loop while current.Next is not lastNode
                while (current.Next != lastNode)
                    current = current.Next; // move to next node

                // current is new lastNode
                lastNode = current;
                current.Next = firstNode;
            } // end else

            lenght--;
            return removeItem; // return removed data
        } // end method RemoveFromBack


        public object RemoveByValue(object value)
        {
            ListNode current = firstNode;

            if (IsEmpty())
                throw new EmptyListException();

            if (value.Equals(firstNode.Data))
            {
                object removeItem = firstNode.Data;
                firstNode = firstNode.Next;
                lastNode.Next = firstNode;
                lenght--;
                return removeItem;
            }

            else if (value.Equals(lastNode.Data))
            {
                while (current.Next != lastNode)
                    current = current.Next;
                object removeItem = lastNode.Data;
                lastNode = current;
                current.Next = firstNode;
                lenght--;
                return removeItem;
            }
            else {
                while (!value.Equals(current.Next.Data))
                    current = current.Next;

                object removeItem = current.Next.Data;
                current.Next = current.Next.Next;
                lenght--;
                return removeItem;
            }
        }


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

                ListNode current = firstNode;

                // output current node data while not at end of list
                int count = 0;
                while (count < lenght)
                {
                    Console.Write(current.Data + " ");
                    current = current.Next;
                    count++;
                } // end while

                Console.WriteLine("\n");
            } // end else
        } // end method Display

        public object RemoveAt(int index)
        {
            ListNode current = firstNode;
            object temp;
            if (IsEmpty())
                throw new EmptyListException();

            if (Lenght == 1)
            {
                temp = current.Data;
                current.Next = null;
                firstNode = null;
                lenght--;
                return temp;
            }

            if (index == 0)
            {
                temp = firstNode.Data;
                firstNode = firstNode.Next;
                lastNode.Next = firstNode;
                lenght--;
                return temp;
            }

            else if (index == Lenght-1)
            {
                temp = lastNode.Data;
                while (current.Next != lastNode)
                {
                    current = current.Next;
                }

                current.Next = firstNode;
                lastNode = current;
                lenght--;
                return temp;

            }

            else
            {
                for (int i = 0; i < index - 1; i++)
                    current = current.Next;
                temp = current.Next.Data;
                current.Next = current.Next.Next;
                lenght--;
                return temp;
            }
        }

    }

} // end namespace LinkedListLibrary