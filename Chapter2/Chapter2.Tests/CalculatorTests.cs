namespace Chapter2.Tests;

public class CalculatorTests
{
    private readonly Calculator _calculator;

    public CalculatorTests()
    {
        _calculator = new Calculator();
    }

    [Fact]
    public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
    {
        // Arrange
        int a = 5;
        int b = 3;

        // Act
        int result = _calculator.Add(a, b);

        // Assert
        Assert.Equal(8, result);
    }

    [Fact]
    public void Add_PositiveAndNegativeNumbers_ReturnsCorrectSum()
    {
        // Arrange
        int a = 10;
        int b = -3;

        // Act
        int result = _calculator.Add(a, b);

        // Assert
        Assert.Equal(7, result);
    }

    [Fact]
    public void Add_TwoNegativeNumbers_ReturnsCorrectSum()
    {
        // Arrange
        int a = -5;
        int b = -3;

        // Act
        int result = _calculator.Add(a, b);

        // Assert
        Assert.Equal(-8, result);
    }

    [Fact]
    public void Add_ZeroAndNumber_ReturnsSameNumber()
    {
        // Arrange
        int a = 42;
        int b = 0;

        // Act
        int result = _calculator.Add(a, b);

        // Assert
        Assert.Equal(42, result);
    }

    [Fact]
    public void Subtract_TwoPositiveNumbers_ReturnsCorrectDifference()
    {
        // Arrange
        int a = 10;
        int b = 3;

        // Act
        int result = _calculator.Subtract(a, b);

        // Assert
        Assert.Equal(7, result);
    }

    [Fact]
    public void Subtract_SmallerFromLarger_ReturnsPositiveResult()
    {
        // Arrange
        int a = 3;
        int b = 10;

        // Act
        int result = _calculator.Subtract(a, b);

        // Assert
        Assert.Equal(-7, result);
    }

    [Fact]
    public void Subtract_NegativeFromPositive_ReturnsCorrectDifference()
    {
        // Arrange
        int a = 10;
        int b = -3;

        // Act
        int result = _calculator.Subtract(a, b);

        // Assert
        Assert.Equal(13, result);
    }

    [Fact]
    public void Subtract_TwoNegativeNumbers_ReturnsCorrectDifference()
    {
        // Arrange
        int a = -10;
        int b = -3;

        // Act
        int result = _calculator.Subtract(a, b);

        // Assert
        Assert.Equal(-7, result);
    }

    [Fact]
    public void Subtract_ZeroFromNumber_ReturnsSameNumber()
    {
        // Arrange
        int a = 42;
        int b = 0;

        // Act
        int result = _calculator.Subtract(a, b);

        // Assert
        Assert.Equal(42, result);
    }

    [Fact]
    public void Subtract_NumberFromItself_ReturnsZero()
    {
        // Arrange
        int a = 42;
        int b = 42;

        // Act
        int result = _calculator.Subtract(a, b);

        // Assert
        Assert.Equal(0, result);
    }
}
