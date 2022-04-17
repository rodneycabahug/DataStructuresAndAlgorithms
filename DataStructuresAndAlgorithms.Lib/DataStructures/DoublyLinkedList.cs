namespace DataStructuresAndAlgorithms.Lib.DataStructures;

public class DoublyLinkedList<T>
{
    private Node<T>? _first = default;
    private Node<T>? _last = default;
    private int _count = 0;

    public T? First
    {
        get => _first == null ? default : _first.Value;
    }

    public T? Last
    {
        get => _last == null ? default : _last.Value;
    }

    public int Count
    {
        get => _count;
    }

    public bool IsEmpty => _count == 0;

    public void Clear()
    {
        if (_count == 0) return;

        while(_first?.Next != null)
        {
            _first = _first.Next;
            _first.Previous = null;
        }
        _first = _last = null;

        _count = 0;
    }

    public bool Contains(T item)
    {
        if (IsEmpty) return false;

        var _firstPointer = _first;
        var _lastPointer = _last;

        do
        {
            if ((_firstPointer?.Value?.Equals(item) ?? false)
                || (_lastPointer?.Value?.Equals(item) ?? false))
            {
                return true;
            }

            _firstPointer = _firstPointer?.Next;
            _lastPointer = _lastPointer?.Previous;

        } while (_firstPointer != null && _lastPointer != null);

        return false;
    }
    
    public void AddFirst(T item)
    { 
        if (item is null) throw new ArgumentNullException(nameof(item));

        _count++;
        var node = new Node<T>(item, null, null);

        if(_first is null)
        {
            _first = node;
            _last = node;
            return;
        }

        _first.Previous = node;
        node.Next = _first;
        _first = node;
    }

    public void RemoveFirst()
    {
        if (_first is null)
            return;

        _count--;

        if (_first.Next is null)
        {
            _first = _last = null;
            return;
        }

        _first = _first.Next;
        _first.Previous = null;
    }


    public void AddLast(T item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));

        _count++;
        var node = new Node<T>(item, null, null);

        if (_last is null)
        {
            _first = node;
            _last = node;
            return;
        }

        _last.Next = node;
        node.Previous = _last;
        _last = node;
    }

    public void RemoveLast()
    {
        if (_last is null)
            return;

        _count--;

        if (_last.Previous is null)
        {
            _first = _last = null;
            return;
        }

        _last = _last.Previous;
        _last.Next = null;
    }


    public class Node<I>
    {
        public Node(I value, Node<I>? previous, Node<I>? next)
        {
            Value = value;
            Previous = previous;
            Next = next;
        }

        public I Value { get; set; }
        public Node<I>? Next { get; set; }
        public Node<I>? Previous { get; set; }
    }
}
