using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Algorithms
{
    class HashTable
    {
        public List<KeyValuePair> Collection { get; set; }

        public HashTable()
        {
            Collection = new List<KeyValuePair>();
        }

        public void Set(string key, int val)
        {
            for (int i = 0; i < Collection.Count; i++)
            {
                if (Collection[i].Key == key)
                {
                    Collection[i].Value = val;
                    return;
                }
            }
            Collection.Add(new KeyValuePair(key, val));
        }

        public void Clear(string key)
        {
            for (int i = 0; i < Collection.Count; i++)
            {
                if (Collection[i].Key == key)
                {
                    Collection.RemoveAt(i);
                    return;
                }
            }
        }

        public int Get(string key)
        {
            for (int i = 0; i < Collection.Count; i++)
            {
                if (Collection[i].Key == key) return Collection[i].Value;
            }

            throw new IndexOutOfRangeException();
        }

        public string Find(int val)
        {
            for (int i = 0; i < Collection.Count; i++)
            {
                if (Collection[i].Value == val) return Collection[i].Key;
            }

            return null;
        }
    }

    class KeyValuePair
    {
        public string Key { get; set; }
        public int Value { get; set; }

        public KeyValuePair(string key, int val)
        {
            Key = key;
            Value = val;
        }
    }
}