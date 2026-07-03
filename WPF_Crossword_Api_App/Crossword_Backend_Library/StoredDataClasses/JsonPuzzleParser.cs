using Crossword_Backend_Library.PuzzleClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword_Backend_Library.StoredDataClasses;

public static class JsonPuzzleParser
{
    // Json keys needed for Crossword object:

    // answers: { across, down }
    // author
    // clues: {across, down}
    // copyright
    // date
    // dow
    // editor
    // grid
    // gridnums 
    // publisher
    // size
    // title

    public static Crossword CreatePuzzleFromJson(NytCrosswordJsonObject puzzle)
    {

        Crossword populatedPuzzle = new Crossword(puzzle.Author, puzzle.Copyright, puzzle.Date,
            puzzle.DayOfWeek, puzzle.Editor, puzzle.Title, puzzle.Columns, puzzle.Rows, puzzle.CluesAcross,
            puzzle.CluesDown, puzzle.AnswersAcross, puzzle.AnswersDown, puzzle.Grid, puzzle.GridNumbers);


        return populatedPuzzle;
    }

    //public static Crossword LoadInProgressPuzzle(string fileLocation)
    //{
    //    // Get an in progress crossword from the info storage file
    //}

}
