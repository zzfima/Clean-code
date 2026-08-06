namespace Chapter2;

public class Program
{
    private const int flagged = 4;
    private const int statusIndex = 0;
    private static int[][] cellList = new int[4][];
    private static int[][] cellBoard = cellList;

    public static void RunDemo()
    {
        ResetToDefaultData();

        List<int[]> originalFlaggedCells = GetThem();
        List<int[]> refactoredFlaggedCells = GetFlaggedCells();
        List<ProgramHelpers.Cell> finalRefactoredFlaggedCells = ProgramHelpers.GetFlaggedCellsEx();

        Console.WriteLine("clean code first refactoring");
    }

    private static void Main(string[] args)
    {
        RunDemo();
    }

    // Test helper method to set up test data
    public static void SetTestData(int[][] testData)
    {
        cellList = testData;
        cellBoard = testData;
    }

    // Test helper method to reset to default data
    public static void ResetToDefaultData()
    {
        cellList = new int[4][];
        cellList[0] = new int[] { 1, 0 };
        cellList[1] = new int[] { 4, 1 };
        cellList[2] = new int[] { 3, 2 };
        cellList[3] = new int[] { 4, 3 };
        cellBoard = cellList;
    }

    //before
    public static List<int[]> GetThem()
    {
        List<int[]> flaggedCells = new List<int[]>();
        if (cellList == null)
        {
            return flaggedCells;
        }

        foreach (int[] cell in cellList)
        {
            if (cell != null && cell[0] == 4)
            {
                flaggedCells.Add(cell);
            }
        }

        return flaggedCells;
    }

    //refactoring 1
    public static List<int[]> GetFlaggedCells()
    {
        List<int[]> flaggedCells = new List<int[]>();
        if (cellBoard == null)
        {
            return flaggedCells;
        }

        foreach (int[] cell in cellBoard)
        {
            if (cell != null && cell[statusIndex] == flagged)
            {
                flaggedCells.Add(cell);
            }
        }

        return flaggedCells;
    }
}
