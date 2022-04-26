using DataStructuresAndAlgorithms.Lib.SearchAlgorithms.Interfaces;

namespace DataStructuresAndAlgorithms.Lib.SearchAlgorithms;

public class LinearSearch<T> : ISearchAlgorithm<T> where T : IComparable
{
    public int Execute(T[] array, T itemToFind)
    {
        int opCounter = 0;
        try
        {
            for (int index = 0; index < array.Length; index++)
            {
                if (array[index].CompareTo(itemToFind) == 0)
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
            Console.WriteLine($"{nameof(LinearSearch<T>)} Operation Count => {opCounter}");
        }
    }

    public int Execute(T[] array, Func<T, bool> predicate)
    {
        for (int i = 0; i < array.Length; i++)
            if (predicate(array[i]))
                return i;

        return -1;
    }
}