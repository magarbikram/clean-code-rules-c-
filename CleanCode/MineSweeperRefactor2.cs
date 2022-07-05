using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    internal class MineSweeperRefactor2
    {
        private IList<Cell> gameBoard = new List<Cell>();

        public IList<Cell> GetFlaggedCells()
        {
            IList<Cell> flaggedCells = new List<Cell>();
            foreach (Cell cell in gameBoard)
            {
                if (cell.IsFlagged())
                {
                    flaggedCells.Add(cell);
                }
            }
            return flaggedCells;
        }
    }
    internal class Cell
    {
        private bool _isFlagged;
        public bool IsFlagged()
        {
            return _isFlagged;
        }
    }
}
