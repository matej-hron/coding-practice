<Query Kind="Program" />

void Main()
{
	makeAnagram("fcrxzwscanmligyxyvym", "jxwtrhvujlmrpdoqbisbwhmgpmeoke").Dump();
}

public static int makeAnagram(string a, string b)
{
	
	var allLetters = (a + b).Distinct();
	
	var counts = allLetters.Select(l => (l, countL:a.Count(x => x ==l ), countR:b.Count(x => x == l)));
	return counts.Select(x => Math.Abs(x.countL - x.countR)).Sum();
}
