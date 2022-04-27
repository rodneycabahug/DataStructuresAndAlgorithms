using DataStructuresAndAlgorithms.Lib.DataStructures;
using DataStructuresAndAlgorithms.Lib.DataStructures.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DataStructuresAndAlgorithms.LibTests;

public class SeparateChainingHashtableTests
{
    [Fact]
    public void Hashtable_EnsureCapacity_Beyond_Default_64()
    {
        var items = Enumerable.Range(1, 100).Select(i => (i.ToString(), i.ToString())).ToArray();
        var hashtable = new SeparateChainingHashtable<string, string>(items);
        var expectedCount = 100;

        Assert.Equal(expectedCount, expectedCount);
    }

    [Fact]
    public void Keys_Returns_Array_Of_Keys()
    {
        var items = Enumerable.Range(1, 100).Select(i => (i.ToString(), i.ToString())).ToArray();
        var hashtable = new SeparateChainingHashtable<string, string>(items);
        var expectedCount = 100;

        var keys = hashtable.Keys;

        Assert.Equal(expectedCount, keys.Length);
        Assert.Contains(keys, key => "25".Equals(key));
        Assert.Contains(keys, key => "50".Equals(key));
        Assert.Contains(keys, key => "75".Equals(key));
        Assert.Contains(keys, key => "100".Equals(key));

    }

    [Fact]
    public void Values_Returns_Array_Of_Values()
    {
        var items = Enumerable.Range(1, 100).Select(i => (i.ToString(), i.ToString())).ToArray();
        var hashtable = new SeparateChainingHashtable<string, string>(items);
        var expectedCount = 100;

        var values = hashtable.Values;

        Assert.Equal(expectedCount, values.Length);
        Assert.Contains(values, value => "25".Equals(value));
        Assert.Contains(values, value => "50".Equals(value));
        Assert.Contains(values, value => "75".Equals(value));
        Assert.Contains(values, value => "100".Equals(value));

    }

    [Fact]
    public void Add_Checks_For_Duplicate()
    {
        var items = Enumerable.Range(1, 100).Select(i => (i.ToString(), i.ToString())).ToArray();
        var hashtable = new SeparateChainingHashtable<string, string>(items);
        var expectedErrorMessage = "Duplicate key.";

        var exception = Assert.Throws<InvalidOperationException>(() => hashtable.Add("25", "25"));

        Assert.Equal(expectedErrorMessage, exception.Message);
    }

    [Fact]
    public void Add_Checks_Key_IsNotNull()
    {
        var hashtable = new SeparateChainingHashtable<string, string>();
        var expectedErrorMessage = "Value cannot be null. (Parameter 'key')";

        var exception = Assert.Throws<ArgumentNullException>(() => hashtable.Add(null, "25"));

        Assert.Equal(expectedErrorMessage, exception.Message);
    }

    [Fact]
    public void Clear_Deletes_All_Items()
    {
        var items = Enumerable.Range(1, 100).Select(i => (i.ToString(), i.ToString())).ToArray();
        var hashtable = new SeparateChainingHashtable<string, string>(items);
        var expectedCount = 0;

        hashtable.Clear();

        Assert.Equal(expectedCount, hashtable.Count);
        Assert.False(hashtable.ContainsKey("25"));
        Assert.False(hashtable.ContainsKey("100"));
    }

    [Fact]
    public void ContainsKey_Checks_Key_IsNotNull()
    {
        var hashtable = new SeparateChainingHashtable<string, string>();
        var expectedErrorMessage = "Value cannot be null. (Parameter 'key')";

        var exception = Assert.Throws<ArgumentNullException>(() => hashtable.ContainsKey(null));

        Assert.Equal(expectedErrorMessage, exception.Message);
    }

    [Fact]
    public void ContainsKey_Checks_Key_Exists()
    {
        var items = Enumerable.Range(1, 100).Select(i => (i.ToString(), i.ToString())).ToArray();
        var hashtable = new SeparateChainingHashtable<string, string>(items);
        var expectedKey = "65";
        var unexpectedKey = "101";

        Assert.True(hashtable.ContainsKey(expectedKey));
        Assert.False(hashtable.ContainsKey(unexpectedKey));
    }

