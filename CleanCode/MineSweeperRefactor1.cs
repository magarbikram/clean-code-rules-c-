using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    internal class MineSweeperRefactor1
    {
        private const int Flagged = 4;
        private const int StatusIndex = 0;
        private IList<int[]> gameBoard = new List<int[]>();

        public IList<int[]> GetFlaggedCells()
        {
            IList<int[]> flaggedCells = new List<int[]>();
            foreach (int[] cell in gameBoard)
            {
                if (cell[StatusIndex] == Flagged)
                {
                    flaggedCells.Add(cell);
                }
            }
            return flaggedCells;
        }
    }
}
