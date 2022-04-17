using DataStructuresAndAlgorithms.Lib.DataStructures.Interfaces;

namespace DataStructuresAndAlgorithms.Lib.DataStructures;

public class ListBasedStack<T> : IStack<T>
{
    private const string _emptyErrorMessage = "Stack is empty.";

    private readonly DoublyLinkedList<T> _stack;

    public ListBasedStack()
    {
        _stack = new DoublyLinkedList<T>();
    }

    public int Size => _stack.Count;

    public bool IsEmpty => _stack.IsEmpty;

    public void Clear() => _stack.Clear();

    public bool Contains(T item) => _stack.Contains(item);

    public T Peek()
    {
        if (_stack.IsEmpty)
            throw new InvalidOperationException(_emptyErrorMessage);

        return _stack.Last;
    }


    public T Pop()
    {
        var top = Peek();
        _stack.RemoveLast();

        return top;
    }

    public void Push(T item) => _stack.AddLast(item);
}
