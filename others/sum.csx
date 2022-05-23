#!/usr/bin/env dotnet-script

public string Sum(string num1, string num2)
{
   
    var shift = 0;
    var res = new List<int>();

    for(var index = 0; index <= Math.Max(num1.Length, num2.Length); index++)
    {
        var a = Get(num1, index);
        var b = Get(num2, index);
        var x = (a + b + shift);
        res.Add(x % 10);
        Console.WriteLine($"{a} + {b} + {shift}");

        shift = x / 10;
       
        
    }
    res.Reverse();
    return string.Join(string.Empty, res);
}

public int Get(string arr, int index) => index >= arr.Length ? 0 : (int)arr[^(index+1)] - 48;



Console.WriteLine($"100+100 = {Sum("100", "100")}");