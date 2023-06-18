using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WordleSolver
{
    public class Solver
    {
        public Dictionary<string, Letter> PossibleLetters = new Dictionary<string, Letter>()
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
        public string CurrentGuessString { get; set; }
        public List<Letter> CorrectLetters = new List<Letter>();
        public List<string> AvailableWords = new List<string>();

        public string[] MakeNewGuess(string[] currentCorrectArray)
        {
            CurrentGuessString = "";
            //If first guess; then select random word.
            if(GuessesMade == 0)
            {
                this.CurrentGuess = ConvertCharArrayToStringArray(GetRandomStartingWord());                
            }
            else
            {
                // TODO: Get next guess by lookig at CurrentCorrectArray and searching for word that matches criteria

                try
                {

                    string directory = Environment.CurrentDirectory;
                    string fileName = "answers.txt";
                    string fullPath = Path.Combine(directory, fileName);
                    using (StreamReader sr = new StreamReader(fullPath))
                    {
                        //Convert whole file to one string
                        string wholeFile = sr.ReadToEnd();
                        //Convert one string to list of strings
                        List<string> words = wholeFile.Split("\n").ToList();
                        //How it matches to CurrentCorrectArray
                        AvailableWords = words;
                    }
                }
                catch
                {

                    Console.WriteLine("Sorry, there was an error reading the file.");

                }

                for (int i = 0; i < CurrentCorrectArray.Length; i++)
                {
                    if (CurrentCorrectArray[i] != null && PossibleLetters[CurrentCorrectArray[i]].IsInCorrectPlace)
                    {
                        List<string> reducedWords = AvailableWords;
                        reducedWords =
                            (List<string>)(from word in reducedWords
                             where word[i].ToString().ToUpper() == CurrentCorrectArray[i]
                             select word).ToList();

                        AvailableWords = reducedWords;
                    }

                }

                foreach (string item in NotCorrectlyPlaced)
                {
                    List<string> reducedWords =
                        (List<string>)AvailableWords.Where(word => word.Contains(item.ToUpper()))
                        .Select(word => word).ToList();

                    AvailableWords = reducedWords;
                }

                foreach (KeyValuePair<string, Letter> kvp in PossibleLetters)
                {
                    if (kvp.Value.IsEliminated)
                    {
                        List<string> reducedWords =
                            (List<string>)AvailableWords.Where(word => !word.Contains(kvp.Key.ToUpper()))
                            .Select(word => word).ToList();

                        AvailableWords = reducedWords;
                    }
                }

                if(AvailableWords.Count == 2315)
                {
                    string nextGuess = GetRandomStartingWord();
                    Console.WriteLine();
                    Console.WriteLine($"Next Guess:     {nextGuess}");
                    CurrentGuess = ConvertCharArrayToStringArray(nextGuess);

                }
                else
                {
                    Random r = new Random();
                    
                    CurrentGuess = ConvertCharArrayToStringArray(AvailableWords[r.Next(0, AvailableWords.Count)]);
                    Console.WriteLine();
                    Console.Write("Next Guess:     ");
                    foreach(string item in CurrentGuess)
                    {
                        Console.Write(item);
                    }
                }

                foreach(string item in CurrentGuess)
                {
                    CurrentGuessString += item;
                }
                

                this.GuessesMade++;
                return CurrentGuess;

            }

            return CurrentGuess;
        }

        private  string[] MakeNewGuess()
        {
            this.CurrentGuess = ConvertCharArrayToStringArray(GetRandomStartingWord());
            this.GuessesMade++;
            return CurrentGuess;
            
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
