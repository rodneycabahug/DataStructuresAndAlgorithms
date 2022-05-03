using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.Lib.DataStructures.Interfaces
{
    // https://en.wikipedia.org/wiki/Heap_(data_structure)
    public interface IHeap<T>
    {
        int Size { get; }
        bool IsEmpty { get; }

        void Heapify(T[] items, bool clear = false);
        void Merge(IHeap<T> otherHeap);

        void Push(T item);
        T Peek();
        T Pop();
        T Replace(T item);

        T? Search(T item);
        bool Delete(T item);
        void Print();
    }
}
