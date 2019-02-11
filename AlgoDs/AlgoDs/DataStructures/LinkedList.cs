using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDs.DataStructures
{
    public class LinkedList
    {
        private Node head;
        private Node last;
        private int length;

        public int Length { get => length; set => length = value; }
        public Node Head { get => head; set => head = value; }
        public Node Last { get => last; set => last = value; }

        public LinkedList()
        {
            Length = 1;
            Head = new Node();
            Last = Head;
        }

        public void Add(object elem)
        {
            if (Head.Element == null)
            {
                Head = new Node(elem);
                return;
            }

            Node Current = Head;
            while (Current.Next != null)
            {
                Current = Current.Next;
            }

            Current.Next = new Node(elem)
            {
                Previous = Current
            };

            Last = Current;
            Length++;
        }

        public void Remove(object elem)
        {
            Node current = Head;
            while (current.Element.ToString() != elem.ToString())
            {
                current = current.Next;
                if (current == null)
                {
                    return;
                }
            }

            Length--;

            if (Length == 0)
            {
                Head = new Node();
                return;
            }

            else if (current == Head)
            {
                Head = Head.Next;
                Head.Previous = null;
            }

            else if (current.Next == null)
            {
                current.Previous.Next = null;
            }

            else
            {
                current.Previous.Next = current.Next;
                current.Next.Previous = current.Previous;
            }
        }

        public void Replace(int index, object elem)
        {
            Node toInsert = new Node(elem);
            Node current = Head;
            while (index > 0)
            {
                current = current.Next;
                index--;
            }

            if (current == Head)
            {
                toInsert.Next = Head.Next;
                if (Length > 1)
                {
                    Head.Next.Previous = toInsert;
                }
                Head = toInsert;
            }
            else if (current.Next == null)
            {
                toInsert.Previous = current.Previous;
                current.Previous.Next = toInsert;
            }
            else
            {
                toInsert.Previous = current.Previous;
                current.Previous.Next = toInsert;
                toInsert.Next = current.Next;
                current.Next.Previous = toInsert;
            }
        }

        public void Insert(int index, object elem)
        {
            Node toInsert = new Node(elem);
            Node current = Head;
            if (index > Length - 1)
            {
                Add(elem);
                return;
            }

            while (index > 0)
            {
                current = current.Next;
                index--;
            }

            if (current == Head)
            {
                Node temp = new Node(Head.Element)
                {
                    Next = Head.Next,
                    Previous = toInsert
                };

                toInsert.Next = temp;
                Head = toInsert;

            }
            else
            {
                toInsert.Previous = current.Previous;
                toInsert.Next = current;
                current.Previous.Next = toInsert;
            }
            Length++;

        }
    }

    public class Node
    {
        private object element;
        private Node next;
        private Node previous;

        public Node(object elem)
        {
            Element = elem;
            Next = null;
        }

        public Node()
        {
            Element = null;
            Next = null;
            Previous = null;
        }

        public object Element { get => element; set => element = value; }
        public Node Next { get => next; set => next = value; }
        internal Node Previous { get => previous; set => previous = value; }
    }
}

