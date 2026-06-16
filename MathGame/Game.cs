using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    internal class Game
    {
        internal DateTime Date { get; set; }
        internal int Score { get; set; }
        internal GameType Type { get; set; }
        internal int Timer { get; set; }
        internal Difficulty Difficulty { get; set; }
    }
    internal enum GameType 
    { 
        Addition,
        Subtraction,
        Multiplication,
        Division,
        Random,
        TEMP
    }
    internal enum Difficulty
{
    Easy,
    Normal,
    Hard,
    Temp
}
}
