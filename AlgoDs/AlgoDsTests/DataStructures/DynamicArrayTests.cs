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
    public class DynamicArrayTests
    {
        private DynamicArray array;

        [TestInitialize()]
        public void TestInit()
        {
            array = new DynamicArray(2);
            array.Add(15);
            array.Add(10);
            array.Add(5);
            array.Add(1);
        }

        [TestMethod()]
        public void CreationTest()
        {
            new DynamicArray(15);
        }

        [TestMethod()]
        public void AddTest()
        {
            string result = "15 10 5 1";
            Assert.AreEqual(result, string.Join(" ", array.Container));
        }

        [TestMethod()]
        public void RemoveTest()
        {
            array.Remove(0);
            array.Remove(1);
            string result = "10 1";
            Assert.AreEqual(result, string.Join(" ", array.Container));
        }

        [TestMethod()]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InvalidRemove()
        {
            array.Remove(10);
            array.Remove(-1);
        }

        [TestMethod()]
        public void InsertTest()
        {
            array.Insert(0, 100);
            array.Insert(500, 150);
            string result = "100 15 10 5 1 150";
            Assert.AreEqual(result, string.Join(" ", array.Container));
        }
    }
}