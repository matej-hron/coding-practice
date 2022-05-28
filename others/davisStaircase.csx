/*
     * Complete the 'stepPerms' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER n as parameter.
     */

    public static int calcNum(int n) {
        int[] array = new int[n];
        if (n == 1) {
            return 1;
        }
        else if(n == 2) {
            return 2;
        }
        else if(n == 3) {
            return 4;
        }
        array[0] = 1;
        array[1] = 2;
        array[2] = 4;
        for (int i = 3; i < n; i++) {
            array[i] = array[i-1] + array[i-2] + array[i-3];
        }
        return array[array.Count()-1];
    }

    public static int stepPermsRec(int n)
    {
        if(n == 0) return 0;
        if(n == 1) return 1;
        if(n == 2) return 2;
        if(n == 3) return 4;

        return stepPermsRec(n-1) + stepPermsRec(n-2) + stepPermsRec(n-3);
    }


    /*
        c(7) = c(6) + c(5) + c(4)
        c(6) = c(5) + c(4) + c(3)
        c(5) = c(4) + c(3) + c(2)
        c(4) = c(3) + c(2) + c(1)

    


    */

    public static long stepPerms(int n)
    {
        
        var res = stepPermsRec(n) ;
        return res% 10000000007;
    }

    void Assert(int n, int expectedResult)
    {
        var actualResult = stepPerms(n);
        var actualResult2 = calcNum(n);

        if(actualResult != expectedResult) throw new Exception($"for input {n} expected: {expectedResult}, actual: {actualResult}");
        if(actualResult2 != expectedResult) throw new Exception($"for input {n} expected: {expectedResult}, actual: {actualResult2}");
    
        Console.WriteLine($"Test OK, n: {n}, expected: {expectedResult}, actual: {actualResult2}");
    }

    //Assert(1, 1);
    Assert(2, 2);

    Assert(3, 4);
    Assert(7, 44);

