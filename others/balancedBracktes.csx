var brackets = new List<(char left, char right)>
{
    ('(', ')'),
    ('[', ']'),
    ('{', '}'),
};

string isBalanced(string s) {
    var lefts = new HashSet<char>(brackets.Select(bPair => bPair.left));
    var rightToLeftMap = brackets.ToDictionary(kv => kv.right, kv => kv.left);
    var stack = new Stack<char>();

    if(s is null) 
    {
        return "NO"; //???
    }

    foreach(var l in s)
    {
        if(lefts.Contains(l))
        {
            stack.Push(l);
        }

        if(rightToLeftMap.TryGetValue(l, out var expectedLeft))
        {
            if(!stack.Any())
            {
                return "NO";
            }

            var actualLeft = stack.Pop();
            if(actualLeft != expectedLeft)
            {
                return "NO";
            }
        }
    }

    if(stack.Any())
    {
        return "NO";
    }

    return "YES";
}

Assert("{[()]}", "YES");
Assert("{[(])}", "NO");
Assert("{{[[(())]]}} ", "YES");

void Assert(string input, string expected)
{
    var res = isBalanced(input);
    var message = res == expected
    ? $"Test OK. Input: {input}, expected: {expected}, actual: {res}"
    : $"Test Failed. Input: {input}, expected: {expected}, actual: {res}";
    Console.WriteLine(message);
}

