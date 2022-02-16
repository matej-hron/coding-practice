<Query Kind="Program" />

string leftBrackets = "{[(";
string rightBrackets = "}])";

void Main()
{
	Should(1, "", "YES");
	Should(2, "(", "NO");
	Should(3, "()", "YES");
	Should(4, "[()]", "YES");
	Should(5, "[()]]", "NO");




}

void Should(int testNo, string expression, string expectation)
{
	$"test number {testNo}".Dump();
	
	var actual = isBalanced(expression);
	
	if (actual != expectation)
	{
		throw new Exception($"Expression {expression}, Expected: {expectation}, Actual: {actual}");
	}

	$"Expression {expression} was evaluated as expected to {expectation}".Dump();
}


public string isBalanced(string s)
{	
	char findLeft(char right) 
	{
		return leftBrackets[rightBrackets.IndexOf(right)];
	}

	bool isLeftBracket(char ch) => leftBrackets.Contains(ch);
	bool isRightBracket(char ch) => rightBrackets.Contains(ch);

	var stack = new Stack<char>();

	foreach(var ch in s.ToCharArray())
	{
		if(isLeftBracket(ch))
		{
			stack.Push(ch);
		}
		
		if(isRightBracket(ch))
		{
			if(stack.Count() == 0)
			{
				$"{ch} was not opened, stack is empty".Dump();
				return "NO";
			}
			
			var left = stack.Pop();
			
			if(left != findLeft(ch))
			{
				$"Right {ch} does not correspond to {left}".Dump();
				return "NO";
			}
		}
	}
	
	
	if(stack.Any())
	{
		$"some left were not closed {stack.Count()}".Dump();
		return "NO";
	}
	return "YES";
}


// You can define other methods, fields, classes and namespaces here