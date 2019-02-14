using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDs.DataStructures
{
    public class HashMap
    {
        private List<object[]> container;
        private int hashIndex;
        private int hashedKey;

        public HashMap(int size)
        {
            Container = new List<object[]>(size);
            PopulateContainer(size);
        }

        private void PopulateContainer(int size)
        {

            for (int externalIndex = 0; externalIndex < size; externalIndex++)
            {
                Container.Add(new object[2 * size]);
                PopulateInternalArrays(externalIndex);   
            }
        }

        private void PopulateInternalArrays(int externalIndex)
        {
            for (int internalIndex = 0; internalIndex < Container[externalIndex].Length; internalIndex++)
            {
                Container[externalIndex][internalIndex] = null;
            }
        }

        private void HashKey(object key)
        {
            HashIndex = Math.Abs(key.GetHashCode() % Container.Capacity - 1);
            HashedKey = Math.Abs(key.GetHashCode() % 2 * Container.Capacity - 1);
        }


        public List<object[]> Container { get => container; set => container = value; }
        public int HashedKey { get => hashedKey; set => hashedKey = value; }
        public int HashIndex { get => hashIndex; set => hashIndex = value; }

        public void Add(object key, object value)
        {


            HashKey(key);
            
            Container[HashIndex][HashedKey] = value;
        }

        public object GetValue(object key)
        {
            HashKey(key);

            return Container[HashIndex][HashedKey];
        }

        public bool Remove(object key)
        {
            HashKey(key);

            foreach (object value in Container[HashIndex])
            {
                if (Container[HashIndex][HashedKey] != null)
                {
                    Container[HashIndex][HashedKey] = null;
                    return true;
                }
            }
            return false;
        }

        public void ClearAll()
        {
            int baseSize = Container.Count;
            Container = new List<object[]>(baseSize);
            PopulateContainer(baseSize);
        }
    
    }
}
