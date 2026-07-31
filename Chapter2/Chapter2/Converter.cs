namespace Chapter2
{
    public class CConverter
    {
        private const double m_millimetersPerInch = 25.4;

        public double InchesToMillimeters(double inches)
        {
            return inches * m_millimetersPerInch;
        }

        public double MillimetersToInches(double millimeters)
        {
            return millimeters / m_millimetersPerInch;
        }
    }
}
