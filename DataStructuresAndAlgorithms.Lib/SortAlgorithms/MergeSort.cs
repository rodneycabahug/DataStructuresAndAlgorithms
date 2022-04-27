using DataStructuresAndAlgorithms.Lib.SearchAlgorithms;
using DataStructuresAndAlgorithms.Lib.SortAlgorithms.Interfaces;

namespace DataStructuresAndAlgorithms.Lib.SortAlgorithms;

public class MergeSort : ISortAlgorithm
{
    private int _opCounter = 0;

    public void Execute(int[] array)
    {

        try
        {
            Sort(array);
        }
        finally
        {
            Console.WriteLine($"{nameof(MergeSort)} Operation Count => {_opCounter}");
        }
    }

    private void Sort(int[] array)
    {
        if (array.Length <= 1)
            return;

        var halfLength = array.Length / 2;

        var left = new int[halfLength];
        for (int i = 0; i < left.Length; i++)
            left[i] = array[i];

        var right = new int[array.Length - halfLength];
        for (int i = 0; i < right.Length; i++)
            right[i] = array[halfLength + i];

        Sort(left);
        Sort(right);
        Merge(left, right, array);
    }

    private void Merge(int[] left, int[] right, int[] array)
    {
        for (int leftIndex = 0, rightIndex = 0, index = 0;
            index < array.Length;
            index++, _opCounter++)
        {
            if (leftIndex < left.Length && rightIndex < right.Length)
            {
                array[index] = left[leftIndex] < right[rightIndex] ? left[leftIndex++] : right[rightIndex++];
            }
            else if (leftIndex < left.Length)
            {
                array[index] = left[leftIndex++];
            }
            else
            {
                array[index] = right[rightIndex++];
            }
        }
    }
}