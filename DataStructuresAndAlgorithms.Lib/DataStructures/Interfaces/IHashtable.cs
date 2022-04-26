using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.Lib.DataStructures.Interfaces;

public interface IHashtable<K,V>
{
    int Count { get; }
    K[] Keys { get; }
    V[] Values { get; }
    V this[K key] { get; set; }
    V GetValue(K key);
    void SetValue(K key, V value);
    void Add(K key, V value);
    void Remove(K key);
    void Clear();
    bool ContainsKey(K key);
    bool ContainsValue(V value);
}
