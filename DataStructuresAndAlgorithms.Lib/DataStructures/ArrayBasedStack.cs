using DataStructuresAndAlgorithms.Lib.DataStructures.Interfaces;

namespace DataStructuresAndAlgorithms.Lib.DataStructures;

public class ArrayBasedStack<T> : IStack<T>
{
    private const string _emptyErrorMessage = "Stack is empty.";

    private int _top = -1;
    private int _initialCapacity;
    private T[] _stack;

    public ArrayBasedStack() : this(16) { }

    public ArrayBasedStack(int capacity)
    {
        _stack = new T[capacity];

        if (_initialCapacity != capacity)
            _initialCapacity = capacity;
    }

    public int Size => _top + 1;

    public bool IsEmpty => _top == -1;

    public void Clear()
    {
        _top = -1;
        Array.Resize(ref _stack, _initialCapacity);
    }

    public bool Contains(T item) => Array.IndexOf(_stack, item, 0, _top + 1) >= 0;

    public T? Peek() =>
        _top == -1
            ? throw new InvalidOperationException(_emptyErrorMessage)
            : _stack[_top];

    public T? Pop() =>
        _top == -1
            ? throw new InvalidOperationException(_emptyErrorMessage)
            : _stack[_top--];

    public void Push(T item)
    {
        if (_top + 1 == _stack.Length)
            Array.Resize(ref _stack, _stack.Length + _initialCapacity);

        _stack[++_top] = item;
    }
}
