namespace MonkeyFinder.Services;

public class OunceConversionService
{
    public double ConvertGramsToOunces(double grams)
    {
        return Math.Round(grams / 28.35, 2);
    }
}
