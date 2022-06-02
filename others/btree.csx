public class Node {
    public int Value {get; set;}
    public Node Left {get; set;}
    public Node Right {get; set;}

    public Node(int value, Node left, Node right)
    {
        Value = value;
        Left = left;
        Right = right;
    }
}

var root = new Node
    (5,
        new Node(3,
            new Node(2, null, null), new Node(4, null, null)),

        new Node(7, null, null)
    );


public List<int> Flatten(Node node)
{
    var list = new List<int>();

    var leftList = node.Left != null ? Flatten(node.Left) : new List<int>();
    var rightList = node.Right != null ? Flatten(node.Right) : new List<int>();

    list.AddRange(leftList);
    list.Add(node.Value);
    list.AddRange(rightList);
    return list;
}

Console.WriteLine(string.Join(',', Flatten(root)));

/*
                5
        3           7
    2       4
    */
