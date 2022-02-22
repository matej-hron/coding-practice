<Query Kind="Program" />

void Main()
{
	quickSort(new int[] { 5, 8, 1, 3, 7, 9, 2});
}

static void quickSort(int[] ar)
{

	var res = quickSortRec(ar);
	string.Join(',', res).Dump();

}

static int[] quickSortRec(int[] ar)
{
	if(ar.Length <= 1) return ar;
	
	var pivot = ar[0];
	
	var left = ar.Skip(1).Where(x => x < pivot).ToArray();
	var right = ar.Skip(1).Where(x => x >= pivot).ToArray();

	return quickSortRec(left).Concat(new[] {pivot}).Concat(quickSortRec(right)).ToArray();
}

// You can define other methods, fields, classes and namespaces here