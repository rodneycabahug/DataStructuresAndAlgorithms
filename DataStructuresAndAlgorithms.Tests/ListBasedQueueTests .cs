using DataStructuresAndAlgorithms.Lib.DataStructures;
using DataStructuresAndAlgorithms.Lib.DataStructures.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DataStructuresAndAlgorithms.LibTests;

public class ListBasedQueueTests
{

    [Fact]
    public void Count_Returns_Number_Of_Items()
    {
        var itemCount = 20;
        var items = Enumerable.Range(0, itemCount).Select(i => i.ToString()).ToArray();
        var queue = new ListBasedQueue<string>(items);

        Assert.Equal(itemCount, queue.Count);
    }

    [Fact]
    public void Clear_Deletes_All_Items()
    {
        var itemCount = 20;
        var items = Enumerable.Range(0, itemCount).Select(i => i.ToString()).ToArray();
        var queue = new ListBasedQueue<string>(items);

        queue.Clear();

        Assert.Equal(0, queue.Count);
    }

    [Theory]
    [ClassData(typeof(TestDataForContains))]
    public void Contains_Returns_True_If_Item_Exists_Otherwise_False(ListBasedQueue<string> queue, string searchItem, bool expectedResult)
    {
        var result = queue.Contains(searchItem);

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Enqueue_Adds_Item_At_Last_Position()
    {
        var items = Enumerable.Range(0, 5).Select(i => i.ToString()).ToArray();
        var queue = new ListBasedQueue<string>(items);
        var expectedItem = "ItemToAdd";
        var expectedCount = 6;

        queue.Enqueue(expectedItem);

        Assert.True(queue.Contains(expectedItem));
        Assert.Equal(expectedCount, queue.Count);

        foreach(var i in items) _ = queue.Dequeue();

        var item = queue.Dequeue();

        Assert.Equal(expectedItem, item);
        Assert.Equal(0, queue.Count);
    }

    [Fact]
    public void Dequeue_Returns_And_Deletes_Item_At_Front_Position()
    {
        var items = Enumerable.Range(0, 5).Select(i => i.ToString()).ToArray();
        var queue = new ListBasedQueue<string>(items);
        var expectedItem = "0";
        var expectedCount = 4;

        var item = queue.Dequeue();

        Assert.False(queue.Contains(expectedItem));
        Assert.Equal(expectedItem, item);
        Assert.Equal(expectedCount, queue.Count);
    }

    [Fact]
    public void Dequeue_Throws_Exception_If_Empty()
    {
        var queue = new ListBasedQueue<string>();
        var expectedErrorMessage = "Queue is empty.";

        var exception = Assert.Throws<InvalidOperationException>(() => _ = queue.Dequeue());

        Assert.Equal(expectedErrorMessage, exception.Message);
    }

    [Fact]
    public void Peek_Returns_But_Keeps_Item_At_Front_Position()
    {
        var items = Enumerable.Range(0, 5).Select(i => i.ToString()).ToArray();
        var queue = new ListBasedQueue<string>(items);
        var expectedItem = "0";
        var expectedCount = 5;

        var item = queue.Peek();

        Assert.True(queue.Contains(expectedItem));
        Assert.Equal(expectedItem, item);
        Assert.Equal(expectedCount, queue.Count);
    }

    [Fact]
    public void Peek_Throws_Exception_If_Empty()
    {
        var queue = new ListBasedQueue<string>();
        var expectedErrorMessage = "Queue is empty.";

        var exception = Assert.Throws<InvalidOperationException>(() => _ = queue.Peek());

        Assert.Equal(expectedErrorMessage, exception.Message);
    }

    [Fact]
    public void ToArray_Returns_Queue_As_Array()
    {
        var items = Enumerable.Range(0, 5).Select(i => i.ToString()).ToArray();
        var queue = new ListBasedQueue<string>(items);

        var result = queue.ToArray();

        Assert.IsType<string[]>(result);
        Assert.Equal(items.Length, result.Length);
        for(int i = 0; i < items.Length; i++)
        {
            Assert.Equal(items[i], result[i]);
        }
        Assert.Equal(items.Length, queue.Count);
    }
}

internal class TestDataForContains : IEnumerable<object[]>
{
    private static readonly List<object[]> _testData = new()
    {
        new object[] { new ListBasedQueue<string>(Enumerable.Range(5, 10).Select(i => i.ToString()).ToArray()), "6", true },
        new object[] { new ListBasedQueue<string>(Enumerable.Range(5, 10).Select(i => i.ToString()).ToArray()), "4", false },
        new object[] { new ListBasedQueue<string>(), "7", false }
    };


    public IEnumerator<object[]> GetEnumerator() => _testData.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _testData.GetEnumerator();
}