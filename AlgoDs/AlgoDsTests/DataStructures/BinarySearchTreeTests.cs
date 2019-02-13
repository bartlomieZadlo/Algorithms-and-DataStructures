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
    public class BinarySearchTreeTests
    {
        private BinarySearchTree testTree;
        private int[] testingArray;

        [TestInitialize()]
        public void TestInit()
        {
            testingArray = new int[] { 6, 7, 9, 13, 21, 45, 101, 102 };
            testTree = new BinarySearchTree(testingArray);
        }

        [TestMethod()]
        public void BinarySearchTreeTest()
        {
            Assert.IsTrue(BinarySearchTree.IsBSTUtil(testTree.Head, 6, 102));
        }

        [TestMethod()]
        public void FindElementTest()
        {
            foreach(int value in testingArray)
            {
                Assert.IsTrue(testTree.NumberInTree(testTree.Head, value));
            }
            
        }
    }
}