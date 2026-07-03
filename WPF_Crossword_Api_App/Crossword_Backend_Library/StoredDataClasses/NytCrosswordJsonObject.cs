using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Crossword_Backend_Library.StoredDataClasses;

public class NytCrosswordJsonObject
{
    // Class to deserialize doshea's NYT Crossword Json files into
    // (sourced from https://github.com/doshea/nyt_crosswords)

    /*
     * Json keys: (? is null value in 01.json)
     * 
     * "acrossmap" : ?
     * "admin": bool
     * "answers": {
     *      "across": []string
     *      "down": []string
     * }
     * "author": string
     * "autowrap": ?
     * "bbars": ?
     * "circles": ?
     * "clues": {
     *      "across": []string
     *      "down": []string
     * }
     * "code": ?
     * "copyright": string
     * "date": string
     * "dow": string
     * "downmap": ?
     * "editor": string
     * "grid": []string
     * "gridnums": []int
     * "hold": ?
     * "id": ?
     * "id2": ?
     * "interpretcolors": ?
     * "jnotes": ?
     * "key": ?
     * "mini": ?
     * "notepad": ?
     * "publisher": string
     * "rbars": ?
     * "shadecircles": ?
     * "size": {
     *      "cols": int
     *      "rows": int
     * }
     * "title": string
     * "track": ?
     * "type": ?
     * 
     */

    // All variables not used in early crossword json files are temporarily being represented as nullable strings

    public string? Acrossmap;
    public bool Admin;
    public Dictionary<string, string[]> Answers;
    public string Author;
    public string? Autowrap;
    public string? Bbars;
    public string? Circles;
    public Dictionary<string, string[]> Clues;
    public string? Code;
    public string Copyright;
    public string Date;
    public string Dow;
    public string? Downmap;
    public string Editor;
    public string[] Grid;
    public int[] Gridnums;
    public string? Hold;
    public string? Id;
    public string? Id2;
    public string? Interpretcolors;
    public string? Jnotes;
    public string? Key;
    public string? Mini;
    public string? Notepad;
    public string Publisher;
    public string? Rbars;
    public string? Shadecircles;
    public Dictionary<string, int> Size;
    public string Title;
    public string? Track;
    public string? Type;
}
