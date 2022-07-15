using Converter;

namespace MonkeyFinder.Services;

public class MeasurementService
{
    List<Measurement> measurementList;
    private readonly GramConversionService _gramConversionService;
    private readonly OunceConversionService _ounceConversionService;

    public MeasurementService(GramConversionService gramConversionService, OunceConversionService ounceConversionService)
    {
        _gramConversionService = gramConversionService;
        _ounceConversionService = ounceConversionService;
    }

    public List<Measurement> GetMeasurementList()
    {
        if (measurementList?.Count > 0)
            return measurementList;

        measurementList = new List<Measurement>
            {
                new Measurement
                {
                    Id = 1,
                    Name = ApplicationConstants.MeasurementName_Ounce
                },
                new Measurement
                {
                    Id = 2,
                    Name = ApplicationConstants.MeasurementName_Gram
                }
            };
        return measurementList;
    }

    public double GetMeasurementConversions(Measurement from, Measurement to, double value)
    {
        double result = 0;

        if (from.Name == ApplicationConstants.MeasurementName_Ounce && to.Name == ApplicationConstants.MeasurementName_Gram)
        {
            result = GetOuncesToGrams(value);
        }
        if (from.Name == ApplicationConstants.MeasurementName_Gram && to.Name == ApplicationConstants.MeasurementName_Ounce)
        {
            result = GetGramsToOunces(value);
        }
        return result;
    }

    public double GetOuncesToGrams(double ounces)
    {
        return _gramConversionService.ConvertOuncesToGrams(ounces);
    }

    public double GetGramsToOunces(double grams)
    {
        return _ounceConversionService.ConvertGramsToOunces(grams);
    }
}
