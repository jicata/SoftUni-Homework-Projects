using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DictionaryHashTable
{
    public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
    {
        public const int initialCapacity = 16;
        public const float LoadFactor = 0.75f;
        private LinkedList<KeyValue<TKey, TValue>>[] slots;

        public int Count { get; private set; }

        public int Capacity
        {
            get { return this.slots.Length; }

        }

        public HashTable(int capacity = initialCapacity)
        {
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
            this.Count = 0;
        }

        public void Add(TKey key, TValue value)
        {
            this.GrowIfNeeded();
            int slotNumber = this.FindSlotNumber(key);
            if (this.slots[slotNumber] == null)
            {
                this.slots[slotNumber] = new LinkedList<KeyValue<TKey, TValue>>();
            }
            else
            {
                foreach (var element in this.slots[slotNumber])
                {
                    if (element.Key.Equals(key))
                    {
                        throw new ArgumentException("Key already exists: " + key);
                    }
                }
            }
            var newElement = new KeyValue<TKey, TValue>(key, value);
            this.slots[slotNumber].AddLast(newElement);
            this.Count++;
        }

        private int FindSlotNumber(TKey key)
        {
            int hash = Math.Abs(key.GetHashCode());
            return hash % this.Capacity;
        }

        private void GrowIfNeeded()
        {
            if ((float)(this.Count + 1) / (float)this.Capacity >= LoadFactor)
            {
                this.Grow();
            };
        }

        private void Grow()
        {
            var newHashTable = new HashTable<TKey, TValue>(this.Capacity * 2);
            foreach (var element in this)
            {
                newHashTable.Add(element.Key, element.Value);
            }
            this.slots = newHashTable.slots;
            this.Count = newHashTable.Count;
        }

        public bool AddOrReplace(TKey key, TValue value)
        {
            bool replaced = false;
            this.GrowIfNeeded();
            int slotNumber = this.FindSlotNumber(key);
            if (this.slots[slotNumber] == null)
            {
                this.slots[slotNumber] = new LinkedList<KeyValue<TKey, TValue>>();
            }
            else
            {
                foreach (var element in this.slots[slotNumber])
                {
                    if (element.Key.Equals(key))
                    {
                        replaced = true;
                        element.Value = value;
                        break;
                    }
                }
            }
            if (replaced)
            {
                return true;
            }
            var newElement = new KeyValue<TKey, TValue>(key, value);
            this.slots[slotNumber].AddLast(newElement);
            this.Count++;
            return false;
        }

        public TValue Get(TKey key)
        {
            var element = this.Find(key);
            if (element != null)
            {
                return element.Value;
            }
            throw new KeyNotFoundException("Key does not exist");
        }

        public TValue this[TKey key]
        {
            get
            {
                var element = this.Get(key);
                if (element == null)
                {
                    throw new KeyNotFoundException("Key does not exist");
                }
                return element;
            }
            set
            {
                this.AddOrReplace(key, value);

            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var element = this.Find(key);
            if (element == null)
            {
                value = default(TValue);
                return false;
            }
            value = element.Value;
            return true;
        }

        public KeyValue<TKey, TValue> Find(TKey key)
        {
            int slotNumber = this.FindSlotNumber(key);
            var elements = this.slots[slotNumber];
            if (elements != null)
            {
                foreach (var element in elements)
                {
                    if (element.Key.Equals(key))
                    {
                        return element;
                    }
                }
            }
            return null;
        }

        public bool ContainsKey(TKey key)
        {
            var element = this.Find(key);
            if (element == null)
            {
                return false;
            }
            return true;
        }

        public bool Remove(TKey key)
        {
            int index = this.FindSlotNumber(key);
            var elements = this.slots[index];
            if (elements != null)
            {
                foreach (var element in elements)
                {
                    if (element.Key.Equals(key))
                    {
                        elements.Remove(element);
                        this.Count--;
                        return true;
                    }
                }
            }
            return false;
        }

        public void Clear()
        {
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[this.Capacity];
            this.Count = 0;
        }

        public IEnumerable<TKey> Keys
        {
            get { return this.Select(x => x.Key); }
        }

        public IEnumerable<TValue> Values
        {
            get { return this.Select(x => x.Value); }
        }

        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            foreach (var elements in this.slots)
            {
                if (elements != null)
                {
                    foreach (var element in elements)
                    {
                        yield return element;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
