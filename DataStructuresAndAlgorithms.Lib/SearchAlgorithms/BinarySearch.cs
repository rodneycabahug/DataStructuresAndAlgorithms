using DataStructuresAndAlgorithms.Lib.SearchAlgorithms.Interfaces;

namespace DataStructuresAndAlgorithms.Lib.SearchAlgorithms;

public class BinarySearch : ISearchAlgorithm
{
    private int _opCounter = 0;

    public int Execute(int[] array, int itemToFind)
    {
        try
        {
            return Search(array, 0, array.Length - 1, itemToFind);
        }
        finally
        {
            Console.WriteLine($"{nameof(BinarySearch)} Operation Count => {_opCounter}");
        }
    }

    private int Search(int[] array, int left, int right, int itemToFind)
    {
        _opCounter += 1;

        if (left > right)
            return -1;

        int middle = (left + right) / 2;

        if (array[middle] == itemToFind)
            return middle;

        if (array[middle] > itemToFind)
            return Search(array, left, middle - 1, itemToFind);

        //array[middle] < itemToFind
        return Search(array, middle + 1, right, itemToFind);
    }
}
