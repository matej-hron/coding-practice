using System;

// To execute C#, please define "static void Main" on a class
// named Solution.

class Solution
{
    static void Main(string[] args)
    {
        var arr = new[] {1, 2, 3};
        Test(Reverse(arr), arr);
    }
    
   public static int[] Reverse(int[] arr){
   for (int i = 0; i < arr.Count() /2 ; i++)
    {
        var j = arr.Count() - 1 - i;
        var jVal = arr[j];
        arr[j] = arr[i];
        arr[i] = jVal;
    }

    return arr;
}
    
    public static void Test(int[] arr, int[] sourceArr)
    {
        Console.WriteLine($"{string.Join(',', arr)}, {string.Join(',', sourceArr)}");
    }
}
