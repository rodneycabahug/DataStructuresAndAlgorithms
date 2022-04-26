using DataStructuresAndAlgorithms.Lib.SearchAlgorithms.Interfaces;
using DataStructuresAndAlgorithms.Lib.SortAlgorithms.Interfaces;

namespace DataStructuresAndAlgorithms.Lib;

public static class ArrayExtensions
{
    public static int Search<T, I>(this I[] array, I itemToFind) where T : ISearchAlgorithm<I>, new() where I : IComparable
    {
        ISearchAlgorithm<I> searchAlgorithm = new T();
        return searchAlgorithm.Execute(array, itemToFind);
    }

    public static void Sort<T>(this int[] array) where T : ISortAlgorithm, new()
    {
        ISortAlgorithm sortAlgorithm = new T();
        sortAlgorithm.Execute(array);
    }

    public static void Print(this int[] array)
    {
        foreach (int element in array)
        {
            Console.Write($"{element} ");
        }
    }
}