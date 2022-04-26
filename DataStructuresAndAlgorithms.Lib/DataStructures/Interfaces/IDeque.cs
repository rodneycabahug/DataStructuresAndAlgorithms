using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.Lib.DataStructures.Interfaces;

public interface IDeque<T>: ISequence<T>
{
    void PushFront(T item);
    void PushBack(T item);
    T PopFront();
    T PopBack();
    T PeekFront();
    T PeekBack();
}