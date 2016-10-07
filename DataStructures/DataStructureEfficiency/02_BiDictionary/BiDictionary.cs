namespace _02_BiDictionary
{
    using System;
    using System.Collections.Generic;

    public class BiDictionary<K1,K2, T>
    {
        private Dictionary<K1, List<T>> valuesByFirstKey;
        private Dictionary<K2, List<T>> valuesBySecondKey;
        private Dictionary<Tuple<K1, K2>, List<T>> valuesByBothKeys;

        public BiDictionary()
        {
            this.valuesByFirstKey = new Dictionary<K1, List<T>>();
            this.valuesBySecondKey = new Dictionary<K2, List<T>>();
            this.valuesByBothKeys = new Dictionary<Tuple<K1, K2>, List<T>>();
        }                                           

        public void Add(K1 key1, K2 key2, T value)
        {
            Tuple<K1, K2> tuple = new Tuple<K1, K2>(key1, key2);
            if (!this.valuesByBothKeys.ContainsKey(tuple))
            {
                this.valuesByBothKeys.Add(tuple, new List<T>());
                
            }
            if (!this.valuesByFirstKey.ContainsKey(key1))
            {
                this.valuesByFirstKey.Add(key1, new List<T>());
               
            }
            if (!this.valuesBySecondKey.ContainsKey(key2))
            {
                this.valuesBySecondKey.Add(key2, new List<T>());
            }
            this.valuesByBothKeys[tuple].Add(value);
            this.valuesByFirstKey[key1].Add(value);
            this.valuesBySecondKey[key2].Add(value);
        }

        public IEnumerable<T> Find(K1 key1, K2 key2)
        {
            Tuple<K1, K2> tuple = new Tuple<K1, K2>(key1, key2);
            if (!this.valuesByBothKeys.ContainsKey(tuple))
            {
                return new List<T>();
            }
            return this.valuesByBothKeys[tuple];
        }

        public IEnumerable<T> FindByKey1(K1 key1)
        {
            if (!this.valuesByFirstKey.ContainsKey(key1))
            {
                return new List<T>();
            }
            var values = this.valuesByFirstKey[key1];
            return values;
        }
        public IEnumerable<T> FindByKey2(K2 key2)
        {
            if (!this.valuesBySecondKey.ContainsKey(key2))
            {
                return new List<T>();
            }
            var values = this.valuesBySecondKey[key2];
            return values;
        }

        public bool Remove(K1 key1, K2 key2)
        {
            Tuple<K1, K2> tuple = new Tuple<K1, K2>(key1, key2);
            if (!this.valuesByBothKeys.ContainsKey(tuple))
            {
                return false;
            }
            var allValues = this.valuesByBothKeys[tuple];
            var valuesByKeyOne = this.valuesByFirstKey[key1];
            var valuesByKeyTwo = this.valuesBySecondKey[key2];

            valuesByKeyOne.RemoveAll(x => allValues.Contains(x));
            valuesByKeyTwo.RemoveAll(x => allValues.Contains(x));
            this.valuesByBothKeys.Remove(tuple);
            

            this.valuesByFirstKey[key1] = valuesByKeyOne;
            this.valuesBySecondKey[key2] = valuesByKeyTwo;
          
            return true;
           
        }
    }
}
