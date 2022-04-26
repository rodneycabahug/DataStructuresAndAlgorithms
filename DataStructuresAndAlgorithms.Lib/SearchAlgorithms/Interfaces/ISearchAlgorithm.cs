using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.Lib.SearchAlgorithms.Interfaces;

public interface ISearchAlgorithm<T> where T : IComparable
{
    int Execute(T[] array, T itemToFind);
}