    [Fact]
    public void ContainsValue_Checks_Value_Exists()
    {
        var items = Enumerable.Range(1, 100).Select(i => (i.ToString(), i.ToString())).ToArray();
        var hashtable = new SeparateChainingHashtable<string, string>(items);
        var expectedValue = "65";
        var unexpectedValue = "101";

        Assert.True(hashtable.ContainsValue(expectedValue));
        Assert.False(hashtable.ContainsValue(unexpectedValue));
    }

    [Fact]
    public void ContainsValue_Caters_To_Null()
    {
        var items = Enumerable.Range(1, 42).Select(i => (i.ToString(), default(string))).ToArray();
        var hashtable = new SeparateChainingHashtable<string, string?>(items);
        var expectedCount = 42;
        var expectedValue = default(string);

        Assert.Equal(expectedCount, hashtable.Count);
        Assert.True(hashtable.ContainsValue(expectedValue));
    }

    [Fact]
    public void GetValue_Returns_Value_For_Key()
    {
        var items = Enumerable.Range(1, 100).Select(i => (i.ToString(), i.ToString())).ToArray();
        var hashtable = new SeparateChainingHashtable<string, string>(items);
        var searchKey = "22";
        var expectedValue = "22";

        var value = hashtable.GetValue(searchKey);

        Assert.Equal(expectedValue, value);
    }

    [Fact]
    public void GetValue_Throws_If_Key_DoesNotExist()
    {
        var items = Enumerable.Range(1, 100).Select(i => (i.ToString(), i.ToString())).ToArray();
        var hashtable = new SeparateChainingHashtable<string, string>(items);
        var searchKey = "101";
        var expectedErrorMessage = "Key does not exist.";

        var exception = Assert.Throws<InvalidOperationException>(() => hashtable.GetValue(searchKey));

        Assert.Equal(expectedErrorMessage, exception.Message);
    }

    [Fact]
    public void SetValue_Sets_The_Value_Identified_By_Key()
    {
        var items = Enumerable.Range(1, 10).Select(i => (i.ToString(), i.ToString())).ToArray();
        var hashtable = new SeparateChainingHashtable<string, string>(items);
        var searchKey = "9";
        var expectedValue = "101";

        hashtable.SetValue(searchKey, expectedValue);

        Assert.Equal(expectedValue, hashtable.GetValue(searchKey));
    }

    [Fact]
    public void SetValue_Adds_New_Item_If_NotExist()
    {
        var items = Enumerable.Range(1, 100).Select(i => (i.ToString(), i.ToString())).ToArray();
        var hashtable = new SeparateChainingHashtable<string, string>(items);
        var searchKey = "101";
        var expectedValue = "101";
        var expectedCount = 101;

        hashtable.SetValue(searchKey, expectedValue);

        Assert.Equal(expectedCount, hashtable.Count);
        Assert.Equal(expectedValue, hashtable.GetValue(searchKey));
    }

    [Fact]
    public void Remove_Deletes_Item_If_Exists()
    {
        var items = Enumerable.Range(1, 80).Select(i => (i.ToString(), i.ToString())).ToArray();
        var hashtable = new SeparateChainingHashtable<string, string>(items);
        var searchKey = "2";
        var expectedCount = 79;

        hashtable.Remove(searchKey);

        Assert.Equal(expectedCount, hashtable.Count);
        Assert.False(hashtable.ContainsKey(searchKey));
    }

    [Fact]
    public void Remove_Does_Nothing_If_NotExists()
    {
        var items = Enumerable.Range(1, 80).Select(i => (i.ToString(), i.ToString())).ToArray();
        var hashtable = new SeparateChainingHashtable<string, string>(items);
        var searchKey = "81";
        var expectedCount = 80;

        hashtable.Remove(searchKey);

        Assert.Equal(expectedCount, hashtable.Count);
        Assert.False(hashtable.ContainsKey(searchKey));
    }
}