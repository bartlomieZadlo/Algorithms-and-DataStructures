using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDs.DataStructures
{

    public class Queue
    {
        private Node head;
        private Node last;
        private int size;
        private bool isEmpty;

        public Queue()
        {
            Head = new Node();
            Last = Head;
            Size = 0;
            IsEmpty = true;
        }

        public void Enqueue(object elem)
        {
            if(Head == null)
            {
                Head = new Node();
            }

            if (Head.Element == null)
            {
                Head.Element = elem;
                Size++;
                return;
            }

            Node toEnqueue = new Node(elem);
            Node currentNode = Head;
            while(currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }
            currentNode.Next = toEnqueue;
            Last = toEnqueue;
            Size++;
        }

        public object Dequeue()
        {
            Node toDequeue = Head;
            Head = Head.Next;
            Size--;
            return toDequeue.Element;
        }

        public object Peek()
        {
            return Head.Element;
        }

        public Node Last { get => last; set => last = value; }
        public Node Head { get => head; set => head = value; }
        public int Size { get => size; set => size = value; }
        public bool IsEmpty { get => isEmpty; set => isEmpty = value; }
    }

}
