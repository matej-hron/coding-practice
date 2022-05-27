/*
     * Complete the 'maxMin' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY arr
     */

    public static int maxMin(int k, List<int> arr)
    {
        var l = arr.OrderBy(x => x).ToList();
        Console.WriteLine(string.Join(",", l));
        var min = int.MaxValue;
        for(int i = 0; i < l.Count() - k + 1; i++)
        {
            var left = l[i];
            var right = l[i+k-1];
            min = right - left < min ? min = right - left : min;
            Console.WriteLine($"{i}: left:{left}, right: {right}, min:{min}");
        }
        return min;
    }

    // var res = maxMin(4, new List<int> {
    //     1,
    //     2,
    //     3,
    //     4,
    //     10,
    //     20,
    //     30,
    //     40,
    //     100,
    //     200
    // });


    var _ = maxMin(8, new List<int> {
        6327,
        571,
        6599,
        479,
        7897,
        9322,
        4518,
        571,
        6677,
        7432,
        815,
        6920,
        4329,
        4104,
        7775,
        5708,
        7991,
        5802,
        8619,
        6053,
        7539,
        7454,
        9000,
        3267,
        6343,
        7165,
        4095,
        439,
        5621,
        4095,
        153,
        1948,
        1018,
        6752,
        8779,
        5267,
        2426,
        9649,
        2190,
        9103,
        7081,
        3006,
        2376,
        7762,
        3462,
        151,
        3471,
        1453,
        2305,
        8442,
    });

    /*
1
2
3
4
10
20
30
40
100
200

    */