<Query Kind="Program" />

void Main()
{
	Test1();
	Test2();
	Test3();
}

void Test1()
{
	var indexes = icecreamParlor(6, new List<int> {1, 3, 4, 5, 6}).ToArray();
	Assert(indexes[0], 1);
	Assert(indexes[1], 4);
}

void Test2()
{
	var indexes = icecreamParlor(4, new List<int> { 1, 4, 5, 3, 2 }).ToArray();
	Assert(indexes[0], 1);
	Assert(indexes[1], 4);
}


void Test3()
{
	var indexes = icecreamParlor(4, new List<int> { 2, 2, 4, 3 }).ToArray();
	Assert(indexes[0], 1);
	Assert(indexes[1], 2);
}

void Assert(int actual, int expected)
{
	if (actual != expected) throw new Exception($"{actual} != {expected}");
}

public static List<int> icecreamParlor(int m, List<int> arr)
{
	var valueToIndexMap = new Dictionary<int, List<int>>();
	
	for(int index = 0; index < arr.Count(); index++)
	{
		var value = arr[index];
		
		if(!valueToIndexMap.ContainsKey(arr[index]))
		{
			valueToIndexMap[value] = new List<int> {index};
		}
		else{
			valueToIndexMap[value].Add(index);
		}
	}
	
	for(int index = 0; index < arr.Count(); index++)
	{
		var price1 = arr[index];
		var remaining = m - price1;
		
		if(valueToIndexMap.ContainsKey(remaining) && valueToIndexMap[remaining].Any(i => i != index))
		{
			return new List<int> {index + 1, valueToIndexMap[remaining].Where(i => i != index).Min() + 1};
		}
		
		
	}
	
	return null;
}

// You can define other methods, fields, classes and namespaces here