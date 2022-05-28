/*
     * Complete the 'crosswordPuzzle' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts following parameters:
     *  1. STRING_ARRAY crossword
     *  2. STRING words
     */

    public static List<string> CrosswordPuzzle(List<string> crossword, string words)
    {
        var w = words.Split(';').ToList();
        var candidates =  FillRows(crossword, w);

        return candidates[0];

    }

    public static List<List<string>> FillRows(List<string> crossword, List<string> words, int wordIndex = 0)
    {
        //terminate guard
        var res = new List<List<string>>();

        if(wordIndex == words.Count()) return res;

        var word = words[wordIndex];

        for(int i = 0; i < crossword.Count(); i++)
        {
            var wordPlaceholder = new string('-', word.Length);
            if(crossword[i].Contains(wordPlaceholder))
            {
                crossword[i] = crossword[i].Replace(wordPlaceholder, word);
                res.AddRange(FillRows(crossword, words, wordIndex+1));
            }
        }

        res.AddRange(FillRows)

        return res;
    }

   
    var crossword = new List<string>{
    "+-++++++++",
    "+-++++++++",
    "+-++++++++",
    "+-----++++",
    "+-+++-++++",
    "+-+++-++++",
    "+++++-++++",
    "++------++",
    "+++++-++++",
    "+++++-++++",
    };
    var words = "LONDON;DELHI;ICELAND;ANKARA";

    CrosswordPuzzle(crossword, words);