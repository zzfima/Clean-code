using Xunit;

namespace Chapter2.Tests;

public class ProgramHelpersTests
{
    [Fact]
    public void GetFlaggedCellsEx_WithDefaultData_ReturnsTwoFlaggedCells()
    {
        // Arrange
        ProgramHelpers.ResetToDefaultData();

        // Act
        var result = ProgramHelpers.GetFlaggedCellsEx();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.True(result[0].IsFlaggedCell());
        Assert.True(result[1].IsFlaggedCell());
    }

    [Fact]
    public void GetFlaggedCellsEx_WithCustomData_ReturnsCorrectFlaggedCells()
    {
        // Arrange
        var testData = new ProgramHelpers.Cell[]
        {
            new ProgramHelpers.Cell(ProgramHelpers.CellStatus.Flagged),
            new ProgramHelpers.Cell(ProgramHelpers.CellStatus.Empty),
            new ProgramHelpers.Cell(ProgramHelpers.CellStatus.Flagged),
            new ProgramHelpers.Cell(ProgramHelpers.CellStatus.Available),
            new ProgramHelpers.Cell(ProgramHelpers.CellStatus.Flagged)
        };
        ProgramHelpers.SetTestData(testData);

        // Act
        var result = ProgramHelpers.GetFlaggedCellsEx();

        // Assert
        Assert.Equal(3, result.Count);
        Assert.True(result[0].IsFlaggedCell());
        Assert.True(result[1].IsFlaggedCell());
        Assert.True(result[2].IsFlaggedCell());
    }

