using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword_Backend_Library.PuzzleClasses;

public class SingleWord
{
    public List<SingleLetter> GuessLetters { get; } = new List<SingleLetter>();
    public string AnswerWord { get; }
    public string Clue { get; }
    public bool Across { get; }

    public SingleWord(string clue, string answer, bool across) 
    {
        Clue = clue;
        AnswerWord = answer;
        Across = across;
    }

    public bool CheckGuess()
    {
        StringBuilder guessWord = new StringBuilder();
        foreach (SingleLetter letter in GuessLetters)
        {
            guessWord.Append(letter.Guess);
        }
        return guessWord.Equals(AnswerWord) ? true : false;
    }
}
