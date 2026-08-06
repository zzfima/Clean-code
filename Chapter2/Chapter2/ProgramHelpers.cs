public static class ProgramHelpers
{
    private static Cell[] cells =
    {
        new(CellStatus.Empty),
        new(CellStatus.Flagged),
        new(CellStatus.Available),
        new(CellStatus.Flagged)
    };

    // Test helper method to set up test data
    public static void SetTestData(Cell[] testData)
    {
        cells = testData;
    }

    // Test helper method to reset to default data
    public static void ResetToDefaultData()
    {
        cells = new Cell[]
        {
            new(CellStatus.Empty),
            new(CellStatus.Flagged),
            new(CellStatus.Available),
            new(CellStatus.Flagged)
        };
    }

    //TODO: Implement GetFlaggedCellsEx() method to return a list of flagged cells
    public static List<Cell> GetFlaggedCellsEx()
    {
        List<Cell> flaggedCells = new List<Cell>();
        if (cells == null) return flaggedCells;

        foreach (Cell cell in cells)
            if (cell != null && cell.IsFlaggedCell())
                flaggedCells.Add(cell);
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
        private CellStatus cellStatus;

        public Cell(CellStatus status)
        {
            cellStatus = status;
        }

        public bool IsFlaggedCell() => cellStatus == CellStatus.Flagged;
    }
}