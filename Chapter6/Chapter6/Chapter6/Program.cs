using Chapter6;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(GetDmcVersion(123));
        Console.WriteLine(GetDmcVersion(1234));
        Console.WriteLine(GetDmcVersion(12345));
        Console.WriteLine(GetDmcVersion(123456));

        Point point = new Point();
        point.x = 44;

        IPoint point1 = point as IPoint;

        point1.
    }

    private static Version GetDmcVersion(int encoded)
    {
        Console.Write(encoded + " : ");
        int patch = encoded % 10;
        int packed = encoded / 10;

        int major;
        int minor;

        // DEVVER-compatible decode for typical values (e.g., 1170 -> 1.17.0)
        // Fallback preserves legacy short-form behavior.
        if (packed >= 100)
        {
            major = packed / 100;
            minor = packed % 100;
        }
        else
        {
            major = packed / 10;
            minor = packed % 10;
        }

        return new Version(major, minor, patch);
    }
}