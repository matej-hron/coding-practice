public static int superDigit(string n, int k=0)
{
    if(n.Length==1)
    {
        return n[0] - '0';
    }

    var sumOfDigits = n.Aggregate(0, (sum, digit) => sum + (digit - '0'));
    return superDigit(sumOfDigits.ToString());
}


void Assert(string n, int expectedResult)
{
    var actualRes = superDigit(n);
    Console.WriteLine($"expected {expectedResult}, actual: {actualRes}");
}
Assert("9", 9);
Assert("15", 6);


Assert("9875", 2);
