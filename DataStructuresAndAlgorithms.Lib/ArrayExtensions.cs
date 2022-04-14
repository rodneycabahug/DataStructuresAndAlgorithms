using DataStructuresAndAlgorithms.Lib.SearchAlgorithms.Interfaces;
using DataStructuresAndAlgorithms.Lib.SortAlgorithms.Interfaces;

namespace CSharpDumps.DataStructuresAndAlgorithms.Lib;

public static class ArrayExtensions
{
    public static int Search<T>(this int[] array, int itemToFind) where T : ISearchAlgorithm, new()
    {
        ISearchAlgorithm searchAlgorithm = new T();
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