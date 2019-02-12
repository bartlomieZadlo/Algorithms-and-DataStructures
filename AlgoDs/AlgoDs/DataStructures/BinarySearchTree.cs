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
            CreateTree(Head, Data);
        }

        private void CreateTree(Node root, int[] data)
        {
            int rootIndex = GetRoot(data);

            if (rootIndex > 0)
            {
                root.Next = new Node(data[rootIndex - 1]);
                root.Previous = new Node(data[rootIndex + 1]);
                CreateTree(root.Next, data.Slice(0, rootIndex - 1));
                CreateTree(root.Previous, data.Slice(rootIndex + 2, data.Length-1));
            }else if (rootIndex == 0)
            {
                root.Next = new Node(data[rootIndex]);
                root.Previous = new Node(data[rootIndex + 1]);
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
            if(number > (int)node.Element)
            {
                
                return NumberInTree(node.Previous, number);
            }
            else if(number < (int)node.Element)
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
            return (IsBSTUtil(node.Next, min, (int)node.Element - 1) && IsBSTUtil(node.Previous, (int)node.Element + 1, max));
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
