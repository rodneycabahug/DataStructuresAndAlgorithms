using DataStructuresAndAlgorithms.Lib.DataStructures.Interfaces;

namespace DataStructuresAndAlgorithms.Lib.DataStructures;

public class ListBasedDeque<T> : IDeque<T>
{
    private const string EmptyErrorMessage = "Deque is empty.";

    private readonly DoublyLinkedList<T> _deque = new();

    public ListBasedDeque()
    { }

    public ListBasedDeque(T[] items)
    {
        foreach (var item in items) _deque.AddLast(item);
    }

    public int Count => _deque.Count;

    public void Add(T item) => _deque.AddLast(item);

    public void AddRange(T[] items) => _deque.AddRange(items);

    public void Clear() => _deque.Clear();

    public bool Contains(T item) => _deque.Contains(item);

    public T PeekBack()
    {
        if (_deque.Last is null) throw new InvalidOperationException(EmptyErrorMessage);
        
        return _deque.Last;
    }
    

    public T PeekFront()
    {
        if (_deque.First is null) throw new InvalidOperationException(EmptyErrorMessage);

        return _deque.First;
    }

    public T PopBack()
    {
        var item = PeekBack();
        _deque.RemoveLast();
        return item;
    }

    public T PopFront()
    {
        var item = PeekFront();
        _deque.RemoveFirst();
        return item;
    }

    public void PushBack(T item) => _deque.AddLast(item);

    public void PushFront(T item) => _deque.AddFirst(item);

    public T[] ToArray() => _deque.ToArray();
}
