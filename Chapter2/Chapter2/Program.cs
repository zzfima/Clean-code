namespace Chapter2;

public class CProgram
{
    private const int m_flagged = 4;
    private const int m_statusIndex = 0;
    private static int[][] m_list = new int[4][];
    private static int[][] m_board = m_list;

    public static void RunDemo()
    {
        ResetToDefaultData();

        List<int[]> originalFlaggedCells = GetThem();
        List<int[]> refactoredFlaggedCells = GetFlaggedCells();
        List<CProgramHelpers.CCell> finalRefactoredFlaggedCells = CProgramHelpers.GetFlaggedCellsEx();

        Console.WriteLine("clean code first refactoring");
    }

    private static void Main(string[] args)
    {
        RunDemo();
    }

    // Test helper method to set up test data
    public static void SetTestData(int[][] testData)
    {
        m_list = testData;
        m_board = testData;
    }

    // Test helper method to reset to default data
    public static void ResetToDefaultData()
    {
        m_list = new int[4][];
        m_list[0] = new int[] { 1, 0 };
        m_list[1] = new int[] { 4, 1 };
        m_list[2] = new int[] { 3, 2 };
        m_list[3] = new int[] { 4, 3 };
        m_board = m_list;
    }

    //before
    public static List<int[]> GetThem()
    {
        List<int[]> list1 = new List<int[]>();
        if (m_list == null)
        {
            return list1;
        }

        foreach (int[] x in m_list)
        {
            if (x != null && x[0] == 4)
            {
                list1.Add(x);
            }
        }

        return list1;
    }

    //refactoring 1
    public static List<int[]> GetFlaggedCells()
    {
        List<int[]> flaggedCells = new List<int[]>();
        if (m_board == null)
        {
            return flaggedCells;
        }

        foreach (int[] x in m_board)
        {
            if (x != null && x[m_statusIndex] == m_flagged)
            {
                flaggedCells.Add(x);
            }
        }

        return flaggedCells;
    }
}
