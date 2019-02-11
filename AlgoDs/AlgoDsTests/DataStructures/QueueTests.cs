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
    public class QueueTests
    {
        private Queue queue;

        [TestInitialize()]
        public void TestInit()
        {
            queue = new Queue();
        }

        [TestMethod()]
        public void EnqueueTest()
        {
            string expectedHeadElement = "Test";
            string expectedLastElement = "Test2";
            int excpetedSize = 2;
            queue.Enqueue("Test");
            queue.Enqueue("Test2");

            Assert.AreEqual(expectedHeadElement, queue.Head.Element);
            Assert.AreEqual(expectedLastElement, queue.Last.Element);
            Assert.AreEqual(excpetedSize, queue.Size);
        }

        [TestMethod()]
        public void Deque()
        {
            string exceptedElement = "Test";
            int expectedSize = 1;
            queue.Enqueue("Test");
            queue.Enqueue("Test2");

            string result = queue.Dequeue().ToString();
            Assert.AreEqual(exceptedElement, result);
            Assert.AreEqual(expectedSize, queue.Size);
        }

        [TestMethod()]
        public void PeekTest()
        {
            string expectedElement = "Test";
            int expectedSize = 2;

            queue.Enqueue("Test");
            queue.Enqueue("Test2");

            object result = queue.Peek();
            Assert.AreEqual(expectedElement, result);
            Assert.AreEqual(expectedSize, queue.Size);
        }
    }
}