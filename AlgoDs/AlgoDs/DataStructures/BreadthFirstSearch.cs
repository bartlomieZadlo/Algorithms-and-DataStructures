using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoDs.DataStructures
{
    public class Friend
    {
        public string Name { get; set; }
        private List<Friend> friends;
        private Guid iD;
    
        public Friend(string name)
        {
            Name = name;
            Friends = new List<Friend>();
            ID = Guid.NewGuid();    
        }
    
       
    
        public List<Friend> Friends { get => friends; set => friends = value; }
        public Guid ID { get => iD; set => iD = value; }
    
        public void IsFriendOf(Friend p)
        {
            FriendsList.Add(p);
        }
    
        List<Friend> FriendsList = new List<Friend>();
    
        public override string ToString()
        {
            return Name;
        }
    }
    
    public class BreadthFirstSearch
    {
        private Friend root;

        public Friend Root { get => root; set => root = value; }

        public BreadthFirstSearch(Friend root)
        {
            Root = root;
        }
    
        public Friend Search(string nameToSearchFor)
        {
            Queue friendQue = new Queue();
            HashSet<Friend> friendsSet = new HashSet<Friend>();
            friendQue.Enqueue(Root);
            friendsSet.Add(Root);
    
            while (friendQue.Size > 0)
            {
                Friend e = (Friend)friendQue.Dequeue();
                if (e.Name == nameToSearchFor)
                    return e;
                foreach (Friend friend in e.Friends)
                {
                    if (!friendsSet.Contains(friend))
                    {
                        friendQue.Enqueue(friend);
                        friendsSet.Add(friend);
                    }
                }
            }
            return null;
        }
    
        public List<Friend> Traverse()
        {
            Queue traverseOrder = new Queue();
            List<Friend> allFriends = new List<Friend>();
            Queue friendQueue = new Queue();
            HashSet<Friend> friendsSet = new HashSet<Friend>();

            friendQueue.Enqueue(Root);
            friendsSet.Add(Root);
    
            while (friendQueue.Size > 0)
            {
                Friend friend = (Friend)friendQueue.Dequeue();
                traverseOrder.Enqueue(friend);
    
                foreach (Friend person in friend.Friends)
                {
                    if (!friendsSet.Contains(person))
                    {
                        friendQueue.Enqueue(person);
                        friendsSet.Add(person);
                    }
                }
            }
    
            while (traverseOrder.Size > 0)
            {
                Friend friend = (Friend) traverseOrder.Dequeue();
                allFriends.Add(friend);
            }

            return allFriends;
        }
    }        
}