namespace Chapter2.Tests;

public class ConverterTests
{
    private readonly Converter converter = new();

    [Theory]
    [InlineData(1, 25.4)]
    [InlineData(2, 50.8)]
    [InlineData(0, 0)]
    [InlineData(0.5, 12.7)]
    [InlineData(10, 254)]
    [InlineData(-1, -25.4)]
    public void InchesToMillimeters_ReturnsCorrectValue(double inches, double expected)
    {
        double result = converter.InchesToMillimeters(inches);
        Assert.Equal(expected, result, precision: 4);
    }

    [Theory]
    [InlineData(25.4, 1)]
    [InlineData(50.8, 2)]
    [InlineData(0, 0)]
    [InlineData(12.7, 0.5)]
    [InlineData(254, 10)]
    [InlineData(-25.4, -1)]
    public void MillimetersToInches_ReturnsCorrectValue(double millimeters, double expected)
    {
        double result = converter.MillimetersToInches(millimeters);
        Assert.Equal(expected, result, precision: 4);
    }

    [Fact]
    public void InchesToMillimeters_MillimetersToInches_RoundTrip_ReturnsOriginalValue()
    {
        double original = 5.5;
        double mm = converter.InchesToMillimeters(original);
        double backToInches = converter.MillimetersToInches(mm);
        Assert.Equal(original, backToInches, precision: 10);
    }
}
