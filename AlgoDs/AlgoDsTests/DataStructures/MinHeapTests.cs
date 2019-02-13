using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoDs.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDs.DataStructures.Tests
{
    [TestClass()]
    public class MinHeapTests
    {
        private MinHeap minHeap;

        [TestInitialize()]
        public void TestInit()
        {
            minHeap = new MinHeap(5);
        }

        [TestMethod()]
        public void MinHeapTest()
        {
            int[] expectedValues = new int[] { 1, 5, 10, 15 };

            minHeap.InsertElement(5);
            minHeap.InsertElement(10);
            minHeap.InsertElement(15);
            minHeap.InsertElement(1);

            foreach (int value in expectedValues)
            {
                Assert.AreEqual(value, minHeap.ExtractMin());
            }
        }

        [TestMethod()]
        public void MinHeapPeekTest()
        {
            int[] expectedValues = new int[] { 1, 1, 1, 1 };

            minHeap.InsertElement(5);
            minHeap.InsertElement(10);
            minHeap.InsertElement(15);
            minHeap.InsertElement(1);

            foreach (int value in expectedValues)
            {
                Assert.AreEqual(value, minHeap.PeekRoot());
            }
        }

        [TestMethod()]
        public void MinHeapDeleteTest()
        {
            int[] expectedValues = new int[] {5, 15};

            minHeap.InsertElement(5);
            minHeap.InsertElement(10);
            minHeap.InsertElement(15);
            minHeap.InsertElement(1);

            minHeap.DeleteKey(0);
            minHeap.DeleteKey(1);

            foreach (int value in expectedValues)
            {
                Assert.AreEqual(value, minHeap.ExtractMin());
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(OverflowException))]
        public void MinHeapOverflowTest()
        {
            for (int i=0; i< minHeap.HeapCapacity + 1; i++)
            {
                minHeap.InsertElement(100 * i);
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(MinHeap.HeapEmptyException))]
        public void MinHeapExtracEmptyTest()
        {
            for (int i = 0; i < minHeap.HeapCapacity + 1; i++)
            {
                minHeap.ExtractMin();
            }
        }
    }
}