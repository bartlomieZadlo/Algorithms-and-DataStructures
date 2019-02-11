using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDs.DataStructures
{
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
