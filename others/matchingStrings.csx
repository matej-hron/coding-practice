/*
     * Complete the 'matchingStrings' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. STRING_ARRAY strings
     *  2. STRING_ARRAY queries
     */

    public static List<int> matchingStrings(List<string> strings, List<string> queries)
    {
        var dict = strings.GroupBy(s => s).ToDictionary(kv => kv.Key, kv => kv.Count());
        return queries.Select(q => dict.ContainsKey(q) ? dict[q] : 0).ToList();
    }

    var res = matchingStrings(
        new List<string> {"aba", "baba", "aba", "xzxb"},
        new List<string> {"aba", "xzxb", "ab"} 
    );

    Console.WriteLine(string.Join(",", res));
