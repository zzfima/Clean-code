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

        var originalFlaggedCells = getThem();
        var refactoredFlaggedCells = getFlaggedCells();
        var finalRefactoredFlaggedCells = ProgramHelpers.getFlaggedCellsEx();
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
}