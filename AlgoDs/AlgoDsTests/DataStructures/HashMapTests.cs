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
    public class HashMapTests
    {
        private HashMap hashMap;

        [TestInitialize()]
        public void TestInit()
        {
            hashMap = new HashMap(500);
        }

        [TestMethod()]
        public void AddTest()
        {
            string[] expectedKeys = { "test1", "test2", "test3" };
            string[] expectedValues = { "test3", "test4", "test5" };
            hashMap.Add("test1", "test3");
            hashMap.Add("test2", "test4");
            hashMap.Add("test3", "test5");

            for(int i = 0; i < expectedKeys.Length; i++)
            {
                Assert.AreEqual(expectedValues[i], hashMap.GetValue(expectedKeys[i]));
            }
        }

        [TestMethod()]
        public void OverFillTest()
        {

            for (int i = 0; i < 2 * hashMap.Container.Capacity; i++)
            {
                hashMap.Add(String.Format("test{0}", i), String.Format("test{0}", i));
            }
            
        }

        [TestMethod()]
        public void GetNonexistentElementTest()
        {
            hashMap.Add("test1", "test3");
            hashMap.Add("test2", "test4");
            hashMap.Add("test3", "test5");

            Assert.AreEqual(null, hashMap.GetValue("test4"));   
        }

        [TestMethod()]
        public void RemoveElementTest()
        {
            hashMap.Add("test1", "test3");
            hashMap.Add("test2", "test4");
            hashMap.Add("test3", "test5");
            hashMap.Add("test4", "test5");


            Assert.IsTrue(hashMap.Remove("test4"));
            Assert.AreEqual(null, hashMap.GetValue("test4"));
        }

        [TestMethod()]
        public void ClearAllTest()
        {
            string[] expectedKeys = { "test1", "test2", "test3" };
            

            hashMap.Add("test1", "test3");
            hashMap.Add("test2", "test4");
            hashMap.Add("test3", "test5");

            hashMap.ClearAll();



            for (int i = 0; i < expectedKeys.Length; i++)
            {
                Assert.AreEqual(null, hashMap.GetValue(expectedKeys[i]));
            }
        }


    }
}