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
    public class LinkedListTests
    {
        private LinkedList array;

        [TestInitialize()]
        public void TestInit()
        {
            array = new LinkedList();
            array.Add(15);
            array.Add(10);
            array.Add(5);
            array.Add(1);
        }

        [TestMethod()]
        public void TestInitializing()
        {
            array = new LinkedList();
        }

        [TestMethod()]
        public void AddTest()
        {
            string expectedResult = "151051";
            Node current = array.Head;
            string actualResult = current.Element.ToString();
            while (current.Next != null)
            {
                current = current.Next;
                actualResult += current.Element;
            }
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(4, array.Length);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            string expectedResult = "1551";
            
            array.Remove(10);
            
            Node current = array.Head;
            string actualResult = current.Element.ToString();
            while (current.Next != null)
            {
                current = current.Next;
                actualResult += current.Element.ToString();
            }
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(3, array.Length);
        }

        [TestMethod()]
        public void RemoveHeadElement()
        {
            string expectedResult = "1051";

            array.Remove(15);

            Node current = array.Head;
            string actualResult = current.Element.ToString();
            while (current.Next != null)
            {
                current = current.Next;
                actualResult += current.Element.ToString();
            }
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(3, array.Length);
        }

        [TestMethod()]
        public void RemoveLastElement()
        {
            string expectedResult = "15105";

            array.Remove(1);

            Node current = array.Head;
            string actualResult = current.Element.ToString();
            while (current.Next != null)
            {
                current = current.Next;
                actualResult += current.Element.ToString();
            }
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(3, array.Length);
        }

        [TestMethod()]
        public void RemoveLastAndOnlyElement()
        {

            array.Remove(1);
            array.Remove(10);
            array.Remove(5);
            array.Remove(15);

            Node current = array.Head;
            object actualResult = current.Element;
            Assert.AreEqual(null, actualResult);
            Assert.AreEqual(0, array.Length);
        }

        [TestMethod()]
        public void ReplaceTest()
        {
            string expectedResult = "1510051";
            array.Replace(1, 100);
            Node current = array.Head;
            string actualResult = current.Element.ToString();
            while (current.Next != null)
            {
                current = current.Next;
                actualResult += current.Element;
            }
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(4, array.Length);
        }

        [TestMethod()]
        public void InsertTest()
        {
            string expectedResult = "509151051100";
            array.Insert(0, 50);
            array.Insert(100, 100);
            array.Insert(1, 9);
            Node current = array.Head;
            string actualResult = current.Element.ToString();
            while (current.Next != null)
            {
                current = current.Next;
                actualResult += current.Element;
            }
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(7, array.Length);
        }
    }
}