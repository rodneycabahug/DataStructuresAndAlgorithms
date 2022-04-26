using DataStructuresAndAlgorithms.Lib.DataStructures.Interfaces;
using DataStructuresAndAlgorithms.Lib.SearchAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.Lib.DataStructures;
public class SeparateChainingHashtable<K, V> : IHashtable<K, V>
{
    private const string DuplicateKeyErrorMessage = "Duplicate key.";
    private const string KeyDoesNotExistErrorMessage = "Key does not exist.";
    
    private const int DefaultTableSize = 64;
    private const double LoadFactor = .64;

    private int _count = 0;
    private DoublyLinkedList<KeyValuePair<K, V>>[] _hashtable;

    public SeparateChainingHashtable()
    {
        _hashtable = new DoublyLinkedList<KeyValuePair<K, V>>[DefaultTableSize];
    }

    public SeparateChainingHashtable((K Key, V Value)[] items) : this()
    {
        foreach (var item in items)
            Add(item.Key, item.Value);
    }

    public V this[K key]
    {
        get => GetValue(key);
        set => SetValue(key, value);
    }

    public int Count => _count;

    public K[] Keys
    {
        get {
            var keys = new DoublyLinkedList<K>();
            
            foreach (var bucket in _hashtable)
            {
                if (bucket is null)
                    continue;

                keys.AddRange(bucket.ToArray().Select(kvp => kvp.Key).ToArray());
            }

            return keys.ToArray();
        }
    }

    public V[] Values
    {
        get
        {
            var values = new DoublyLinkedList<V>();

            foreach (var bucket in _hashtable)
            {
                if (bucket is null)
                    continue;

                values.AddRange(bucket.ToArray().Select(kvp => kvp.Value).ToArray());
            }

            return values.ToArray();
        }
    }


    public void Add(K key, V value)
    {
        if (key is null) throw new ArgumentNullException(nameof(key));
        if (ContainsKey(key)) throw new InvalidOperationException(DuplicateKeyErrorMessage);

        var item = new KeyValuePair<K, V>(key, value);
        var index = GetHashtableIndex(key);

        if (_hashtable[index] is null)
            _hashtable[index] = new DoublyLinkedList<KeyValuePair<K, V>>();

        _hashtable[index].AddLast(item);
        _count++;

        EnsureCapacity();
    }

    private int GetHashtableIndex(K key)
    {
        if (key is null) throw new ArgumentNullException(nameof(key));

        return Math.Abs(key.GetHashCode()) % _hashtable.Length;
    }

    private void EnsureCapacity()
    {
        if (((double)_count / _hashtable.Length) < LoadFactor) return;

        var oldHashtable = _hashtable;
        _hashtable = new DoublyLinkedList<KeyValuePair<K, V>>[oldHashtable.Length * 2];
        _count = 0;

        for (var i = 0; i < oldHashtable.Length; i++)
        {
            if (oldHashtable[i] is null)
                continue;

            while (oldHashtable[i].First != null)
            {
                Add(oldHashtable[i].First.Key, oldHashtable[i].First.Value);
                oldHashtable[i].RemoveFirst();
            }
        }
    }

    public void Clear()
    {
        foreach (var bucket in _hashtable)
        {
            if (bucket is null) continue;

            bucket.Clear();
        }

        _count = 0;
    }

    public bool ContainsKey(K key)
    {
        if (key is null) throw new ArgumentNullException(nameof(key));

        var index = GetHashtableIndex(key);
        if (_hashtable[index] is null)
            return false;

        return _hashtable[index].Contains(item => key.Equals(item.Key));
        //return _hashtable[index].ToArray().Any(kv => key.Equals(kv.Key));
    }

    public bool ContainsValue(V value)
    {
        foreach(var bucket in _hashtable)
        {
            if (bucket is null)
                continue;

            if (bucket.Contains(item =>
                (value is null && item.Value is null)
                || (value is not null && value.Equals(item.Value))))
                return true;
        }

        return false;
    }

    public V GetValue(K key)
    {
        if (ContainsKey(key))
        {
            var index = GetHashtableIndex(key);
            var bucket = _hashtable[index].ToArray();
            foreach (var item in bucket)
            {
                if (key.Equals(item.Key))
                    return item.Value;
            }
        }

        throw new InvalidOperationException(KeyDoesNotExistErrorMessage);
    }

    public void Remove(K key)
    {
        throw new NotImplementedException();
    }

    public void SetValue(K key, V value)
    {
        if (ContainsKey(key))
        {
            var index = GetHashtableIndex(key);
            var bucket = _hashtable[index].ToArray();
            foreach (var item in bucket)
            {
                if (key.Equals(item.Key))
                {
                    item.Value = value;
                    return;
                }
            }

            throw new InvalidOperationException(KeyDoesNotExistErrorMessage);
        }
        else
        {
            Add(key, value);
        }
    }
}
