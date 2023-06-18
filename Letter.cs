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
        public bool IsCorrectLetter { get; set; } = false;
        public string ActualLetter { get; set; }

        public List<int> CorrectIndexes = new List<int>();
        public bool IsEliminated { get; set; } = false;
        public int NumberOfAppearancesInTarget { get; set; } = 0;







        public Letter(string actualLetter)
        {

            ActualLetter = actualLetter;

        }

    }
}
