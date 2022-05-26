public static long arrayManipulation(int n, List<List<int>> queries)
{
    var arr = new int[n];

    foreach(var query in queries)
    {
        var leftIndex = query[0] - 1;
        var rightIndex = query[1] - 1;
        var value = query[2];

        arr[leftIndex] += value;
        if(rightIndex + 1 < arr.Length) arr[rightIndex+1] -= value;
    }

    long running = 0;
    long max = 0;
    foreach(var delta in arr)
    {
        running += delta;
        max = running > max ? running : max;
    }

    return max;
}

/*
    a b k
    1 5 3
    4 8 7
    6 9 1
*/