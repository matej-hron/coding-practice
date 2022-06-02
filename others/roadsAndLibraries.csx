/*
     * Complete the 'roadsAndLibraries' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER c_lib
     *  3. INTEGER c_road
     *  4. 2D_INTEGER_ARRAY cities
     */

    public static long roadsAndLibraries(int n, int c_lib, int c_road, List<List<int>> cities)
    {
        // if library is cheaper then road then it makes sense to build library in each city
        if(c_lib <= c_road)
        {
            return n * c_lib;
        }

        var roadMap = new Dictionary<int, HashSet<int>>();

        var citiesWithoutLibrary = new HashSet<int>(Enumerable.Range(1, n));

        foreach(var city in citiesWithoutLibrary)
        {
            roadMap.Add(city, new HashSet<int>());
        }

        foreach(var cityLink in cities)
        {
            roadMap[cityLink[0]].Add(cityLink[1]);
            roadMap[cityLink[1]].Add(cityLink[0]);
        }

        
        int cost = 0;
        while(citiesWithoutLibrary.Any())
        {
            //find city connected with most cities without library
            var c = roadMap
                .Where(x => citiesWithoutLibrary.Contains(x.Key))
                .Select(x => new { x.Key, cities = x.Value.Intersect(citiesWithoutLibrary) })
                .OrderByDescending(x => x.cities.Count())
                .First();
            
            cost += c_lib;
            cost += c.cities.Count() * c_road;
            citiesWithoutLibrary.Remove(c.Key);
            
            foreach(var connectedCity in c.cities) citiesWithoutLibrary.Remove(connectedCity);

        }

        return cost;
    }

    /*
        1   2   3
    1
    2
    3

    */

    void Assert(int testNo, int n, int c_lib, int c_road, List<List<int>> cities, int expectedCost)
    {
        var actualCost = roadsAndLibraries(n, c_lib, c_road, cities);

        var message = actualCost == expectedCost
        ? $"{testNo}. Test OK, expected == actual: {expectedCost}"
        : $"{testNo}. Test Failed, expected: {expectedCost}, actual: {actualCost}";

        Console.WriteLine(message);  
    }

   

    Assert(3, 5, 6, 1, new List<List<int>>{
        new List<int> {1,2},
        new List<int> {1,2},
        new List<int> {1,3},
        new List<int> {1,4},
    }, 15);

     Assert(1, 3, 2, 1, new List<List<int>>{
        new List<int> {1,2},
        new List<int> {3,1},
        new List<int> {2,3},
        
    }, 4);


    Assert(2, 6, 2, 5, new List<List<int>>{
        new List<int> {1,3},
        new List<int> {1,2},
        new List<int> {2,3},
        new List<int> {3,4},
        new List<int> {2,4},
        new List<int> {5,6},
    }, 12);

    