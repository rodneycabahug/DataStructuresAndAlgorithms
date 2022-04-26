using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.Lib.DataStructures;
public class KeyValuePair<K, V>
{
    public K Key { get; set; }
    public V Value { get; set; }
    
    public KeyValuePair(K key, V value)
    {
        Key = key;
        Value = value;
    }
}