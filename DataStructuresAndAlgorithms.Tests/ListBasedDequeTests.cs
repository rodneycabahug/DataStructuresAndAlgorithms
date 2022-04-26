using DataStructuresAndAlgorithms.Lib.DataStructures;
using DataStructuresAndAlgorithms.Lib.DataStructures.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DataStructuresAndAlgorithms.LibTests;

public class ListBasedDequeTests
{
    [Fact]
    public void PeekBack_Returns_And_Keeps_Item_At_Back()
    { 
        var items = Enumerable.Range(1, 10).Select(i => i.ToString()).ToArray();
        var deque = new ListBasedDeque<string>(items);
        var expectedItem = "10";
        var expectedCount = 10;

        var item = deque.PeekBack();

        Assert.Equal(expectedItem, item);
        Assert.Equal(expectedCount, deque.Count);
    }

    [Fact]
    public void PeekBack_Throws_If_Empty()
    {
        var deque = new ListBasedDeque<string>();
        var expectedErrorMessage = "Deque is empty.";

        var exception = Assert.Throws<InvalidOperationException>(() => _ = deque.PeekBack());

        Assert.Equal(expectedErrorMessage, exception.Message);
    }

    [Fact]
    public void PeekFront_Returns_And_Keeps_Item_At_Front()
    {
        var items = Enumerable.Range(1, 10).Select(i => i.ToString()).ToArray();
        var deque = new ListBasedDeque<string>(items);
        var expectedItem = "1";
        var expectedCount = 10;

        var item = deque.PeekFront();

        Assert.Equal(expectedItem, item);
        Assert.Equal(expectedCount, deque.Count);
    }

    [Fact]
    public void PeekFront_Throws_If_Empty()
    {
        var deque = new ListBasedDeque<string>();
        var expectedErrorMessage = "Deque is empty.";

        var exception = Assert.Throws<InvalidOperationException>(() => _ = deque.PeekFront());

        Assert.Equal(expectedErrorMessage, exception.Message);
    }

    [Fact]
    public void PopBack_Returns_And_Removes_Item_At_Back()
    {
        var items = Enumerable.Range(1, 10).Select(i => i.ToString()).ToArray();
        var deque = new ListBasedDeque<string>(items);
        var expectedItem = "10";
        var expectedCount = 9;

        var item = deque.PopBack();

        Assert.Equal(expectedItem, item);
        Assert.Equal(expectedCount, deque.Count);
        Assert.False(deque.Contains(expectedItem));
    }

    [Fact]
    public void PopBack_Throws_If_Empty()
    {
        var deque = new ListBasedDeque<string>();
        var expectedErrorMessage = "Deque is empty.";

        var exception = Assert.Throws<InvalidOperationException>(() => _ = deque.PopBack());

        Assert.Equal(expectedErrorMessage, exception.Message);
    }

    [Fact]
    public void PopFront_Returns_And_Removes_Item_At_Front()
    {
        var items = Enumerable.Range(1, 10).Select(i => i.ToString()).ToArray();
        var deque = new ListBasedDeque<string>(items);
        var expectedItem = "1";
        var expectedCount = 9;

        var item = deque.PopFront();

        Assert.Equal(expectedItem, item);
        Assert.Equal(expectedCount, deque.Count);
        Assert.False(deque.Contains(expectedItem));
    }

    [Fact]
    public void PopFront_Throws_If_Empty()
    {
        var deque = new ListBasedDeque<string>();
        var expectedErrorMessage = "Deque is empty.";

        var exception = Assert.Throws<InvalidOperationException>(() => _ = deque.PopFront());

        Assert.Equal(expectedErrorMessage, exception.Message);
    }

    [Fact]
    public void PushFront_Adds_Item_At_Front()
    {
        var items = Enumerable.Range(1, 10).Select(i => i.ToString()).ToArray();
        var deque = new ListBasedDeque<string>(items);
        var expectedItem = "0";
        var expectedCount = 11;

        deque.PushFront(expectedItem);

        Assert.Equal(expectedItem, deque.PeekFront());
        Assert.Equal(expectedCount, deque.Count);
    }

    [Fact]
    public void PushBack_Adds_Item_At_Back()
    {
        var items = Enumerable.Range(1, 10).Select(i => i.ToString()).ToArray();
        var deque = new ListBasedDeque<string>(items);
        var expectedItem = "11";
        var expectedCount = 11;

        deque.PushBack(expectedItem);

        Assert.Equal(expectedItem, deque.PeekBack());
        Assert.Equal(expectedCount, deque.Count);
    }
}