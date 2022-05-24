public int[] Merge(int[] arrL, int[] arrR)
{
    int Get(int[] arr, int index) => index >= arr.Length ? int.MaxValue : arr[index];
    
    var size = arrL.Length + arrR.Length;
    var res = new int[size];
    var i = 0;
    var j = 0;
    for(int index = 0; index < size; index++)
    {
        if(Get(arrL, i) < Get(arrR, j))
        {
            res[index] = arrL[i];
            i++;
        }
        else{
            res[index] = arrR[j];
            j++;
        }
    }

    return res;
}

var x = Merge(new[] {1, 2, 5}, new[] {4, 6});
Console.WriteLine(string.Join(",", x));