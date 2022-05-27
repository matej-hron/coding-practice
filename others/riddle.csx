   static long[] Riddle(long[] arr) {
        // complete this function
        var res = new long[arr.Length];

        for(int i = 0; i < arr.Length; i++)
        {

        }


        return new long[] {0};
    }

/*
  
    1, min 1
    2, min 1
    3, 
    
*/



    var res = Riddle(new long[] {6, 3, 5, 1, 12});
    
    Console.WriteLine($"Expected 12,3,3,1,1, actual: {string.Join(",", res)}");