namespace DataStructuresAndAlgorithms.Lib.DataStructures.Interfaces;

public interface ISequence<T>
{
    int Count { get; }
    void Add(T item);
    void AddRange(T[] items);
    bool Contains(T item);
    void Clear();
    T[] ToArray();
}
