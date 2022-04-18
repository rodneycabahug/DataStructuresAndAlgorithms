using DataStructuresAndAlgorithms.Lib.DataStructures;
using DataStructuresAndAlgorithms.Lib.DataStructures.Interfaces;
using System;
using Xunit;

namespace CSharpDumps.DataStructuresAndAlgorithms.LibTests;

public class ListBasedStackTests
{
    [Fact]
    public void IsEmpty_Return_True_If_Empty()
    {
        IStack<string> stack = new ListBasedStack<string>();

        Assert.True(stack.IsEmpty);
    }

    [Fact]
    public void IsEmpty_Return_False_If_NotEmpty()
    {
        IStack<string> stack = new ListBasedStack<string>();

        stack.Push("string");

        Assert.False(stack.IsEmpty);
    }

    [Fact]
    public void Size_Returns_The_Number_Of_Elements()
    {
        IStack<string> stack = new ListBasedStack<string>();
        var expectedSize = 2;

        stack.Push("string");
        stack.Pop();
        stack.Push("another string");
        stack.Push("and another");

        Assert.Equal(expectedSize, stack.Size);
    }

    [Fact]
    public void Peek_Returns_The_Top_Element()
    {
        IStack<string> stack = new ListBasedStack<string>();
        var expectedResult = "expected";

        stack.Push("string");
        stack.Pop();
        stack.Push("another string");
        stack.Push(expectedResult);

        var peekResult = stack.Peek();

        Assert.Equal(expectedResult, peekResult);
    }

    [Fact]
    public void Peek_Keeps_The_Top_Element()
    {
        IStack<string> stack = new ListBasedStack<string>();
        var expectedResult = "expected";
        var expectedSize = 2;

        stack.Push("string");
        stack.Pop();
        stack.Push("another string");
        stack.Push(expectedResult);

        var peekResult = stack.Peek();

        Assert.Equal(expectedResult, peekResult);
        Assert.Equal(expectedSize, stack.Size);
    }



    [Fact]
    public void Push_Adds_The_Element_The_Top()
    {
        IStack<string> stack = new ListBasedStack<string>();
        var expectedResult = "expected";

        stack.Push("string");
        stack.Push("another string");
        stack.Push(expectedResult);

        var peekResult = stack.Peek();

        Assert.Equal(expectedResult, peekResult);
    }

    [Fact]
    public void Pop_Returns_The_Top_Element()
    {
        IStack<string> stack = new ListBasedStack<string>();
        var expectedResult = "expected";

        stack.Push("string");
        stack.Push("another string");
        stack.Push(expectedResult);

        var popResult = stack.Pop();

        Assert.Equal(expectedResult, popResult);
    }

    [Fact]
    public void Pop_Removes_The_Top_Element()
    {
        IStack<string> stack = new ListBasedStack<string>();
        var expectedResult = "expected";
        var expectedSize = 2;

        stack.Push("string");
        stack.Push("another string");
        stack.Push(expectedResult);

        var popResult = stack.Pop();

        Assert.Equal(expectedResult, popResult);
        Assert.Equal(expectedSize, stack.Size);
    }

    [Fact]
    public void Contains_Return_True_If_Exists()
    {
        IStack<string> stack = new ListBasedStack<string>();
        var searchElement = "expected";

        stack.Push("string");
        stack.Push(searchElement);
        stack.Push("another string");

        Assert.True(stack.Contains(searchElement));
    }

    [Fact]
    public void Contains_Return_False_If_NotExists()
    {
        IStack<string> stack = new ListBasedStack<string>();
        var searchElement = "expected1";

        stack.Push("string");
        stack.Push("expected 1");
        stack.Push("another string");

        Assert.False(stack.Contains(searchElement));
    }

    [Fact]
    public void Clear_Empties_Stack()
    {
        IStack<string> stack = new ListBasedStack<string>();
        var expectedErrorMessage = "Stack is empty.";

        stack.Push("string");
        stack.Push("expected 1");
        stack.Push("another string");

        stack.Clear();

        Assert.True(stack.IsEmpty);
        var exception = Assert.Throws<InvalidOperationException>(() => stack.Peek());
        Assert.Equal(expectedErrorMessage, exception.Message);
    }
}
