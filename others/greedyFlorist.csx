static int getMinimumCost(int noOfPeople, int[] flowerPrices) {
    var repeatCount = 0;
    var accumulatedPrice = 0;
    var iteration=0;
    flowerPrices = flowerPrices.OrderBy(x => x).ToArray();
    for(var i = flowerPrices.Count() - 1; i >=0; i--)
    {
        if((iteration % noOfPeople) == 0)
        {
            repeatCount ++;
        }

        accumulatedPrice += flowerPrices[i] * repeatCount;
        iteration++;
    }

    return accumulatedPrice;

}

var minPrice = getMinimumCost(3, new[] {1, 3, 5, 7, 9});
Console.WriteLine($"minPrice: {minPrice}, expected: 29");

/*
1 3 5 7 9
*/