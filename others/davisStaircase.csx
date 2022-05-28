/*
     * Complete the 'stepPerms' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER n as parameter.
     */

    public static int stepPermsRec(int n)
    {
        if(n == 0) return 0;
        if(n == 1) return 1;
        if(n == 2) return 2;
        //if(n == 3) return 4;

        return stepPermsRec(n-1) + stepPermsRec(n-2) + stepPermsRec(n-3);
    }

    public static long stepPerms(int n)
    {
        
        var res = stepPermsRec(n) ;
        return res% 10000000007;
    }

    void Assert(int n, int expectedResult)
    {
        var actualResult = stepPerms(n);
        if(actualResult != expectedResult) throw new Exception($"for input {n} expected: {expectedResult}, actual: {actualResult}");
    
        Console.WriteLine($"Test OK, n: {n}, expected: {expectedResult}, actual: {actualResult}");
    }

    //Assert(1, 1);
    Assert(2, 2);

    Assert(3, 4);
    Assert(7, 44);

