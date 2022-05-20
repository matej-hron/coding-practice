#!/usr/bin/env dotnet-script

public class Zapujcka{
    public string Name {get; set;}
    public string Book {get; set;}

    public Zapujcka(string name, string book)
    {
        Name = name;
        Book = book;
    }
}

public IEnumerable<string> GetPeopleWhoRead(IEnumerable<Zapujcka> zapujcky, int count, params string[] books)
{
    var interestBooksBooks = new HashSet<string>(books);
    var peopleToInterestBooksMap = new Dictionary<string, HashSet<string>>();
    var peopleYielded = new HashSet<string>();

    foreach(var zapujcka in zapujcky)
    {
        if(interestBooksBooks.Contains(zapujcka.Book))
        {
            peopleToInterestBooksMap.TryGetValue(zapujcka.Name, out var b);
            b = b ?? new HashSet<string>();
            b.Add(zapujcka.Book);
            peopleToInterestBooksMap[zapujcka.Name] = b;

            if(books.Count() == 2 && !peopleYielded.Contains(zapujcka.Name))
            {
                peopleYielded.Add(zapujcka.Name);
                yield return zapujcka.Name;
            }
        }
    }
}

var zapujcky = new List<Zapujcka>
{
    new("koci", "ferda mravenec"),
    new("matej", "pan prstenu"),
    new("koci", "luisa a lotka"),
    new("matej", "hobit"),
    new("gleb", "zapisky silencovi")
};
Console.WriteLine("OK");
var names = GetPeopleWhoRead(zapujcky, 2, "ferda mravenec", "luisa a lotka").Take(1);

Console.WriteLine(string.Join(',', names));
