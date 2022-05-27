void ProcessCommands(string[] commands)
{
    var q = new Q();
    foreach(var command in commands)
    {
        var cmd = command.Split(' ');
        if(cmd[0] == "1") //add
        {
            q.Enqueue(int.Parse(cmd[1]));
        }
        else if(cmd[0] == "2") //remove
        {
            _ = q.Dequeue();
        }
        else if(cmd[0] == "3") // print
        {
            Console.WriteLine(q.Peek());
        }
    }
}

public class Q
{
    private Stack<int> s1 = new Stack<int>();
    private Stack<int> s2 = new Stack<int>();

    public void Enqueue(int value)
    {
        s1.Push(value);
    }

    public int Dequeue()
    {
        if(!s2.Any())
        {
            Transfer();
        }

        return s2.Pop();
    }

    public int Peek()
    {
        if(!s2.Any())
        {
            Transfer();
        }

        return s2.Peek();
    }

    private void Transfer()
    {
        while(s1.Any())
        {
            s2.Push(s1.Pop());
        }
    }
}


var commands = new string[]
{
"1 42",
"2",
"1 14",
"3",
"1 28",
"3",
"1 60",
"1 78",
"2",
"2",
};
ProcessCommands(commands);