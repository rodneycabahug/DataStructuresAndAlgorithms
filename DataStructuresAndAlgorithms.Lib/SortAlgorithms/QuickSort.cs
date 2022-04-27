using DataStructuresAndAlgorithms.Lib.SearchAlgorithms;
using DataStructuresAndAlgorithms.Lib.SortAlgorithms.Interfaces;

namespace DataStructuresAndAlgorithms.Lib.SortAlgorithms;

public class QuickSort : ISortAlgorithm
{
    //private int _opCounter = 0;

    public void Execute(int[] array)
    {

        try
        {
            Sort(array, 0, array.Length - 1);
        }
        finally
        {
            //Console.WriteLine($"{nameof(QuickSort)} Operation Count => {_opCounter}");
        }
    }

    private void Sort(int[] array, int leftIndex, int rightIndex)
    {
        if (leftIndex >= 0 && rightIndex >= 0
            && leftIndex < rightIndex)
        {
            var pivotIndex = Partition(array, leftIndex, rightIndex);
            Sort(array, leftIndex, pivotIndex);
            Sort(array, pivotIndex + 1, rightIndex);
        }
    }

    private int Partition(int[] array, int leftIndex, int rightIndex)
    {
        var pivot = array[(int)Math.Floor(((decimal)leftIndex + rightIndex) / 2)];
        do
        {
            while (array[leftIndex] < pivot)
                leftIndex++;
            
            while (array[rightIndex] > pivot)
                rightIndex--;
            
            if (leftIndex >= rightIndex)
                return rightIndex;

            array[leftIndex] = array[leftIndex] + array[rightIndex];
            array[rightIndex] = array[leftIndex] - array[rightIndex];
            array[leftIndex] = array[leftIndex] - array[rightIndex];
        } while (true);
    }
}