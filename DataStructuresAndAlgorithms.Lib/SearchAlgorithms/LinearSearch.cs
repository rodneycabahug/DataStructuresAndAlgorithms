using DataStructuresAndAlgorithms.Lib.SearchAlgorithms.Interfaces;

namespace DataStructuresAndAlgorithms.Lib.SearchAlgorithms;

public class LinearSearch : ISearchAlgorithm
{
    public int Execute(int[] array, int itemToFind)
    {
        int opCounter = 0;
        try
        {
            for (int index = 0; index < array.Length; index++)
            {
                if (array[index] == itemToFind)
                {
                    opCounter = index + 1;
                    return index;
                }
            }

            opCounter = array.Length;
            return -1;
        }
        finally
        {
            Console.WriteLine($"{nameof(LinearSearch)} Operation Count => {opCounter}");
        }

    }
}