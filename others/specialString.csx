#!/usr/bin/env dotnet-script

static long substrCount(int n, string s) {

    var tuples = GetTuples(s);

    int sum = 0;
    foreach(var t in tuples)
    {
        sum += (int)((t.count + 1) * ((decimal)t.count / 2));
    }

    for(int i = 1; i < (tuples.Count() - 1); i++)
    {
        //Console.WriteLine(tuples[i+1].count);
        if(tuples[i].count == 1 && tuples[i-1].letter == tuples[i+1].letter)
        {
            sum += Math.Min(tuples[i-1].count, tuples[i+1].count);
        }
    }

    //Console.WriteLine(string.Join(",", tuples.Select(t => $"{t.letter}: {t.count}")));
    return sum;
}

static List<(char letter, int count)> GetTuples(string s)
{
    char currentLetter = s[0];
    int currentCount = 1;
    var res = new List<(char leter, int count)>();

    for(int i = 1; i < s.Length; i++)
    {
        if(s[i] != currentLetter)
        {
            res.Add((currentLetter, currentCount));
            currentLetter = s[i];
            currentCount = 1;
        }
        else
        {
            currentCount++;
        }
    }

    res.Add((currentLetter, currentCount));

    return res;
}



Console.WriteLine($"asasd, should be 7 and is: {substrCount(0, "asasd")}");
Console.WriteLine($"abcbaba, should be 10 and is: {substrCount(0, "abcbaba")}");
Console.WriteLine($"mnonopoo, should be 12 and is: {substrCount(12, "mnonopoo")}");
Console.WriteLine($"aaaa, should be 10 and is: {substrCount(10, "aaaa")}");
Console.WriteLine(substrCount(0, File.ReadAllText("test.txt")));
//aaaa