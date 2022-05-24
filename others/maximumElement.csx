var stack = new Stack<Node>();

public List<int> getMax(List<string> operations)
{
    
    var res = new List<int>();
    foreach(var op in operations)
    {
        var operation = op.Split(' ');
        switch (operation[0]) {
            case "1": 
                var value = int.Parse(operation[1]);
                var node = new Node 
                {
                    CurrentMax = !stack.Any() ? value : Math.Max(stack.Peek().CurrentMax, value), 
                    Value = value
                };
                stack.Push(node);
                break;
            case "2":
                _ =stack.Pop();
                break;
            case "3":
                res.Add(stack.Peek().CurrentMax);
                break;
        }
    }


    return res;
}

public class Node
{
    public int Value {get; set;}
    public int CurrentMax {get; set;}
}

var input = new List<string>{
    "1 97",
    "2",
    "1 20",
    "2",
    "1 26",
    "1 20",
    "2",
    "3",
    "1 91",
    "3"
};

var res = getMax(input);
Console.WriteLine(String.Join("\n", res));
