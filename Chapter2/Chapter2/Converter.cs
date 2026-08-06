namespace Chapter2
{
    public class Converter
    {
        private const double millimetersPerInch = 25.4;

        public double InchesToMillimeters(double inches)
        {
            return inches * millimetersPerInch;
        }

        public double MillimetersToInches(double millimeters)
        {
            return millimeters / millimetersPerInch;
        }
    }
}
