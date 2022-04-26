using DataStructuresAndAlgorithms.Lib.SearchAlgorithms.Interfaces;

namespace DataStructuresAndAlgorithms.Lib.SearchAlgorithms;

public class BinarySearch<T> : ISearchAlgorithm<T> where T : IComparable
{
    private int _opCounter = 0;

    public int Execute(T[] array, T itemToFind)
    {
        try
        {
            return Search(array, 0, array.Length - 1, itemToFind);
        }
        finally
        {
            Console.WriteLine($"{nameof(BinarySearch<T>)} Operation Count => {_opCounter}");
        }
    }

    private int Search(T[] array, int left, int right, T itemToFind)
    {
        _opCounter += 1;

        if (left > right)
            return -1;

        int middle = (left + right) / 2;

        if (array[middle].CompareTo(itemToFind) == 0)
            return middle;

        if (array[middle].CompareTo(itemToFind) > 0)
            return Search(array, left, middle - 1, itemToFind);

        //array[middle] < itemToFind
        return Search(array, middle + 1, right, itemToFind);
    }
}
