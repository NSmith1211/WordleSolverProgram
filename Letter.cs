using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleSolver
{
    public class Letter
    {
        public bool IsInCorrectPlace { get; set; } = false;
        public bool IsCorrectLetterWrongPlace { get; set; } = false;
        public string ActualLetter { get; set; }







        public Letter(string actualLetter)
        {

            ActualLetter = actualLetter;

        }

    }
}
