﻿using DataStructuresAndAlgorithms.Lib.DataStructures;
using DataStructuresAndAlgorithms.Lib.DataStructures.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace DataStructuresAndAlgorithms.LibTests
{
    public class BinaryHeapTests
    {
        [Fact]
        public void Heap_Ensures_Capacity_Above_Default32()
        {
            var random = new Random();
            var items = Enumerable.Range(0, 33).Select(i => random.Next(0, 100)).ToArray();
            var heap = new BinaryHeap<int>(items);
            var expectedSize = 33;

            Assert.Equal(expectedSize, heap.Size);
        }

        [Fact]
        public void Size_Returns_Number_Of_Items()
        {
            var random = new Random();
            var items = Enumerable.Range(0, 20).Select(i => random.Next(0, 100)).ToArray();
            var heap = new BinaryHeap<int>(items);
            var expectedSize = 20;

            Assert.Equal(expectedSize, heap.Size);
        }

        [Fact]
        public void IsEmpty_Returns_True_If_Size_Is_Zero()
        {
            var heap = new BinaryHeap<int>();
            var expectedSize = 0;

            Assert.Equal(expectedSize, heap.Size);
            Assert.True(heap.IsEmpty);
        }

        [Fact]
        public void IsEmpty_Returns_False_If_Size_Is_NotZero()
        {
            var items = Enumerable.Range(1, 20).ToArray();
            var heap = new BinaryHeap<int>(items);
            var expectedSize = 20;

            Assert.Equal(expectedSize, heap.Size);
            Assert.False(heap.IsEmpty);
        }

        [Fact]
        public void Heapify_Creates_Heap_From_Collection()
        {
            var random = new Random();
            var items = Enumerable.Range(0, 20).Select(i => random.Next(0, 100)).ToArray();
            var heap = new BinaryHeap<int>();

            var expectedRoot = items.Min();
            var expectedSize = 20;

            heap.Heapify(items);

            Assert.Equal(expectedSize, heap.Size);
            Assert.Equal(expectedRoot, heap.Peek());
        }

        [Fact]
        public void Heapify_Replaces_Heap_If_Cleared()
        {
            var items = Enumerable.Range(1, 20).ToArray();
            var heap = new BinaryHeap<int>(items);


            var newItems = Enumerable.Range(40, 20).ToArray();
            var expectedRoot = 40;
            var expectedSize = 20;

            heap.Heapify(newItems, true);

            Assert.Equal(expectedSize, heap.Size);
            Assert.Equal(expectedRoot, heap.Peek());
        }

        [Fact]
        public void Heapify_Adds_To_Heap_If_Not_Cleared()
        {
            var items = Enumerable.Range(40, 20).ToArray();
            var heap = new BinaryHeap<int>(items);


            var newItems = Enumerable.Range(1, 20).ToArray();
            var expectedRoot = 1;
            var expectedSize = 40;

            heap.Heapify(newItems, false);

            Assert.Equal(expectedSize, heap.Size);
            Assert.Equal(expectedRoot, heap.Peek());
        }

        [Fact]
        public void Peek_Returns_Heap_Root()
        {
            var random = new Random();
            var items = Enumerable.Range(0, 20).Select(i => random.Next(0, 100)).ToArray();
            var heap = new BinaryHeap<int>(items);
            var expectedRoot = items.Min();

            Assert.Equal(expectedRoot, heap.Peek());
        }

        [Fact]
        public void Peek_Throws_Exception_If_Empty()
        {
            var heap = new BinaryHeap<int>();
            var expectedError = "Heap is empty.";

            var exception = Assert.Throws<InvalidOperationException>(() => heap.Peek());

            Assert.True(heap.IsEmpty);
            Assert.Equal(expectedError, exception.Message);
        }

        [Fact]
        public void Push_Increases_Size_By_One()
        {
            var random = new Random();
            var items = Enumerable.Range(0, 20).Select(i => random.Next(0, 100)).ToArray();
            var heap = new BinaryHeap<int>(items);
            var expectedSize = 21;

            heap.Push(random.Next(0, 100));

            Assert.Equal(expectedSize, heap.Size);
        }

        [Fact]
        public void Push_Sifts_Smallest_To_Root()
        {
            var random = new Random();
            var items = Enumerable.Range(0, 20).Select(i => random.Next(10, 100)).ToArray();
            var heap = new BinaryHeap<int>(items);
            var expectedRoot = 1;

            heap.Push(expectedRoot);

            Assert.Equal(expectedRoot, heap.Peek());
        }

        [Fact]
        public void Push_Throws_Exception_If_Item_IsNull()
        {
            var heap = new BinaryHeap<int?>();
            var expectedError = "Value cannot be null. (Parameter 'item')";

            var exception = Assert.Throws<ArgumentNullException>(() => heap.Push(default));

            Assert.Equal(expectedError, exception.Message);
        }

        [Fact]
        public void Pop_Returns_The_Root()
        {
            var items = Enumerable.Range(1, 20).ToArray();
            var heap = new BinaryHeap<int>(items);
            var expectedRoot = 1;

            Assert.Equal(expectedRoot, heap.Pop());
        }

        [Fact]
        public void Pop_Decreases_Size_By_One()
        {
            var items = Enumerable.Range(1, 1).ToArray();
            var heap = new BinaryHeap<int>(items);
            var expectedSize = 0;

            heap.Pop();

            Assert.Equal(expectedSize,heap.Size);
        }

        [Fact]
        public void Pop_Replaces_Root_By_Next_Smallest()
        {
            var items = Enumerable.Range(1, 2).ToArray();
            var heap = new BinaryHeap<int>(items);
            var expectedRoot = 2;

            heap.Pop();

            Assert.Equal(expectedRoot, heap.Peek());
        }

        [Fact]
        public void Pop_Throws_Exception_If_Empty()
        {
            var heap = new BinaryHeap<int>();
            var expectedError = "Heap is empty.";

            var exception = Assert.Throws<InvalidOperationException>(() => heap.Pop());

            Assert.True(heap.IsEmpty);
            Assert.Equal(expectedError, exception.Message);
        }

        [Fact]
        public void Replace_Throws_Exception_If_Item_IsNull()
        {
            var heap = new BinaryHeap<int?>();
            var expectedError = "Value cannot be null. (Parameter 'item')";

            var exception = Assert.Throws<ArgumentNullException>(() => heap.Push(default));

            Assert.Equal(expectedError, exception.Message);
        }

        [Fact]
        public void Replace_Increase_Size_To_One_If_Empty()
        {
            var heap = new BinaryHeap<int?>();
            var expectedRoot = 1;
            var expectedSize = 1;
            var expectedResult = default(int?);

            var result = heap.Replace(expectedRoot);

            Assert.Equal(expectedResult, result);
            Assert.Equal(expectedRoot, heap.Peek());
            Assert.Equal(expectedSize, heap.Size);
        }

        [Fact]
        public void Replace_Keeps_Size_If_NotEmpty()
        {
            var items = Enumerable.Range(10, 20).ToArray();
            var heap = new BinaryHeap<int>(items);
            var expectedRoot = 2;
            var expectedSize = 20;
            var expectedResult = 10;

            var result = heap.Replace(expectedRoot);

            Assert.Equal(expectedResult, result);
            Assert.Equal(expectedRoot, heap.Peek());
            Assert.Equal(expectedSize, heap.Size);
        }

        [Fact]
        public void Type_Flip_Min_Max()
        {
            var random = new Random();
            var items = Enumerable.Range(0, 20).Select(i => random.Next(10, 100)).ToArray();
            var heap = new BinaryHeap<int>(items);
            var expectedRoot = items.Min();
            var expectedNewRoot = items.Max();

            var root = heap.Peek();
            heap.Type = BinaryHeapType.MaxHeap;
            var newRoot = heap.Peek();

            Assert.Equal(expectedRoot, root);
            Assert.Equal(expectedNewRoot, newRoot);
        }
    }
}
