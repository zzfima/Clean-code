namespace Chapter6;

public class Point
{
    private double xCoordinate;
    private double yCoordinate;

    public Point(double xCoordinate, double yCoordinate)
    {
        this.xCoordinate = xCoordinate;
        this.yCoordinate = yCoordinate;
    }

    public double X => xCoordinate;

    public double Y => yCoordinate;

    public double DistanceTo(Point otherPoint)
    {
        double deltaX = xCoordinate - otherPoint.xCoordinate;
        double deltaY = yCoordinate - otherPoint.yCoordinate;
        return Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
    }
}

public class PointCoordinates
{
    public double X;
    public double Y;
}
public interface IPoint
{
    double GetX();
    double GetY();
    void SetCartesian(double xCoordinate, double yCoordinate);
    double GetR();
    double GetTheta();
    void SetPolar(double radius, double theta);
}
