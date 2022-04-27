using DataStructuresAndAlgorithms.Lib;
using DataStructuresAndAlgorithms.Lib.SearchAlgorithms;
using DataStructuresAndAlgorithms.Lib.SortAlgorithms;

var random = new Random();
int[] array = Enumerable.Range(0, 20).Select(i => random.Next(0, 100)).ToArray();

array.Print();
Console.WriteLine();

//array.Sort<BubbleSort>();
array.Sort<MergeSort>();

array.Print();
Console.WriteLine();

Console.WriteLine();

int index;

index = array.Search<BinarySearch<int>, int>(79);
Console.WriteLine($"Index Of 79 => {index}");

Console.WriteLine();

index = array.Search<LinearSearch<int>, int>(79);
Console.WriteLine($"Index Of 79 => {index}");