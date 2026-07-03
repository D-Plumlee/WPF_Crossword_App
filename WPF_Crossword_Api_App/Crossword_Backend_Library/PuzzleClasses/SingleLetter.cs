using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword_Backend_Library.PuzzleClasses;

public class SingleLetter
{
    private char _firstGuessLetter = ' ';
    private char _secondGuessLetter = ' ';
    private char _currentGuess;
    public char Guess { get => Char.ToLower(_currentGuess);
        set  
        {
            _currentGuess = Char.IsLetter(value) ? value : ' ';
        } 
    }
    private char _correctLetter;
    public bool BlackSpace { get; }
    public int Num { get; }

    public (int yCoord, int xCoord) GridCoordinates { get; }

    public SingleLetter(char answerLetter, int gridNum, (int, int) gridCoordinates)
    {
        _correctLetter = answerLetter;

        // The puzzle Json files use '.' to represent a black square with no letters
        BlackSpace = (_correctLetter == '.');

        Num = gridNum;
        GridCoordinates = gridCoordinates;
    }

    public void SwapHeldGuesses()
    {
        if (Guess == ' ')
        {
            return;
        }

        else if(_firstGuessLetter == ' ')
        {
            _firstGuessLetter = Guess;
            Guess = ' ';
        }
        else if(_secondGuessLetter == ' ')
        {
            _secondGuessLetter = Guess;
            Guess = ' ';
        }
        else
        {
            char temp = Guess;
            Guess = _secondGuessLetter;
            _secondGuessLetter = _firstGuessLetter;
            Guess = temp;
        }
    }
}
