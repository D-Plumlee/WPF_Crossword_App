using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword_Backend_Library.PuzzleClasses;

public class Crossword
{
    public List<SingleWord> Puzzle { get; } = new List<SingleWord>();
    public SingleLetter[,] PuzzleGrid { get; }

    public string Author { get; }
    public string CopyrightInfo { get; }
    public string Date { get; }
    public string DayOfWeek { get; }
    public string Editor { get; }
    public string Title { get; }

    public Crossword(string auth, string copy, string date, string dow, string editor, string title, int sizeAcross, int sizeDown,
        string[] cluesAcross, string[] cluesDown, string[] ansAcross, string[] ansDown, char[] grid, int[] gridNums) 
    {
        Author = auth;
        CopyrightInfo = copy;
        Date = date;
        DayOfWeek = dow;
        Editor = editor;
        Title = title;

        // CreatePuzzleGrid populates the already initialized list of words, Puzzle, while creating the 2d array acting as the displayed grid
        PuzzleGrid = new SingleLetter[sizeAcross, sizeDown];
        CreatePuzzleGrid(sizeAcross, sizeDown, cluesAcross, cluesDown, ansAcross, ansDown, grid, gridNums);
    }


    private void CreatePuzzleGrid(int sizeAcross, int sizeDown,
        string[] cluesAcross, string[] cluesDown, string[] ansAcross, string[] ansDown, char[] grid, int[] gridNums)
    {

        // Loading SingleWord List
        for(int i = 0; i < cluesAcross.Length; i++)
        {
            Puzzle.Add(new SingleWord(cluesAcross[i], ansAcross[i], true));
        }
        for(int i = 0; i < cluesDown.Length; i++)
        {
            Puzzle.Add(new SingleWord(cluesDown[i], ansDown[i], false));
        }


        // Loading PuzzleGrid Array
        int gridAndNumsIndex = 0;
        // Dictionary for linking clues in SingleWord list to the first SingleLetter in their answer
        Dictionary<int, SingleLetter> startingLetters = new Dictionary<int, SingleLetter>();
        for(int i = 0; i < sizeAcross; i++)
        {
            for(int j = 0; j < sizeDown; j++)
            {
                PuzzleGrid[i, j] = new SingleLetter(grid[gridAndNumsIndex], gridNums[gridAndNumsIndex], (i ,j));
                if (gridNums[gridAndNumsIndex] != 0)
                {
                    startingLetters.Add(gridNums[gridAndNumsIndex], PuzzleGrid[i ,j]);
                }
            }
        }


        // Have Words and Letters loaded, still need to attack SingleLetters into their corresponding SingleWords
        foreach(SingleWord currentWord in Puzzle)
        {
            int cluePeriodIndex = -1;
            for(int i = 0; i < currentWord.Clue.Length; i++)
            {
                if (currentWord.Clue[i] == '.')
                {
                    cluePeriodIndex = i;
                    break;
                }
            }
            if(cluePeriodIndex == -1)
            {
                throw new Exception();
            }

            string clueNumberString = currentWord.Clue.Substring(0, cluePeriodIndex);

            bool parseCheck = int.TryParse(clueNumberString, out int clueNumber);

            if (!parseCheck)
            {
                //exception handle

                // probably should throw a message popup that the puzzle did not work and continue to the next puzzle
            }



            // Adds starting letter based on clue number, checks Across bool to see if i or j coordinate positions need to increment
            SingleLetter firstLetter = startingLetters[clueNumber];
            
            currentWord.GuessLetters.Add(firstLetter);

            for(int nextLetterOffset = 1; nextLetterOffset < currentWord.AnswerWord.Length; nextLetterOffset++)
            {
                if (currentWord.Across)
                {
                    currentWord.GuessLetters.Add(PuzzleGrid[firstLetter.GridCoordinates.yCoord, firstLetter.GridCoordinates.xCoord + nextLetterOffset]);
                }
                else
                {
                    currentWord.GuessLetters.Add(PuzzleGrid[firstLetter.GridCoordinates.yCoord + nextLetterOffset, firstLetter.GridCoordinates.xCoord]);
                }
            }

        }
        
    }
}
