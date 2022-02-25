<Query Kind="Program" />

void Main()
{
	var heap = new Heap();
	heap.Add(4);
	heap.Add(9);
	heap.PrintMin();
	heap.Delete(4);
	heap.PrintMin();

}

void Test1()
{
	var heap = new Heap();
	heap.Add(5);
	heap.Add(10);
	heap.Add(15);
	heap.Add(6);

	heap.Validate();

	heap.Delete(5);

}

public class Heap
{
	private int[] array = new int[100];
	private int indexLast = -1;
	
	public void Add(int value)
	{
		if(indexLast == array.Length)
		{
			throw new InvalidOperationException("Heap is full");
		}
		indexLast++;
		array[indexLast] = value;
		BubbleUp(indexLast);
		
	}

	void BubbleUp(int index)
	{
		if(index == 0)
		{
			return;
		}
		
		var parentIndex = GetParentIndex(index);
		
		if(array[parentIndex] > array[index])
		{
			var valueParent = array[parentIndex];
			array[parentIndex] = array[index];
			array[index] = valueParent;
			BubbleUp(parentIndex);
		}
	}

	public void PrintMin()
	{
		Console.WriteLine(array[0]);
	}
	
	public void Delete(int value)
	{
		var index = FindIndexOf(value);
		
		if(index < 0) return;
		
		array[index] = array[indexLast];
		indexLast--;
		
		var parentIndex = GetParentIndex(index);
		
		BubbleUp(index);
		
		
		BubbleDown(index);
	
	}

	void BubbleDown(int index)
	{
		if(index > indexLast)
		{
			return;
		}

		var children = GetChildIndexex2(index);
		
		if(!children.Any()) return;
		
		var childMinIndex = children.Select(x => new {index = x, value = array[x]}).OrderBy(x => x.value).First().index;
		
		
		if(array[index] > array[childMinIndex])
		{
			var tempV = array[index];
			array[index] = array[childMinIndex];
			array[childMinIndex] = tempV;
			BubbleDown(childMinIndex);
		}
	}

	int FindIndexOf(int value)
	{
		for(int index = 0; index <= indexLast; index++)
		{
			if(array[index] == value)
			{
				return index;
			}
		}
		
		return -1;
	}

	private int GetParentIndex(int index)
	{
		return index / 2;
	}
	
	private (int left, int right) GetChildIndexex(int index)
	{
		return ((index + 1) * 2 - 1, (index + 1) * 2);
	}

	private List<int> GetChildIndexex2(int index)
	{
		var res = new List<int>();
		var indexes = ((index + 1) * 2 - 1, (index + 1) * 2);
		if (indexes.Item1 <= indexLast) res.Add(indexes.Item1);
		if (indexes.Item2 <= indexLast) res.Add(indexes.Item2);
		return res;
	}



	public override string ToString()
	{
		return string.Join(',', array.Take(indexLast + 1));
	}
	
	public void Validate(int index = 0)
	{
		if (index > indexLast)
		{
			return;
		}
		
		var (leftIndex, rightIndex) = GetChildIndexex(index);


		if (leftIndex <= indexLast && array[index] > array[leftIndex])
		{
			throw new Exception("Heap invalid");
		}
		if (rightIndex <= indexLast && array[index] > array[rightIndex]) throw new Exception("Heap invalid");
		
		Validate(leftIndex);
		Validate(rightIndex);

	}
}

// You can define other methods, fields, classes and namespaces here