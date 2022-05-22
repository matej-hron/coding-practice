#!/usr/bin/env dotnet-script

public string Sum(string num1, string num2)
{
    var index = 0;
    var a = Get(num1, index);
    var b = Get(num2, index);
    var shift = 0;
    var res = new List<int>();

    while(a + b + shift > 0)
    {
        var x = (a + b + shift);
        res.Add(x % 10);

        shift = x / 10;
        index++;
        a = Get(num1, index);
        b = Get(num2, index);
        
    }
    res.Reverse();
    return string.Join(string.Empty, res);
}

public int Get(string arr, int index) => index >= arr.Length ? 0 : (int)arr[^(index+1)] - 48;



Console.WriteLine($"1+1 = {Sum("15", "6")}");