<Query Kind="Program" />

void Main()
{
	//MergeSort(new[] {4, 3, 2, 1, 0});
	var lst = new[] {1, 0, 2, 3, -1, - 6, 15};
	MergeSort(lst);
	lst.Dump();
}


void MergeSort(int[] lst)
{
	var temp = new int[lst.Length];
	MergeSort(lst, temp, 0, lst.Length - 1);
	
}

void MergeSort(int[] lst, int[] temp, int leftStart, int rightEnd)
{
	//Print(lst, leftStart, rightEnd);
	if(rightEnd - leftStart < 1)
	{
		return;
	}
	
	int midIndex = leftStart + (rightEnd - leftStart) / 2;
	MergeSort(lst, temp, leftStart, midIndex );
	MergeSort(lst, temp, midIndex + 1, rightEnd);
	Merge(lst, temp, leftStart, rightEnd);

}

void Print(int[] lst, int leftStart, int rightEnd)
{
	Console.Write("MergeSort: ");
	for (int i = leftStart; i <= rightEnd; i++)
	{
		Console.Write($"{lst[i]},");	
	}
	Console.Write(Environment.NewLine);
}

void Merge(int[] lst, int[] temp, int leftStart, int rightEnd)
{
	
	var midIndex = leftStart + (rightEnd - leftStart) / 2;
	var i = leftStart;
	var j = midIndex + 1;
	var k = 0;
	while(i <= midIndex && j <= rightEnd)
	{
		if(lst[i] <= lst[j])
		{
			temp[leftStart + k] = lst[i];
			i++;
			k++;
		}
		else{
			temp[leftStart + k] = lst[j];
			j++;
			k++;
		}
	}

	Array.Copy(lst, i, temp, leftStart + k, midIndex + 1 - i);
	Array.Copy(lst, j, temp, leftStart + k, rightEnd + 1 - j);
	Array.Copy(temp, leftStart, lst, leftStart, rightEnd - leftStart + 1);
	//temp.Dump();

}
// You can define other methods, fields, classes and namespaces here