<Query Kind="Program" />

    class SinglyLinkedListNode {
		public int data;
		public SinglyLinkedListNode next;

		public SinglyLinkedListNode(int nodeData)
		{
			this.data = nodeData;
			this.next = null;
		}
	}

	class SinglyLinkedList
	{
		public SinglyLinkedListNode head;
		public SinglyLinkedListNode tail;

		public SinglyLinkedList()
		{
			this.head = null;
			this.tail = null;
		}

		public void InsertNode(int nodeData)
		{
			SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

			if (this.head == null)
			{
				this.head = node;
			}
			else
			{
				this.tail.next = node;
			}

			this.tail = node;
		}
	}

	static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep, TextWriter textWriter)
	{
		while (node != null)
		{
			textWriter.Write(node.data);

			node = node.next;

			if (node != null)
			{
				textWriter.Write(sep);
			}
		}
	}

	// Complete the hasCycle function below.

	/*
     * For your reference:
     *
     * SinglyLinkedListNode {
     *     int data;
     *     SinglyLinkedListNode next;
     * }
     *
     */
	static bool hasCycle(SinglyLinkedListNode head)
	{
		var seen = new HashSet<SinglyLinkedListNode>(new[] { head });
		
		if(head == null)
		{
			return false;
		}
		
		var currentNode = head;
		
		while(currentNode.next != null)
		{
			currentNode = currentNode.next;
			
			if(seen.Contains(currentNode))
			{
				return true;
			}
			
			seen.Add(currentNode);
		}
		
		return false;
	}
	
	static void Main()
	{
		TestNoCycle();
		TestWithCycle();

    }
	
	static void TestNoCycle()
	{
		
		var llist = new SinglyLinkedList();

		llist.InsertNode(1);
		llist.InsertNode(2);
		llist.InsertNode(2);
		$"Test No Cycle: Expected: False, Actual: {hasCycle(llist.head)}".Dump();
	}

static void TestWithCycle()
{

	var llist = new SinglyLinkedList();

	llist.InsertNode(1);
	llist.InsertNode(2);
	llist.InsertNode(2);
	llist.tail.next = llist.head;
	$"Test No Cycle: Expected: True, Actual: {hasCycle(llist.head)}".Dump();
}


