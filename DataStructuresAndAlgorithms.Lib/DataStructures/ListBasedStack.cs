using DataStructuresAndAlgorithms.Lib.DataStructures.Interfaces;

namespace DataStructuresAndAlgorithms.Lib.DataStructures;

public class ListBasedStack<T> : IStack<T>
{
    private const string _emptyErrorMessage = "Stack is empty.";

    private readonly LinkedList<T> _stack;

    public ListBasedStack()
    {
        _stack = new LinkedList<T>();
    }

    public int Size => _stack.Count;

    public bool IsEmpty => _stack.Count == 0;

    public void Clear() => _stack.Clear();

    public bool Contains(T item) => _stack.Contains(item);

    public T Peek() =>
        IsEmpty 
            ? throw new InvalidOperationException(_emptyErrorMessage) 
            : _stack.Last();


    public T Pop()
    {
        var top = Peek();
        _stack.RemoveLast();

        return top;
    }

    public void Push(T item) => _stack.AddLast(item);
}
