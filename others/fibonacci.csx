public static int Fibonacci(int n)
{
    var arr = new int[n];
    arr[0] = 1;
    arr[1] = 1;
    for(int i = 2; i < arr.Length; i++)
    {
        arr[i] = arr[i-1] + arr[i-2];
    }
    return arr[arr.Length-1];
}

public static int FibRec(int n) =>
    n <= 2 ? 1 : FibRec(n-2) + FibRec(n-1);

Console.WriteLine($"f1: {Fibonacci(5)}, f2:{FibRec(5)}");

//1 1 2 3 5 8
/*
f(5) = f(4) + f(3)
f4 = f3 + f2


*/