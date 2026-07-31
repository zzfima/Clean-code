internal static class ProgramHelpers
{

    //refactoring 2
    static Cell[] cells =
    {
        new(CellStatus.Empty),
        new(CellStatus.Flagged),
        new(CellStatus.Available),
        new(CellStatus.Flagged)
    };

    public static List<Cell> getFlaggedCellsEx()
    {
        List<Cell> flaggedCells = new List<Cell>();
        foreach (Cell x in cells)
            if (x.IsFlaggedCell())
                flaggedCells.Add(x);
        return flaggedCells;
    }

    public enum CellStatus
    {
        Empty = 1,
        Available = 3,
        Flagged = 4
    }

    public class Cell
    {
        private CellStatus _status;

        public Cell(CellStatus status)
        {
            _status = status;
        }

        internal bool IsFlaggedCell() => _status == CellStatus.Flagged;
    }
}