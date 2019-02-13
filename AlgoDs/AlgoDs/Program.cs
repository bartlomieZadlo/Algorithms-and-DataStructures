using AlgoDs.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDs
{
    class Program
    {
        static void Main(string[] args)
        {
            MinHeap h = new MinHeap(11);
            h.InsertElement(3);
            h.InsertElement(2);
            h.DeleteKey(1);
            h.InsertElement(15);
            h.InsertElement(5);
            h.InsertElement(4);
            h.InsertElement(45);
            Console.WriteLine(h.ExtractMin());
            Console.WriteLine(h.GetRoot());
            h.DecreaseKey(2, 1);
            Console.WriteLine(h.GetRoot());
            Console.ReadLine();
        }
    }
}
