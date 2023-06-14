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
        public  string[] TargetWordArray
        {
            get
            {
                for(int i = 0; i < TargetWord.Length; i++)
                {
                    TargetWordArray[i] = TargetWord[i].ToString();
                }
                return TargetWordArray;
            }
        }
        public Solver Solver;

        public void StartGame()
        {
            Solver = new Solver();

        }

        private void CheckGuess()
        {

        }









        public Game()
        {
            this.TargetWord = WordGenerator.ChooseRandomWord();
            
        }
    }
}
