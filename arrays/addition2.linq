<Query Kind="Program" />

private int[] Sum(int[] a, int[] b)
{
	var l = a.Reverse().ToArray();
	var r = b.Reverse().ToArray();
	
	var iterationCount = Math.Max(l.Count(), r.Count());
	var result = new int[Math.Max(l.Count(), r.Count()) + 1];

	var move = 0;
	
	for(int i=0; i < iterationCount; i++)
	{
		var digitSum = Get(l, i) + Get(r, i) + move;
		result[i] = (digitSum % 10);
		move = digitSum / 10;
	}
	
	if(move > 0)
	result[iterationCount] = move;

	return result.Reverse().ToArray();
}

private int Get(int[] arr, int index)
{
	if(index < arr.Count())
	{
		return arr[index];
	}
	else return 0;
}


void Main()
{
	Sum(new[] { 5 }, new[] {6}).Dump();
	Sum(new[] { 1, 5 }, new[] {1, 6}).Dump();
	Sum(new[] { 0, 9, 9 }, new[] {9, 9}).Dump();
	Sum(new[] { 1, 1, 5 }, new[] {1, 6}).Dump();
}

// You can define other methods, fields, classes and namespaces here