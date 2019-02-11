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
    public class StackTests
    {
        private Stack stack;

        [TestInitialize()]
        public void TestInit()
        {
            stack = new Stack(5);
            stack.Push(15);
            stack.Push(10);
            stack.Push(5);
            stack.Push(1);
        }

        [TestMethod()]
        public void PushTest()
        {

            object[] result = new object[5];
            result[0] = 15;
            result[1] = 10;
            result[2] = 5;
            result[3] = 1;
            result[4] = 0;
            stack.Push(0);

            CollectionAssert.AreEqual(result, stack.Container);
            Assert.AreEqual(result.Length, stack.Index);
        }

        [TestMethod()]
        public void PopTest()
        {

            object result = 1;
            object expected = stack.Pop();
            Assert.AreEqual(result, expected);
            Assert.AreEqual(3, stack.Index);
            Assert.AreEqual(5, stack.Size);
            Assert.AreEqual(0, stack.Container[stack.Index]);
        }

        [TestMethod()]
        public void PeekTest()
        {

            object result = 1;
            object expected = stack.Peek();
            Assert.AreEqual(result, expected);
            Assert.AreEqual(4, stack.Index);
            Assert.AreEqual(5, stack.Size);
            Assert.AreEqual(result, stack.Container[stack.Index - 1]);
        }

        [TestMethod()]
        public void GetSizeTest()
        {
            int expectedSize = 5;
            int expectedRemainingSize = 1;
            Assert.AreEqual(expectedRemainingSize, stack.SizeRemaining());
            Assert.AreEqual(expectedSize, stack.Size);
        }

        [TestMethod()]
        [ExpectedException(typeof(StackOverflowException))]
        public void PushToFullStackTest()
        {
            stack.Push(5);
            stack.Push(7);
        }

        [TestMethod()]
        [ExpectedException(typeof(Stack.StackUnderflowException))]
        public void PopFromEmptyStackTest()
        {
            while (true)
            {
                stack.Pop();
            }
        }

    }
}