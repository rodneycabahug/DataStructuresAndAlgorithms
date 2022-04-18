using DataStructuresAndAlgorithms.Lib;
using DataStructuresAndAlgorithms.Lib.SearchAlgorithms;
using DataStructuresAndAlgorithms.Lib.SearchAlgorithms.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CSharpDumps.DataStructuresAndAlgorithms.LibTests;

public class BinarySearchTests
{
    [Theory]
    [ClassData(typeof(TestDataGenerator))]
    public void Execute_Returns_Index_If_Found_Otherwise_NegativeOne(int[] array, int itemToFind, int expectedResult)
    {
        ISearchAlgorithm algorithm = new BinarySearch();

        int searchResult = algorithm.Execute(array, itemToFind);

        Assert.Equal(expectedResult, searchResult);
    }

    [Fact]
    public void Search_ArrayExtension_Returns_Index_If_Found_By_BinarySearch()
    {
        int[] array = Enumerable.Range(0, 100).ToArray();

        var searchResult = array.Search<BinarySearch>(88);

        Assert.Equal(88, searchResult);
    }

    private class TestDataGenerator : IEnumerable<object[]>
    {
        private static readonly List<object[]> _testData = new()
        {
            new object[] { Enumerable.Range(0, 1000).ToArray(), 66, 66 },
            new object[] { Enumerable.Range(0, 77).ToArray(), 102, -1 },
            new object[] { Enumerable.Range(0, 50).ToArray(), 49, 49 },
            new object[] { Enumerable.Range(0, 100).ToArray(), 0, 0 },
            new object[] { Enumerable.Range(0, 66).ToArray(), -10, -1 },
            new object[] { Enumerable.Range(0, 1000000).ToArray(), 456789, 456789 }
        };

        public IEnumerator<object[]> GetEnumerator() => _testData.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _testData.GetEnumerator();
    }
}
