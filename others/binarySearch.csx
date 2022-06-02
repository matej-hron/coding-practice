public int? Find(int value, int[] arr)
{
    int? FindRec(int value, int[] arr, int leftIndex, int length)
    {
        if(length <= 1)
        {
            if(arr[leftIndex] == value)
            {
                return arr[leftIndex];
            }
            else
            {
                return null;
            }
        }

        var midIndex = leftIndex + length / 2;
        if(value == arr[midIndex])
        {
            return value;
        }
        else if(value < arr[midIndex])
        {
            //search in left
            return FindRec(value, arr, leftIndex, midIndex);
        }

        //search in right
        return FindRec(value, arr, midIndex + 1, length - midIndex - 1);
    }

    return FindRec(value, arr, 0, arr.Length);
}


void Assert(int value, int[] arr, int expectedResult)
{
    var actualResult = Find(value, arr);
    var message = actualResult == expectedResult 
        ? $"Test OK"
        : $"Test failed {actualResult} != {expectedResult}";

    Console.WriteLine(message);
}

Assert(1, new[] {1,2,3,4,5,6,7,8,9, 10}, 1);
Assert(9, new[] {1,2,3,4,5,6,7,8,9}, 9);
Assert(10, new[] {1,2,3,4,5,6,7,8,9, 10}, 10);
Assert(9, new[] {1,2,3,4,5,6,7,8,9, 10}, 9);





