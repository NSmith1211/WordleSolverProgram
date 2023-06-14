using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleSolver
{
    public class Solver
    {
        Dictionary<string, Letter> PossibleLetters = new Dictionary<string, Letter>()
        {
            {"A", new Letter("A")},
            {"B", new Letter("B")},
            {"C", new Letter("C")},
            {"D", new Letter("D")},
            {"E", new Letter("E")},
            {"F", new Letter("F")},
            {"G", new Letter("G")},
            {"H", new Letter("H")},
            {"I", new Letter("I")},
            {"J", new Letter("J")},
            {"K", new Letter("K")},
            {"L", new Letter("L")},
            {"M", new Letter("M")},
            {"N", new Letter("N")},
            {"O", new Letter("O")},
            {"P", new Letter("P")},
            {"Q", new Letter("Q")},
            {"R", new Letter("R")},
            {"S", new Letter("S")},
            {"T", new Letter("T")},
            {"U", new Letter("U")},
            {"V", new Letter("V")},
            {"W", new Letter("W")},
            {"X", new Letter("X")},
            {"Y", new Letter("Y")},
            {"Z", new Letter("Z")},
        };
        public int GuessesMade { get; private set; } = 0;
        public List<string> NotCorrectlyPlaced = new List<string>();
        public string[] CurrentCorrectArray = new string[5];
        public string[] CurrentGuess = new string[5];
        

        public string[] MakeNewGuess(string[] currentCorrectArray)
        {
            //If first guess; then select random word.
            if(GuessesMade == 0)
            {
                this.CurrentGuess = ConvertCharArrayToStringArray(GetRandomStartingWord());                
            }
            else
            {
            // TODO: Get next guess by lookig at CurrentCorrectArray and searching for word that matches criteria
            }
            

            return CurrentGuess;
            this.GuessesMade++;
        }

        private  string[] MakeNewGuess()
        {
            this.CurrentGuess = ConvertCharArrayToStringArray(GetRandomStartingWord());
            return CurrentGuess;
            this.GuessesMade++;
        }

        

        private string GetRandomStartingWord()
        {
            //Select random word, if the letters are not all unique, get new word.
            string newGuess = WordGenerator.ChooseRandomWord();
            if (newGuess.Distinct().Count() != newGuess.Count())
            {
                GetRandomStartingWord();
            }
            return newGuess;
        }

        private static string[] ConvertCharArrayToStringArray(string guess)
        {
            //Convert the guess string to an array of strings
            string[] newArray = new string[guess.Length];
            for(int i = 0; i < guess.Length; i++)
            {
                newArray[i] = guess[i].ToString();
            }
            return newArray;
        }

        public Solver()
        {
            MakeNewGuess();
        }

    }
}
