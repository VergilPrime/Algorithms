using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Algorithms
{
    class HashTable
    {
        public ICollection<KeyValuePair> Collection { get; set; }
    }

    class KeyValuePair
    {
        public string Key { get; set; }
        public int Value { get; set; }
    }
}