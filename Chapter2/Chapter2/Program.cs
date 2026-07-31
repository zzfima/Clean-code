using System.Diagnostics;

public class Program
{
    public static int[][] TheList = new int[4][];

    // Test helper method to set up test data
    public static void SetTestData(int[][] testData)
    {
        TheList = testData;
        theBoard = testData;
    }

    // Test helper method to reset to default data
    public static void ResetToDefaultData()
    {
        TheList = new int[4][];
        TheList[0] = new int[] { 1, 0 };
        TheList[1] = new int[] { 4, 1 };
        TheList[2] = new int[] { 3, 2 };
        TheList[3] = new int[] { 4, 3 };
        theBoard = TheList;
    }

    public static void RunDemo()
    {
        ResetToDefaultData();

        var originalFlaggedCells = GetThem();
        var refactoredFlaggedCells = GetFlaggedCells();
        var finalRefactoredFlaggedCells = ProgramHelpers.GetFlaggedCellsEx();

        Console.WriteLine("clean code first refactoring");
    }

    private static void Main(string[] args)
    {
        RunDemo();
    }

    //before
    public static List<int[]> GetThem()
    {
        List<int[]> list1 = new List<int[]>();
        if (TheList == null) return list1;
        
        foreach (int[] x in TheList)
            if (x != null && x[0] == 4)
                list1.Add(x);
        return list1;
    }

    //refactoring 1
    static int FLAGGED = 4;
    static int STATUS_VALUE = 0;
    static int[][] theBoard = TheList;

    public static List<int[]> GetFlaggedCells()
    {
        List<int[]> flaggedCells = new List<int[]>();
        if (theBoard == null) return flaggedCells;
        
        foreach (int[] x in theBoard)
            if (x != null && x[STATUS_VALUE] == FLAGGED)
                flaggedCells.Add(x);
        return flaggedCells;
    }
}