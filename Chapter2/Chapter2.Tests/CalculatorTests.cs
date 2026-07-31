namespace Chapter2.Tests;

public class CalculatorTests
{
    private readonly Calculator _calculator = new();

    [Theory]
    [InlineData(5, 3, 8)]
    [InlineData(10, -3, 7)]
    [InlineData(-5, -3, -8)]
    [InlineData(42, 0, 42)]
    [InlineData(0, 5, 5)]
    [InlineData(-10, 10, 0)]
    public void Add_ReturnsCorrectSum(int a, int b, int expected)
    {
        int result = _calculator.Add(a, b);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(10, 3, 7)]
    [InlineData(3, 10, -7)]
    [InlineData(10, -3, 13)]
    [InlineData(-10, -3, -7)]
    [InlineData(42, 0, 42)]
    [InlineData(42, 42, 0)]
    [InlineData(0, 5, -5)]
    public void Subtract_ReturnsCorrectDifference(int a, int b, int expected)
    {
        int result = _calculator.Subtract(a, b);
        Assert.Equal(expected, result);
    }
}
