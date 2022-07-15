namespace MonkeyFinder.Services;

public class GramConversionService
{
    public double ConvertOuncesToGrams(double ounces)
    {
        return Math.Round(ounces * 28.35, 2);
    }
}
