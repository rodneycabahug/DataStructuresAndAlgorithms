namespace DataStructuresAndAlgorithms.Lib.DataStructures.Interfaces;

public interface ISequence<T>
{
    int Count { get; }
    bool Contains(T item);
    void Clear();
    T[] ToArray();
}
