using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.Lib.SearchAlgorithms.Interfaces;

public interface ISearchAlgorithm
{
    int Execute(int[] array, int itemToFind);
}
