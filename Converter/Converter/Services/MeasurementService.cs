using Converter;

namespace MonkeyFinder.Services;

public class MeasurementService
{
    List<Measurement> weightMeasurementList;
    List<Measurement> volumeMeasurementList;
    private readonly GramConversionService _gramConversionService;
    private readonly OunceConversionService _ounceConversionService;

    public MeasurementService(GramConversionService gramConversionService, OunceConversionService ounceConversionService)
    {
        _gramConversionService = gramConversionService;
        _ounceConversionService = ounceConversionService;
    }

    public List<Measurement> GetWeightMeasurementList()
    {
        if (weightMeasurementList?.Count > 0)
            return weightMeasurementList;

        weightMeasurementList = new List<Measurement>
            {
                new Measurement { Id = 1, Name = ApplicationConstants.MeasurementName_Ounce },
                new Measurement { Id = 2, Name = ApplicationConstants.MeasurementName_Gram }
            };
        return weightMeasurementList;
    }

    public List<Measurement> GetVolumeMeasurementList()
    {
        if (volumeMeasurementList?.Count > 0)
            return volumeMeasurementList;

        volumeMeasurementList = new List<Measurement>
            {
                new Measurement { Id = 3, Name = ApplicationConstants.MeasurementName_Gallon },
                new Measurement { Id = 4, Name = ApplicationConstants.MeasurementName_Liter },
                new Measurement { Id = 5, Name = ApplicationConstants.MeasurementName_Quart },
                new Measurement { Id = 6, Name = ApplicationConstants.MeasurementName_Pint },
                new Measurement { Id = 7, Name = ApplicationConstants.MeasurementName_Cup },
                new Measurement { Id = 8, Name = ApplicationConstants.MeasurementName_FluidOunce },
                new Measurement { Id = 9, Name = ApplicationConstants.MeasurementName_Tablespoon },
                new Measurement { Id = 10, Name = ApplicationConstants.MeasurementName_Teaspoon },
            };
        return volumeMeasurementList;
    }

    public double GetWeightMeasurementConversions(Measurement from, Measurement to, double value)
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

    public double GetVolumeMeasurementConversions(Measurement from, Measurement to, double value)
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
