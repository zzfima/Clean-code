using System.Diagnostics;

internal class Program
{
    static int[][] theList = new int[4][];

    private static void Main(string[] args)
    {
        theList[0] = new int[] { 1, 0 };
        theList[1] = new int[] { 4, 1 };
        theList[2] = new int[] { 3, 2 };
        theList[3] = new int[] { 4, 3 };

        var v1 = getThem();
        var v2 = getFlaggedCells();
        var v3 = getFlaggedCellsEx();
    }

    //before
    public static List<int[]> getThem()
    {
        List<int[]> list1 = new List<int[]>();
        foreach (int[] x in theList)
            if (x[0] == 4)
                list1.Add(x);
        return list1;
    }

    //refactoring 1
    static int FLAGGED = 4;
    static int STATUS_VALUE = 0;
    static int[][] theBoard = theList;

    public static List<int[]> getFlaggedCells()
    {
        List<int[]> flaggedCells = new List<int[]>();
        foreach (int[] x in theBoard)
            if (x[STATUS_VALUE] == FLAGGED)
                flaggedCells.Add(x);
        return flaggedCells;
    }

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