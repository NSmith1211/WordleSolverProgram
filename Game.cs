using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleSolver
{
    public class Game
    {
        public  string TargetWord { get; set; }
        public string[] TargetWordArray = new string[5];
        

        public Solver Solver;

        public void StartGame()
        {
            CreateTargetWordArray();
            Solver = new Solver();

            while(Solver.GuessesMade <= 20)
            {
                if(Solver.GuessesMade == 1)
                {
                    CheckGuess();
                }

                Solver.MakeNewGuess();
                CheckGuess();
               
                if (IsGameOver())
                {
                    Console.WriteLine();

                    if (this.TargetWord.ToUpper().Equals(Solver.CurrentGuessString.ToUpper()))
                    {
                        Console.WriteLine($"Correct! The word was {TargetWord}");
                        Console.WriteLine($"It took {Solver.GuessesMade} turns to be solved");
                    }
                    else
                    {
                        Console.WriteLine($"Sorry you ran out of turns. The word was: {TargetWord}");
                    }

                    Console.WriteLine("Would you like to play again? (Y/N)");
                    string response = Console.ReadLine().ToUpper();

                    if (response == "Y")
                    {
                        Console.Clear();
                        Game newGame = new Game();
                        newGame.StartGame();
                        Solver = new Solver();
                        
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
            }

        }

        private void CheckGuess()
        {

            foreach(string letter in Solver.CurrentGuess)
            {
                if (TargetWordArray.Contains(letter))
                {
                    Solver.PossibleLetters[letter.ToUpper()].IsCorrectLetter = true;
                }
                else
                {
                    Solver.PossibleLetters[letter.ToUpper()].IsEliminated = true;
                }
            }

            for (int i = 0; i < Solver.CurrentGuess.Length; i++)
            {

                if (Solver.CurrentGuess[i] == TargetWordArray[i])
                {
                    Solver.PossibleLetters[Solver.CurrentGuess[i].ToUpper()].IsInCorrectPlace = true;
                    Solver.PossibleLetters[Solver.CurrentGuess[i].ToUpper()].CorrectIndexes.Add(i);
                    Solver.CorrectLetters.Add(new Letter(Solver.CurrentGuess[i].ToUpper()));
                    Solver.CurrentCorrectArray[i] = Solver.CurrentGuess[i].ToUpper();
                }

            }
            
            

        }



        private bool IsGameOver()
        {
            
            if(Solver.GuessesMade >= 20 || this.TargetWord.ToUpper().Equals(Solver.CurrentGuessString.ToUpper()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void CreateTargetWordArray()
        {
            for(int i = 0;i < TargetWord.Length; i++)
            {
                TargetWordArray[i] = TargetWord[i].ToString();
            }
        }



        public Game()
        {
            this.TargetWord = WordGenerator.ChooseRandomWord();
            
        }
    }
}
