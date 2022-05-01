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
                throw new NotImplementedException();
                //if (_type == value)
                //    return;

                //_type = value;
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
            throw new NotImplementedException();
        }

        public void Delete(T item)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
