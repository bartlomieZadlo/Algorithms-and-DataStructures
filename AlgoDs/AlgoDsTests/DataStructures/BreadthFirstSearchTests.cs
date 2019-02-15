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
    public class BreadthFirstSearchTests
    {
        private BreadthFirstSearch bfs;
        private List<Friend> createdFriends;

        [TestInitialize()]
        public void TestInit()
        {
            createdFriends = new List<Friend>();

            Friend Eva = new Friend("Eva");
            Friend Sophia = new Friend("Sophia");
            Friend Brian = new Friend("Brian");
            Friend Lisa = new Friend("Lisa");
            Friend Tina = new Friend("Tina");
            Friend John = new Friend("John");
            Friend Mike = new Friend("Mike");

            createdFriends.Add(Eva);
            createdFriends.Add(Sophia);
            createdFriends.Add(Brian);
            createdFriends.Add(Lisa);
            createdFriends.Add(Tina);
            createdFriends.Add(John);
            createdFriends.Add(Mike);

            Eva.IsFriendOf(Sophia);
            Eva.IsFriendOf(Brian);
            Sophia.IsFriendOf(Lisa);
            Sophia.IsFriendOf(John);
            Brian.IsFriendOf(Tina);
            Brian.IsFriendOf(Mike);

            bfs = new BreadthFirstSearch(Eva);
        }

        [TestMethod()]
        public void SearchTest()
        {
            string[] expectedNames = { "Eva", "Sophia", "Brian", "Lisa", "Tina", "John", "Mike" };
                
            foreach (string name in expectedNames)
            {
                Assert.AreNotEqual(null, bfs.Search(name));
            }
        }

        [TestMethod()]
        public void TraverseTest()
        {
            
            List<Friend> foundFriends = bfs.Traverse();

            CollectionAssert.AreEquivalent(createdFriends, foundFriends);
        }
    }
}