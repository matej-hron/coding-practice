public static string twoStrings(string s1, string s2)
{
    var s1LetterSet = new HashSet<char>(s1.ToCharArray());
    return s2.Any(l => s1LetterSet.Contains(l)) ? "YES" : "NO";
}

public void Assert(string s1, string s2, string expectedAnswer)
{
    var actualAnswer = twoStrings(s1, s2);
    if(actualAnswer != expectedAnswer) 
        throw new Exception($"failed {s1}, {s2}, expected: {expectedAnswer}, actual: {actualAnswer}");

}


Assert("hello", "hello", "YES");
Assert("hi", "world", "NO");
