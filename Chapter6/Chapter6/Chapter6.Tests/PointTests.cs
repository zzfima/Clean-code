namespace Chapter6.Tests;

public class PointTests
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(3, 4)]
    [InlineData(-2, 7)]
    [InlineData(1.5, -2.5)]
    public void Constructor_SetsXAndY(double x, double y)
    {
        Point point = new(x, y);

        Assert.Equal(x, point.X);
        Assert.Equal(y, point.Y);
    }

    [Fact]
    public void DistanceTo_SamePoint_ReturnsZero()
    {
        Point point = new(3, 4);

        double result = point.DistanceTo(point);

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData(0, 0, 3, 4, 5)]
    [InlineData(1, 1, 4, 5, 5)]
    [InlineData(-1, -1, 2, 3, 5)]
    [InlineData(0, 0, 0, 0, 0)]
    public void DistanceTo_ReturnsExpectedDistance(double x1, double y1, double x2, double y2, double expected)
    {
        Point first = new(x1, y1);
        Point second = new(x2, y2);

        double result = first.DistanceTo(second);

        Assert.Equal(expected, result, precision: 10);
    }

    [Fact]
    public void DistanceTo_IsSymmetric()
    {
        Point first = new(1, 2);
        Point second = new(4, 6);

        double firstToSecond = first.DistanceTo(second);
        double secondToFirst = second.DistanceTo(first);

        Assert.Equal(firstToSecond, secondToFirst, precision: 10);
    }
}
