namespace DataStructuresAndAlgorithms.Lib.DataStructures.Interfaces;

public interface IStack<T>
{
    void Push(T item);
    T Pop();
    T Peek();
}
