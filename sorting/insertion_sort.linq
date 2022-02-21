<Query Kind="Program" />

void Main()
{
	insertionSort2(0, new List<int> { 2, 3, 4, 1});
}


public static void insertionSort2(int n, List<int> arr)
{
	// 2 3 4 1
	for(int i = 1; i < arr.Count(); i ++)
	{
		var j = i;
		var key = arr[i].Dump("key");
		while(j > 0 && key < arr[j-1])
		{
			arr[j] = arr[j-1];
			j--;
		}
		arr[j] = key;
		
		Print(arr);
	}
}

public static void Print(List<int> arr) => Console.WriteLine(string.Join(' ', arr));
// You can define other methods, fields, classes and namespaces here