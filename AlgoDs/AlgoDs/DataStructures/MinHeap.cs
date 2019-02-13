using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDs.DataStructures
{
    class MinHeap
    {
        private int heapSize;
        private int heapCapacity;
        private int[] container;

        public int HeapCapacity { get => heapCapacity; set => heapCapacity = value; }
        public int HeapSize { get => heapSize; set => heapSize = value; }
        public int[] Container { get => container; set => container = value; }

        private int GetParentIndex(int index)
        {
            return ((index - 1) / 2);
        }

        private int GetLeftChildIndex(int index)
        {
            return (index * 2 + 1);
        }

        private int GetRightChildIndex(int index)
        {
            return (index * 2 + 2);
        }

        public int GetRoot()
        {
            return Container[0];
        }

        public MinHeap(int capacity)
        {
            HeapSize = 0;
            HeapCapacity = capacity;
            Container = new int[capacity];
        }

        public void InsertElement (int intToInsert)
        {
            if (heapSize == HeapCapacity)
            {
                throw new OverflowException();
            }
            HeapSize++;
            int elemIndex = HeapSize - 1;
            Container[elemIndex] = intToInsert;
            SortHeap(elemIndex);
        }

        public void DecreaseKey(int i, int new_val)
        {
            Container[i] = new_val;
            SortHeap(i);
        }

        public int ExtractMin()
        {
            if (HeapSize <= 0)
                throw new HeapEmptyException();
            if (HeapSize == 1)
            {
                HeapSize--;
                return GetRoot();
            }

            int root = GetRoot();
            Container[0] = Container[HeapSize - 1];
            HeapSize--;

            MinHeapify(0);

            return root;
        }

        public void DeleteKey(int i)
        {
            DecreaseKey(i, Int32.MinValue);
            ExtractMin();
        }

        private void SortHeap(int elemIndex)
        {
            while (elemIndex != 0 && Container[GetParentIndex(elemIndex)] > Container[elemIndex])
            {
                Swap(elemIndex, GetParentIndex(elemIndex), Container);
                elemIndex = GetParentIndex(elemIndex);
            }
        }

        private void MinHeapify(int i)
        {
            int leftNodeIndex = GetLeftChildIndex(i);
            int rightNodeIndex = GetRightChildIndex(i);
            int smallest = i;
            if (leftNodeIndex < HeapSize && Container[leftNodeIndex] < Container[i])
                smallest = leftNodeIndex;
            if (rightNodeIndex < HeapSize && Container[rightNodeIndex] < Container[smallest])
                smallest = rightNodeIndex;
            if (smallest != i)
            {
                Swap(i, smallest, Container);
                MinHeapify(smallest);
            }
        }

        private void Swap(int firstIndex, int secondIndex, int[] data)
        {
            int temp = data[firstIndex];
            data[firstIndex] = data[secondIndex];
            data[secondIndex] = temp;
        }

        [Serializable]
        private class HeapEmptyException : Exception
        {
            public HeapEmptyException()
            {
            }

            public HeapEmptyException(string message) : base(message)
            {
            }

            public HeapEmptyException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected HeapEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
}
