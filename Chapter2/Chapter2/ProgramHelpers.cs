internal static class ProgramHelpers
{

    //refactoring 2
    static Cell[] cells =
    {
        new(CellStatus.Empty, 0),
        new(CellStatus.Flagged, 1),
        new(CellStatus.Available, 2),
        new(CellStatus.Flagged, 3)
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
        private int _value;

        public Cell(CellStatus status, int value)
        {
            _status = status;
            _value = value;
        }

        internal bool IsFlaggedCell() => _status == CellStatus.Flagged;
    }
}