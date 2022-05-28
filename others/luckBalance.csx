public static int luckBalance(int canLoose, List<List<int>> contests)
{
    var importantContests = contests.Where(c => c[1] == 1).OrderBy(c => c[0]);
    var unimportantContests = contests.Where(c => c[1] == 0);

    var luckGainForUnimportant = unimportantContests.Sum(c => c[0]);
    var noToWin = importantContests.Count() - canLoose;
    var priceToWin = importantContests.Take(noToWin).Sum(c => c[0]);
    var luckGainedForImportant = importantContests.Skip(noToWin).Sum(c => c[0]);

    return luckGainedForImportant + luckGainForUnimportant - priceToWin;

}


var contests = new List<List<int>> {
    new List<int> {5, 1},
    new List<int>  {2, 1},
    new List<int>  {1, 1},
    new List<int>  {8, 1},
    new List<int>  {10, 0},
    new List<int>  {5, 0},
};


var result = luckBalance(3, contests);

Console.WriteLine($"actual result: {result}, expected: {29}")