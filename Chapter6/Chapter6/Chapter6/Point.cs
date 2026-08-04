namespace Chapter6;

public class CPoint
{
    private double m_x;
    private double m_y;

    public CPoint(double x, double y)
    {
        m_x = x;
        m_y = y;
    }

    public double X => m_x;

    public double Y => m_y;

    public double DistanceTo(CPoint other)
    {
        double deltaX = m_x - other.m_x;
        double deltaY = m_y - other.m_y;
        return Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
    }
}

public class Point
{
    public double x;
    public double y;
}
public interface IPoint
{
    double getX();
    double getY();
    void setCartesian(double x, double y);
    double getR();
    double getTheta();
    void setPolar(double r, double theta);
}
