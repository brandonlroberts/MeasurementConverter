namespace MonkeyFinder.Services;

public class MeasurementService
{
    //HttpClient httpClient;
    public MeasurementService()
    {
        //this.httpClient = new HttpClient();
    }

    List<Measurement> measurementList;
    public List<Measurement> GetMeasurementList()
    {
        if (measurementList?.Count > 0)
            return measurementList;

        measurementList = new List<Measurement>
            {
                new Measurement
                {
                    Id = 1,
                    Name = "cup"
                },
                new Measurement
                {
                    Id = 2,
                    Name = "tablespoon"
                },
                new Measurement
                {
                    Id= 3,
                    Name = "teaspoon"
                }
            };
        //using var stream = await FileSystem.OpenAppPackageFileAsync("monkeydata.json");
        //using var reader = new StreamReader(stream);
        //var contents = await reader.ReadToEndAsync();
        //monkeyList = JsonSerializer.Deserialize<List<Monkey>>(contents);

        return measurementList;
    }
}
