using DataStructuresAndAlgorithms.Lib.DataStructures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.Lib.DataStructures
{
    public class BinaryHeap<T> : IBinaryHeap<T>
    {
        private const string HeapIsEmptyError = "Heap is empty.";
        private const int PrintPadding = 6;

        private readonly Comparer<T> _comparer;

        private T[] _data;
        private const int DefaultLength = 32;
        private const double LoadFactor = .64;

        private BinaryHeapType _type;
        public BinaryHeapType Type
        {
            get => _type;
            set
            {
                if (_type == value)
                    return;

                _type = value;

                var temp = new T[_size];
                Array.Copy(_data, temp, _size);
                Heapify(temp, true);
            }
        }

        private int _size = 0;
        public int Size => _size;

        public bool IsEmpty => _size == 0;

        public BinaryHeap() : this(BinaryHeapType.MinHeap, Comparer<T>.Default) { }

        public BinaryHeap(BinaryHeapType type) : this(type, Comparer<T>.Default) { }

        public BinaryHeap(BinaryHeapType type, Comparer<T> comparer)
        {
            _data = new T[DefaultLength];
            Type = type;
            _comparer = comparer;
        }

        public BinaryHeap(T[] items) : this(items, BinaryHeapType.MinHeap, Comparer<T>.Default) { }

        public BinaryHeap(T[] items, Comparer<T> comparer) : this(items, BinaryHeapType.MinHeap, comparer) { }

        public BinaryHeap(T[] items, BinaryHeapType type, Comparer<T> comparer)
        {
            _data = new T[items.Length * (int)(LoadFactor * 200) / 100];
            Type = type;
            _comparer = comparer;

            Heapify(items);
        }

        public void Heapify(T[] items, bool clear = false)
        {
            if (clear)
            {
                _size = 0;
                _data = _data = new T[items.Length * (int)(LoadFactor * 200) / 100];
            }

            foreach (var item in items)
                Push(item);
        }

        public void Merge(IHeap<T> otherHeap)
        {
            while (!otherHeap.IsEmpty)
            {
                Push(otherHeap.Pop());
            }
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException(HeapIsEmptyError);

            return _data[0];
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException(HeapIsEmptyError);

            var poppedRoot = _data[0];
            _size--;
            
            if (_size > 0)
            {
                Swap(_size, 0);
                SiftDown(0);
            }

            return poppedRoot;
        }

        public void Push(T item)
        {
            _ = item ?? throw new ArgumentNullException(nameof(item));

            _data[_size] = item;
            SiftUp(_size);

            _size++;
            EnsureCapacity();
        }

        public T Replace(T item)
        {
            _ = item ?? throw new ArgumentNullException(nameof(item));

            if (IsEmpty)
            {
                Push(item);
                return default(T);
            }

            var oldRoot = _data[0];

            _data[0] = item;
            SiftDown(0);

            return oldRoot;
        }

        public T? Search(T item)
        {
            var index = Search(0, item);
            if (index < 0)
                return default;

            return _data[index];
        }

        public bool Delete(T item)
        {
            var index = Search(0, item);
            if (index < 0)
                return false;

            _size--;
            (_data[index], _data[_size]) = (_data[_size], _data[index]);

            var parentIndex = (index - 1) / 2;
            if ((Type == BinaryHeapType.MinHeap && _comparer.Compare(_data[index], _data[parentIndex]) < 0)
                || (Type == BinaryHeapType.MaxHeap && _comparer.Compare(_data[index], _data[parentIndex]) > 0))
                SiftUp(index);
            else
                SiftDown(index);

            return true;
        }

        private int Search(int index, T item)
        {
            if (index >= _size)
                return -1;

            if (_comparer.Compare(_data[index], item) == 0)
                return index;

            var leftResult = Search(index * 2 + 1, item);
            if (leftResult != -1)
                return leftResult;

            var rightResult = Search(index * 2 + 2, item);
            if (rightResult != -1)
                return rightResult;

            return -1;
        }

        private void SiftUp(int index)
        {
            if (index == 0)
                return;

            var parentIndex = (index - 1) / 2;
            if (_type == BinaryHeapType.MinHeap)
            {
                if (_comparer.Compare(_data[index], _data[parentIndex]) < 0)
                {
                    Swap(index, parentIndex);
                    SiftUp(parentIndex);
                }
            }
            else
            {
                if (_comparer.Compare(_data[index], _data[parentIndex]) > 0)
                {
                    Swap(index, parentIndex);
                    SiftUp(parentIndex);
                }
            }   
        }

        private void SiftDown(int index)
        {
            var leftChildIndex = index * 2 + 1;
            if (leftChildIndex >= _size)
                return;

            var rightChildIndex = index * 2 + 2;

            if (_type == BinaryHeapType.MinHeap)
            {
                if (rightChildIndex < _size
                    && _comparer.Compare(_data[rightChildIndex], _data[leftChildIndex]) < 0
                    && _comparer.Compare(_data[rightChildIndex], _data[index]) < 0)
                {
                    Swap(rightChildIndex, index);
                    SiftDown(rightChildIndex);
                }
                else if (_comparer.Compare(_data[leftChildIndex], _data[index]) < 0)
                {
                    Swap(leftChildIndex, index);
                    SiftDown(leftChildIndex);
                }
            }
            else
            {
                if (rightChildIndex < _size
                    && _comparer.Compare(_data[rightChildIndex], _data[leftChildIndex]) > 0
                    && _comparer.Compare(_data[rightChildIndex], _data[index]) > 0)
                {
                    Swap(rightChildIndex, index);
                    SiftDown(rightChildIndex);
                }
                else if (_comparer.Compare(_data[leftChildIndex], _data[index]) > 0)
                {
                    Swap(leftChildIndex, index);
                    SiftDown(leftChildIndex);
                }

            }
        }

        private void Swap(int childIndex, int parentIndex) =>
            (_data[parentIndex], _data[childIndex])=(_data[childIndex], _data[parentIndex]);

        private void EnsureCapacity()
        {
            if(_size > _data.Length * LoadFactor)
                Array.Resize(ref _data, _data.Length * 2);
        }

        public void Print()
        {
            if (typeof(T) != typeof(int))
                throw new NotImplementedException();

            if (_size == 0)
                return;

            Print(0, 0);
        }

        private void Print(int index, int printPadding)
        {
            if (index >= _size)
                return;

            var rightChildIndex = index * 2 + 2;
            var leftChildIndex = index * 2 + 1;

            Print(rightChildIndex, printPadding + PrintPadding);

            Console.WriteLine();
            Console.Write(new String(' ', printPadding));
            Console.WriteLine(_data[index]);

            Print(leftChildIndex, printPadding + PrintPadding);
        }
    }
}
