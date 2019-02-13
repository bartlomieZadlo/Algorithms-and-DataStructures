using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDs.DataStructures
{
    public class BinarySearchTree
    {
        private int[] data;
        private Node head;

        public BinarySearchTree(int[] data)
        {
            Data = data;
            int rootIndex = GetRoot(Data);
            Head = new Node(Data[rootIndex]);
            foreach(int value in Data)
            {
                Insert(Head, value);
            }
        }

        public void Insert(Node root, int data)
        {
            if ((int)root.Element < data)
            {
                if (root.Next == null)
                {
                    root.Next = new Node(data);
                }
                else
                {
                    Insert(root.Next, data);
                }
            }
            else if ((int)root.Element > data)
            {
                if (root.Previous == null)
                {
                    root.Previous = new Node(data);
                }
                else
                {
                    Insert(root.Previous, data);
                }
            }
        }

        private int GetRoot(int[] data)
        {
            if (data.Length == 0)
            {
                return -1;
            }
            
            if (data.Length % 2 == 0)
            {
                return data.Length / 2 - 1;
            }
            else
            { 
                return (data.Length - 1) / 2;
            }
        }

        public int[] Data { get => data; set => data = value; }
        public Node Head { get => head; set => head = value; }

        public bool NumberInTree(Node node ,int number)
        {
            if (node == null)
            {
                return false;
            }
            if(number < (int)node.Element)
            {
                return NumberInTree(node.Previous, number);
            }
            else if(number > (int)node.Element)
            { 
                return NumberInTree(node.Next, number);
            }

            return true;
        }

        public static bool IsBSTUtil(Node node, int min, int max)
        {
            /* an empty tree is BST */
            if (node == null)
            {
                return true;
            }

            /* false if this node violates the min/max constraints */
            if (((int)node.Element < min || (int)node.Element > max))
            {
                return false;
            }

            /* otherwise check the subtrees recursively  
            tightening the min/max constraints */
            // Allow only distinct values  
            return (IsBSTUtil(node.Previous, min, (int)node.Element - 1) && IsBSTUtil(node.Next, (int)node.Element + 1, max));
        }
    }

    public static class Extensions
    {
        /// <summary>
        /// Get the array slice between the two indexes.
        /// ... Inclusive for start index, exclusive for end index.
        /// </summary>
        public static T[] Slice<T>(this T[] source, int start, int end)
        {
            // Handles negative ends.
            if (end < 0)
            {
                end = source.Length + end;
            }
            int len = end - start;

            // Return new array.
            T[] res = new T[len];
            for (int i = 0; i < len; i++)
            {
                res[i] = source[i + start];
            }
            return res;
        }
    }
}
