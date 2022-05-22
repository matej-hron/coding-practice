#!/usr/bin/env dotnet-script

public string Sum(string num1, string num2)
{
    var nArr1 = num1.ToCharArray().Select(ch => (int)ch - 48).Reverse().ToArray();
    var nArr2 = num2.ToCharArray().Select(ch => (int)ch - 48).Reverse().ToArray();

    var index = 0;
    var a = Get(nArr1, index);
    var b = Get(nArr2,index);
    var shift = 0;
    var res = new List<int>();

    while(a + b + shift > 0)
    {
        var x = (a + b + shift);
        res.Add(x % 10);

        shift = x / 10;
        index++;
        a = Get(nArr1, index);
        b = Get(nArr2, index);
        
    }
    res.Reverse();
    return string.Join(string.Empty, res);
}

public int Get(int[] arr, int index) => index >= arr.Length ? 0 : arr[index];



Console.WriteLine($"1+1 = {Sum("15", "6")}");