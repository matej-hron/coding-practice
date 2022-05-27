public static string checkMagazine(List<string> magazine, List<string> note)
{
    var magazineWords = magazine.GroupBy(m => m).ToDictionary(kv => kv.Key, kv => kv.Count());
    var noteWords = note.GroupBy(m => m);

    return noteWords
        .All(word => magazineWords.ContainsKey(word.Key) && magazineWords[word.Key] >= word.Count())
        ? "YES"
        : "NO";
}

Assert("give me one grand today night", "give one grand today", "YES");
Assert("two times three is not four", "two times two is four", "NO");


private void Assert(string magazine, string note, string expectedResult)
{
    var actualResult = checkMagazine(
        magazine.Split(' ').ToList(),
        note.Split(' ').ToList()
    );

    var message = actualResult == expectedResult
        ? "OK"
        : "Failed";

    Console.WriteLine(message);
}