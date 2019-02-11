using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDs.DataStructures
{
    public class DynamicArray
    {
        private int[] container;
        private int pointer;

        public DynamicArray(int size)
        {
            Container = new int[size];
            Pointer = 0;
        }

        public int Pointer { get => pointer; set => pointer = value; }
        public int[] Container { get => container; set => container = value; }

        public void Add(int elem)
        {
            if (Pointer > Container.Length - 1 )
            {
                ResizeContainer(1);
            }
            Container[Pointer] = elem;
            Pointer++;
        }

        public void Remove(int position)
        {
            int[] tempArray = new int[Container.Length - 1];
            int index = 0;
            while (index != position)
            {
                tempArray[index] = Container[index];
                index++;
            }
            while(index < Container.Length - 1)
            {
                tempArray[index] = Container[index + 1];
                index++;
            }
            Container = tempArray;
        }

        public void Insert(int position, int element)
        {
            if(position > Container.Length - 1 || position < 0)
            {
                Pointer++;
                Add(element);
                return;
            }

            int[] tempArray = new int[Container.Length + 1];
            int index = 0;

            while (index != position)
            {
                tempArray[index] = Container[index];
                index++;
            }

            tempArray[position] = element;
            

            while (index < Container.Length)
            {
                tempArray[index + 1] = Container[index];
                index++;
            }
            Container = tempArray;
        }

        private void ResizeContainer(int elems)
        {
            int[] tempArray = new int[Container.Length + elems];
            for(int index = 0; index < Container.Length; index++ )
            {
                tempArray[index] = Container[index];
            }
            Container = tempArray;
        }
    }
}
