using DataStructuresAndAlgorithms.Lib.DataStructures;
using Xunit;

namespace CSharpDumps.DataStructuresAndAlgorithms.LibTests;

public class DoublyLinkedListTests
{
    [Fact]
    public void IsEmpty_Return_True_If_Empty()
    {
        var list = new DoublyLinkedList<string>();

        Assert.True(list.IsEmpty);
    }

    [Fact]
    public void IsEmpty_Return_False_If_NotEmpty()
    {
        var list = new DoublyLinkedList<string>();

        list.AddFirst("a");

        Assert.False(list.IsEmpty);
    }

    [Fact]
    public void Size_Returns_The_Number_Of_Elements()
    {
        var list = new DoublyLinkedList<string>();
        var expectedCount = 3;

        list.AddFirst("a");
        list.AddFirst("ab");
        list.AddFirst("ac");

        Assert.Equal(expectedCount, list.Count);
    }

    [Fact]
    public void Contains_Return_True_If_Exists()
    {
        var list = new DoublyLinkedList<string>();
        var searchElement = "expected";

        list.AddFirst("a");
        list.AddFirst("ab");
        list.AddLast(searchElement);
        list.AddFirst("ac");

        Assert.True(list.Contains(searchElement));
    }

    [Fact]
    public void Contains_Return_False_If_NotExists()
    {
        var list = new DoublyLinkedList<string>();
        var searchElement = "expected";

        list.AddFirst("a");
        list.AddFirst("ab");
        list.AddFirst("ac");

        Assert.False(list.Contains(searchElement));
    }

    [Fact]
    public void Clear_Empties_List()
    {
        var list = new DoublyLinkedList<string>();
        var expectedCount = 0;

        list.AddFirst("a");
        list.AddFirst("ab");
        list.AddFirst("ac");

        list.Clear();

        Assert.Equal(expectedCount, list.Count);
        Assert.True(list.IsEmpty);
    }

    [Fact]
    public void AddFirst_Inserts_At_First_Position()
    {
        var list = new DoublyLinkedList<string>();
        var expectedFirst = "first";
        var expectedLast = "last";

        list.AddFirst(expectedLast);
        list.AddFirst("a");
        list.AddFirst("ab");
        list.AddFirst("ac");
        list.AddFirst(expectedFirst);

        Assert.Equal(expectedFirst, list.First);
        Assert.Equal(expectedLast, list.Last);
    }

    [Fact]
    public void AddLastFirst_Inserts_At_Last_Position()
    {
        var list = new DoublyLinkedList<string>();
        var expectedFirst = "first";
        var expectedLast = "last";

        list.AddLast(expectedFirst);
        list.AddLast("a");
        list.AddLast("ab");
        list.AddLast("ac");
        list.AddLast(expectedLast);

        Assert.Equal(expectedFirst, list.First);
        Assert.Equal(expectedLast, list.Last);
    }

    [Fact]
    public void RemoveFirst_Deletes_At_First_Position()
    {
        var list = new DoublyLinkedList<string>();
        var expectedFirst = "first";
        var expectedCount = 4;
        var itemToDelete = "asdf";

        list.AddFirst("a");
        list.AddFirst("ab");
        list.AddFirst("ac");
        list.AddFirst(expectedFirst);
        list.AddFirst(itemToDelete);

        list.RemoveFirst();

        Assert.Equal(expectedFirst, list.First);
        Assert.Equal(expectedCount, list.Count);
        Assert.False(list.Contains(itemToDelete));
    }

    [Fact]
    public void RemoveLast_Deletes_At_Last_Position()
    {
        var list = new DoublyLinkedList<string>();
        var expectedLast = "last";
        var expectedCount = 4;
        var itemToDelete = "asdf";

        list.AddLast("a");
        list.AddLast("ab");
        list.AddLast("ac");
        list.AddLast(expectedLast);
        list.AddLast(itemToDelete);

        list.RemoveLast();

        Assert.Equal(expectedLast, list.Last);
        Assert.Equal(expectedCount, list.Count);
        Assert.False(list.Contains(itemToDelete));
    }
}
