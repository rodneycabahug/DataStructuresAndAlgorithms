namespace DataStructuresAndAlgorithms.Lib.DataStructures.Interfaces;

public interface IStack<T>
{
    int Size { get; }
    bool IsEmpty { get; }
    void Push(T item);
    T Pop();
    T Peek();
    bool Contains(T item);
    void Clear();
}
