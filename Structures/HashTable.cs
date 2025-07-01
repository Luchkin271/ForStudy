using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForStady.Structures
{
    internal class HashTable<TKey, TValue>
    {
        private int Capacity = 16;
        private float LoadFactor = 0.75f;
        private LinkedList<KeyValuePair<TKey, TValue>>[] buckets;
        private int count;
        public HashTable()
        {
            buckets = new LinkedList<KeyValuePair<TKey, TValue>>[Capacity];
            count = 0;
        }
        public int Count => count;
        public void Add(TKey key, TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if((float)count / buckets.Length >= LoadFactor)
            {
                Resize();
            }
            int bucketIndex = GetBucketIndex(key);
            if (buckets[bucketIndex] == null)
            {
                buckets[bucketIndex] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }
            var bucket = buckets[bucketIndex];
            foreach(var pair in bucket)
            {
                if (pair.Key.Equals(key))
                {
                    throw new ArgumentException("Key already exist");
                }
            }
            bucket.AddLast(new KeyValuePair<TKey, TValue>(key, value));
            count++;
        }
        public KeyValuePair<TKey, TValue> Get(TKey key)
        {
            if(key == null)
            {
                throw new ArgumentNullException("key");
            }
            int bucketIndex = GetBucketIndex(key);
            var bucket = buckets[bucketIndex];
            if(bucket != null)
            {
                foreach(var pair in bucket)
                {
                    if (pair.Key.Equals(key))
                    {
                        return pair;
                    }
                }
            }
            throw new ArgumentException("Key not found");
        }
        public bool Remove(TKey key)
        {
            if(key == null)
            {
                throw new ArgumentNullException("key");
            }
            int bucketIndex = GetBucketIndex(key);
            var bucket = buckets[bucketIndex];
            if (bucket != null)
            {
                var node = bucket.First;
                while (node != null)
                {
                    if (node.Value.Key.Equals(key))
                    {
                        bucket.Remove(node);
                        count--;
                        return true;
                    }
                    node = node.Next;
                }
            }
            return false;
        }
        private int GetBucketIndex(TKey key)
        {
            int hashCode = key.GetHashCode();
            return (hashCode & 0x7FFFFFFF) % buckets.Length;
        }
        private void Resize()
        {
            int newCapacity = buckets.Length * 2;
            var newBuckets = new LinkedList<KeyValuePair<TKey, TValue>>[newCapacity];

            foreach (var bucket in buckets) 
            {
                if(bucket != null)
                {
                    foreach(var pair in bucket)
                    {
                        int newIndex = pair.Key.GetHashCode() % newCapacity;
                        if (newBuckets[newIndex] == null)
                        {
                            newBuckets[newIndex] = new LinkedList<KeyValuePair<TKey, TValue>>();
                        }
                        newBuckets[newIndex].AddLast(pair);
                    }
                }
            }
            buckets = newBuckets;
        }
    }
}
