using DataStructuresAndAlgorithms.Lib.DataStructures.Interfaces;

namespace DataStructuresAndAlgorithms.Lib.DataStructures;

public class ListBasedQueue<T> : IQueue<T>, ISequence<T>
{
    private const string EmptyErrorMessage = "Queue is empty.";

    private readonly DoublyLinkedList<T> _queue = new();

    public ListBasedQueue()
    { }

    public ListBasedQueue(T[] items)
    {
        foreach (var item in items) _queue.AddLast(item);
    }

    public int Count => _queue.Count;

    public void Clear() => _queue.Clear();

    public bool Contains(T item) => _queue.Contains(item);

    public T Dequeue()
    {
        var item = _queue.First;
        if (item is null) throw new InvalidOperationException(EmptyErrorMessage);

        _queue.RemoveFirst();
        
        return item;
    }

    public void Enqueue(T item) => _queue.AddLast(item);

    public T Peek()
    {
        if (_queue.First is null) throw new InvalidOperationException(EmptyErrorMessage);

        return _queue.First;
    }

    public T[] ToArray() => _queue.ToArray();
}
