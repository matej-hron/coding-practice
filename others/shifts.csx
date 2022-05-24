public int[] shiftLeftBy(int[] arr, int cnt)
{
    
    var res = new int[arr.Length];
    var c = cnt % arr.Length;
    Array.Copy(arr, c, res, 0, arr.Length - c);
    Array.Copy(arr, 0, res, arr.Length - c, c);
    return res;
    /*
    1234
    1: 2341
    2: 3412
    3: 4123

    */
}

public int[] shiftRightBy(int[] arr, int cnt)
{
    /*
    1234
    1-4123
    2-3412
    */
    var res = new int[arr.Length];
    var c = cnt % arr.Length;

    Array.Copy(arr, arr.Length - c, res, 0, c);
    Array.Copy(arr, 0, res, c, arr.Length - c);
    return res;
}

var r = shiftRightBy(new[] {1, 2, 3, 4}, 1);

Console.WriteLine(string.Join("", r));