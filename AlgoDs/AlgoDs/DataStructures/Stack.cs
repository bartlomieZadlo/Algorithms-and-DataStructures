using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDs.DataStructures
{
    public class Stack
    {
        private object[] container;
        private int size;
        private int index;

        public Stack(int size)
        {
            Container = new object[size];
            Size = size;
            Index = 0;
        }

        public void Push(object element)
        {
            if(Index == Size)
            {
                throw new StackOverflowException();
            }

            Container[Index] = element;
            Index++;
        }

        public object Pop()
        {
            if(Index == 0)
            {
                throw new StackUnderflowException();
            }
            object objToReturn = Container[Index - 1];
            Container[Index - 1] = 0;
            index--;
            return objToReturn;
        }

        public object Peek()
        {
            return Container[Index - 1];
        }

        public int SizeRemaining()
        {
            return Size - Index;
        }

        public object[] Container { get => container; set => container = value; }
        public int Size { get => size; set => size = value; }
        public int Index { get => index; set => index = value; }

        [Serializable]
        public class StackUnderflowException : Exception
        {
            public StackUnderflowException()
            {
            }

            public StackUnderflowException(string message) : base(message)
            {
            }

            public StackUnderflowException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected StackUnderflowException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
}
