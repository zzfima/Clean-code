using Xunit;

namespace Chapter2.Tests;

public class ProgramTests
{
    [Fact]
    public void GetThem_WithDefaultData_ReturnsTwoFlaggedCells()
    {
        // Arrange
        Program.ResetToDefaultData();

        // Act
        var result = Program.GetThem();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal(4, result[0][0]);
        Assert.Equal(4, result[1][0]);
    }

    [Fact]
    public void GetThem_WithCustomData_ReturnsCorrectFlaggedCells()
    {
        // Arrange
        var testData = new int[][]
        {
            new int[] { 4, 10 },
            new int[] { 2, 20 },
            new int[] { 4, 30 },
            new int[] { 3, 40 },
            new int[] { 4, 50 }
        };
        Program.SetTestData(testData);

        // Act
        var result = Program.GetThem();

        // Assert
        Assert.Equal(3, result.Count);
        Assert.Equal(4, result[0][0]);
        Assert.Equal(4, result[1][0]);
        Assert.Equal(4, result[2][0]);
    }

    [Fact]
    public void GetThem_WithNoFlaggedCells_ReturnsEmptyList()
    {
        // Arrange
        var testData = new int[][]
        {
            new int[] { 1, 10 },
            new int[] { 2, 20 },
            new int[] { 3, 30 }
        };
        Program.SetTestData(testData);

        // Act
        var result = Program.GetThem();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetThem_WithEmptyList_ReturnsEmptyList()
    {
        // Arrange
        Program.SetTestData(Array.Empty<int[]>());

        // Act
        var result = Program.GetThem();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetThem_WithNullList_ReturnsEmptyList()
    {
        // Arrange
        Program.SetTestData(null);

        // Act
        var result = Program.GetThem();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetThem_WithNullCells_ReturnsEmptyList()
    {
        // Arrange
        var testData = new int[][]
        {
            null,
            new int[] { 4, 10 },
            null
        };
        Program.SetTestData(testData);

        // Act
        var result = Program.GetThem();

        // Assert
        Assert.Single(result);
        Assert.Equal(4, result[0][0]);
    }

    [Fact]
    public void GetThem_WithAllFlaggedCells_ReturnsAllCells()
    {
        // Arrange
        var testData = new int[][]
        {
            new int[] { 4, 10 },
            new int[] { 4, 20 },
            new int[] { 4, 30 }
        };
        Program.SetTestData(testData);

        // Act
        var result = Program.GetThem();

        // Assert
        Assert.Equal(3, result.Count);
    }

    [Fact]
    public void GetFlaggedCells_WithDefaultData_ReturnsTwoFlaggedCells()
    {
        // Arrange
        Program.ResetToDefaultData();

        // Act
        var result = Program.GetFlaggedCells();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal(4, result[0][0]);
        Assert.Equal(4, result[1][0]);
    }

    [Fact]
    public void GetFlaggedCells_WithCustomData_ReturnsCorrectFlaggedCells()
    {
        // Arrange
        var testData = new int[][]
        {
            new int[] { 4, 10 },
            new int[] { 2, 20 },
            new int[] { 4, 30 },
            new int[] { 3, 40 },
            new int[] { 4, 50 }
        };
        Program.SetTestData(testData);

        // Act
        var result = Program.GetFlaggedCells();

        // Assert
        Assert.Equal(3, result.Count);
        Assert.Equal(4, result[0][0]);
        Assert.Equal(4, result[1][0]);
        Assert.Equal(4, result[2][0]);
    }

    [Fact]
    public void GetFlaggedCells_WithNoFlaggedCells_ReturnsEmptyList()
    {
        // Arrange
        var testData = new int[][]
        {
            new int[] { 1, 10 },
            new int[] { 2, 20 },
            new int[] { 3, 30 }
        };
        Program.SetTestData(testData);

        // Act
        var result = Program.GetFlaggedCells();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetFlaggedCells_WithEmptyList_ReturnsEmptyList()
    {
        // Arrange
        Program.SetTestData(Array.Empty<int[]>());

        // Act
        var result = Program.GetFlaggedCells();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetFlaggedCells_WithNullList_ReturnsEmptyList()
    {
        // Arrange
        Program.SetTestData(null);

        // Act
        var result = Program.GetFlaggedCells();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetFlaggedCells_WithNullCells_ReturnsEmptyList()
    {
        // Arrange
        var testData = new int[][]
        {
            null,
            new int[] { 4, 10 },
            null
        };
        Program.SetTestData(testData);

        // Act
        var result = Program.GetFlaggedCells();

        // Assert
        Assert.Single(result);
        Assert.Equal(4, result[0][0]);
    }

    [Fact]
    public void GetFlaggedCells_WithAllFlaggedCells_ReturnsAllCells()
    {
        // Arrange
        var testData = new int[][]
        {
            new int[] { 4, 10 },
            new int[] { 4, 20 },
            new int[] { 4, 30 }
        };
        Program.SetTestData(testData);

        // Act
        var result = Program.GetFlaggedCells();

        // Assert
        Assert.Equal(3, result.Count);
    }

    [Fact]
    public void SetTestData_SetsCustomDataCorrectly()
    {
        // Arrange
        var testData = new int[][]
        {
            new int[] { 5, 10 },
            new int[] { 6, 20 }
        };

        // Act
        Program.SetTestData(testData);

        // Assert
        Assert.Equal(2, Program.TheList.Length);
        Assert.Equal(5, Program.TheList[0][0]);
        Assert.Equal(6, Program.TheList[1][0]);
    }

    [Fact]
    public void ResetToDefaultData_ResetsToInitialData()
    {
        // Arrange
        var testData = new int[][]
        {
            new int[] { 5, 10 },
            new int[] { 6, 20 }
        };
        Program.SetTestData(testData);

        // Act
        Program.ResetToDefaultData();

        // Assert
        Assert.Equal(4, Program.TheList.Length);
        Assert.Equal(1, Program.TheList[0][0]);
        Assert.Equal(4, Program.TheList[1][0]);
        Assert.Equal(3, Program.TheList[2][0]);
        Assert.Equal(4, Program.TheList[3][0]);
    }

    [Fact]
    public void GetThem_And_GetFlaggedCells_ReturnSameResults()
    {
        // Arrange
        Program.ResetToDefaultData();

        // Act
        var result1 = Program.GetThem();
        var result2 = Program.GetFlaggedCells();

        // Assert
        Assert.Equal(result1.Count, result2.Count);
        for (int i = 0; i < result1.Count; i++)
        {
            Assert.Equal(result1[i][0], result2[i][0]);
        }
    }

    [Fact]
    public void RunDemo_ExecutesSuccessfully()
    {
        // Arrange & Act
        Program.RunDemo();

        // Assert - if no exception is thrown, the test passes
        Assert.True(true);
    }
}