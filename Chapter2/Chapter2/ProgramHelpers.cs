public static class CProgramHelpers
{
    private static CCell[] m_cells =
    {
        new(CellStatus.Empty),
        new(CellStatus.Flagged),
        new(CellStatus.Available),
        new(CellStatus.Flagged)
    };

    // Test helper method to set up test data
    public static void SetTestData(CCell[] testData)
    {
        m_cells = testData;
    }

    // Test helper method to reset to default data
    public static void ResetToDefaultData()
    {
        m_cells = new CCell[]
        {
            new(CellStatus.Empty),
            new(CellStatus.Flagged),
            new(CellStatus.Available),
            new(CellStatus.Flagged)
        };
    }

    //TODO: Implement GetFlaggedCellsEx() method to return a list of flagged cells
    public static List<CCell> GetFlaggedCellsEx()
    {
        List<CCell> flaggedCells = new List<CCell>();
        if (m_cells == null) return flaggedCells;

        foreach (CCell x in m_cells)
            if (x != null && x.IsFlaggedCell())
                flaggedCells.Add(x);
        return flaggedCells;
    }

    public enum CellStatus
    {
        Empty = 1,
        Available = 3,
        Flagged = 4
    }

    public class CCell
    {
        private CellStatus m_status;

        public CCell(CellStatus status)
        {
            m_status = status;
        }

        public bool IsFlaggedCell() => m_status == CellStatus.Flagged;
    }
}