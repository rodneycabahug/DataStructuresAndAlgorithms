namespace DataStructuresAndAlgorithms.Lib.DataStructures.Interfaces;

public interface IQueue<T>: ISequence<T>
{
    void Enqueue(T item);
    T Dequeue();
    T Peek();
}
