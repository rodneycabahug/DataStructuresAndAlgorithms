using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.Lib.DataStructures.Interfaces
{
    // https://en.wikipedia.org/wiki/Binary_heap
    public interface IBinaryHeap<T> : IHeap<T>
    {
        BinaryHeapType Type { get; set; }
    }

    public enum BinaryHeapType
    {
        MinHeap,
        MaxHeap
    }
}
