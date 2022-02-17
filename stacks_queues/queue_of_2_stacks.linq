<Query Kind="Program" />

void Main()
{
	Test1();
	Test2();

}


public void Test1()
{
	var queue = new Queue();

	queue.Enqueue(1);
	queue.Enqueue(2);
	queue.Enqueue(3);

	Assert(queue.Dequeue(), 1);
	Assert(queue.Peek(), 2);
	Assert(queue.Dequeue(), 2);
	Assert(queue.Peek(), 3);
	Assert(queue.Dequeue(), 3);
}

public void Test2()
{
	var queue = new Queue();

	queue.Enqueue(42);
	queue.Dequeue();
	queue.Enqueue(14);
	Assert(queue.Peek(), 14);
	queue.Enqueue(28);
	Assert(queue.Peek(), 14);




	
}

public void Assert(int actual, int expected)
{
	if (actual != expected) throw new Exception($"Faile {actual} != {expected}");

	$"{actual} == {expected}".Dump();
}

public class Queue
{
	private Stack<int> stack1 = new Stack<int>();
	private Stack<int> stack2 = new Stack<int>();


	public void Enqueue(int value)
	{
		stack1.Push(value);
	}
	
	public int Dequeue()
	{
		RefillStack2();
		EnsureItems();
		
		return stack2.Pop();
	}
	
	public int Peek()
	{
		RefillStack2();
		EnsureItems();

		return stack2.Peek();

	}
	
	private void RefillStack2()
	{
		if(!stack2.Any())
		{
			while(stack1.Any()) stack2.Push(stack1.Pop());
		}
	}
	
	private void EnsureItems()
	{
		if(!stack2.Any()) throw new InvalidOperationException("Qeueu is empty");	
	}
}

// You can define other methods, fields, classes and namespaces here