    [Fact]
    public void GetFlaggedCellsEx_WithNoFlaggedCells_ReturnsEmptyList()
    {
        // Arrange
        var testData = new ProgramHelpers.Cell[]
        {
            new ProgramHelpers.Cell(ProgramHelpers.CellStatus.Empty),
            new ProgramHelpers.Cell(ProgramHelpers.CellStatus.Available),
            new ProgramHelpers.Cell(ProgramHelpers.CellStatus.Empty)
        };
        ProgramHelpers.SetTestData(testData);

        // Act
        var result = ProgramHelpers.GetFlaggedCellsEx();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetFlaggedCellsEx_WithEmptyList_ReturnsEmptyList()
    {
        // Arrange
        ProgramHelpers.SetTestData(Array.Empty<ProgramHelpers.Cell>());

        // Act
        var result = ProgramHelpers.GetFlaggedCellsEx();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetFlaggedCellsEx_WithNullList_ReturnsEmptyList()
    {
        // Arrange
        ProgramHelpers.SetTestData(null);

        // Act
        var result = ProgramHelpers.GetFlaggedCellsEx();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetFlaggedCellsEx_WithNullCells_ReturnsEmptyList()
    {
        // Arrange
        var testData = new ProgramHelpers.Cell[]
        {
            null,
            new ProgramHelpers.Cell(ProgramHelpers.CellStatus.Flagged),
            null
        };
        ProgramHelpers.SetTestData(testData);

        // Act
        var result = ProgramHelpers.GetFlaggedCellsEx();

        // Assert
        Assert.Single(result);
        Assert.True(result[0].IsFlaggedCell());
    }

    [Fact]
    public void GetFlaggedCellsEx_WithAllFlaggedCells_ReturnsAllCells()
    {
        // Arrange
        var testData = new ProgramHelpers.Cell[]
        {
            new ProgramHelpers.Cell(ProgramHelpers.CellStatus.Flagged),
            new ProgramHelpers.Cell(ProgramHelpers.CellStatus.Flagged),
            new ProgramHelpers.Cell(ProgramHelpers.CellStatus.Flagged)
        };
        ProgramHelpers.SetTestData(testData);

        // Act
        var result = ProgramHelpers.GetFlaggedCellsEx();

        // Assert
        Assert.Equal(3, result.Count);
    }

    [Fact]
    public void Cell_Constructor_SetsStatusCorrectly()
    {
        // Arrange & Act
        var cell = new ProgramHelpers.Cell(ProgramHelpers.CellStatus.Flagged);

        // Assert
        Assert.True(cell.IsFlaggedCell());
    }

    [Fact]
    public void Cell_IsFlaggedCell_WithFlaggedStatus_ReturnsTrue()
    {
        // Arrange
        var cell = new ProgramHelpers.Cell(ProgramHelpers.CellStatus.Flagged);

        // Act
        var result = cell.IsFlaggedCell();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Cell_IsFlaggedCell_WithEmptyStatus_ReturnsFalse()
    {
        // Arrange
        var cell = new ProgramHelpers.Cell(ProgramHelpers.CellStatus.Empty);

        // Act
        var result = cell.IsFlaggedCell();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Cell_IsFlaggedCell_WithAvailableStatus_ReturnsFalse()
    {
        // Arrange
        var cell = new ProgramHelpers.Cell(ProgramHelpers.CellStatus.Available);

        // Act
        var result = cell.IsFlaggedCell();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void CellStatus_Enum_HasCorrectValues()
    {
        // Assert
        Assert.Equal(1, (int)ProgramHelpers.CellStatus.Empty);
        Assert.Equal(3, (int)ProgramHelpers.CellStatus.Available);
        Assert.Equal(4, (int)ProgramHelpers.CellStatus.Flagged);
    }

    [Fact]
    public void SetTestData_SetsCustomDataCorrectly()
    {
        // Arrange
        var testData = new ProgramHelpers.Cell[]
        {
            new ProgramHelpers.Cell(ProgramHelpers.CellStatus.Empty),
            new ProgramHelpers.Cell(ProgramHelpers.CellStatus.Available)
        };

        // Act
        ProgramHelpers.SetTestData(testData);

        // Assert
        var result = ProgramHelpers.GetFlaggedCellsEx();
        Assert.Empty(result); // No flagged cells in custom data
    }

    [Fact]
    public void ResetToDefaultData_ResetsToInitialData()
    {
        // Arrange
        var testData = new ProgramHelpers.Cell[]
        {
            new ProgramHelpers.Cell(ProgramHelpers.CellStatus.Empty),
            new ProgramHelpers.Cell(ProgramHelpers.CellStatus.Available)
        };
        ProgramHelpers.SetTestData(testData);

        // Act
        ProgramHelpers.ResetToDefaultData();

        // Assert
        var result = ProgramHelpers.GetFlaggedCellsEx();
        Assert.Equal(2, result.Count); // Default data has 2 flagged cells
    }

    [Fact]
    public void GetFlaggedCellsEx_WithMixedStatuses_ReturnsOnlyFlagged()
    {
        // Arrange
        var testData = new ProgramHelpers.Cell[]
        {
            new ProgramHelpers.Cell(ProgramHelpers.CellStatus.Empty),
            new ProgramHelpers.Cell(ProgramHelpers.CellStatus.Flagged),
            new ProgramHelpers.Cell(ProgramHelpers.CellStatus.Available),
            new ProgramHelpers.Cell(ProgramHelpers.CellStatus.Flagged),
            new ProgramHelpers.Cell(ProgramHelpers.CellStatus.Empty)
        };
        ProgramHelpers.SetTestData(testData);

        // Act
        var result = ProgramHelpers.GetFlaggedCellsEx();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.True(result[0].IsFlaggedCell());
        Assert.True(result[1].IsFlaggedCell());
    }

    [Fact]
    public void CellStatus_Empty_HasValue1()
    {
        // Assert
        Assert.Equal(1, (int)ProgramHelpers.CellStatus.Empty);
    }

    [Fact]
    public void CellStatus_Available_HasValue3()
    {
        // Assert
        Assert.Equal(3, (int)ProgramHelpers.CellStatus.Available);
    }

    [Fact]
    public void CellStatus_Flagged_HasValue4()
    {
        // Assert
        Assert.Equal(4, (int)ProgramHelpers.CellStatus.Flagged);
    }
}