// See https://aka.ms/new-console-template for more information
using Xunit;

Console.WriteLine("Hello, World!");
class Cell
{
    internal bool IsFlagged()
    {
        throw new NotImplementedException();
    }
}
class Program2
{
    IList<Cell> gameBoard = new List<Cell>();
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
