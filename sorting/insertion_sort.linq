<Query Kind="Program" />

void Main()
{
	insertionSort2(0, new List<int> { 1, 4, 3, 5, 6, 2});
}


public static void insertionSort2(int n, List<int> arr)
{
	for(int i = 1; i < arr.Count(); i ++)
	{
		var j = i;
		while(j > 0 && arr[j] < arr[j-1])
		{
			var arrj = arr[j];
			arr[j] = arr[j-1];
			arr[j-1] = arrj;
			j--;
		}
		
		Print(arr);
	}
}

public static void Print(List<int> arr) => Console.WriteLine(string.Join(' ', arr));
// You can define other methods, fields, classes and namespaces here