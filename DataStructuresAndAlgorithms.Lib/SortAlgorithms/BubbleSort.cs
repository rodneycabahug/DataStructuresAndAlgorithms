using DataStructuresAndAlgorithms.Lib.SortAlgorithms.Interfaces;

namespace DataStructuresAndAlgorithms.Lib.SortAlgorithms;

public class BubbleSort : ISortAlgorithm
{
    public void Execute(int[] array)
    {
        int opCounter = 0;

        if (array != null && array.Length > 1)
        {
            for (int i = 1; i <= array.Length; i++)
            {
                for (int j = 0; j < array.Length - i; j++)
                {
                    opCounter++;

                    if (array[j] > array[j + 1])
                    {
                        array[j] = array[j] + array[j + 1];
                        array[j + 1] = array[j] - array[j + 1];
                        array[j] = array[j] - array[j + 1];
                    }
                }
            }
        }

        Console.WriteLine($"{nameof(BubbleSort)} Operation Count => {opCounter}");
    }
}