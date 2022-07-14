using MonkeyFinder.Services;
using System.Reflection;

namespace Converter.ViewModels
{
    public partial class MeasurementViewModel : BaseViewModel
    {
        public ObservableCollection<Measurement> Measurements { get; set; } = new ObservableCollection<Measurement>();
        MeasurementService _measurementService;

        public MeasurementViewModel(MeasurementService measurementService)
        {
            Title = "Convert Measurements";
            _measurementService = measurementService;
        }

        [ObservableProperty]
        bool isRefreshing;

        [RelayCommand]
        async Task GetMeasurementsAsync()
        {
            if (IsBusy)
                return;

            try
            {
                //if (connectivity.NetworkAccess != NetworkAccess.Internet)
                //{
                //    await Shell.Current.DisplayAlert("No connectivity!",
                //        $"Please check internet and try again.", "OK");
                //    return;
                //}

                IsBusy = true;
                var measurements = _measurementService.GetMeasurementList();

                if (Measurements.Count != 0)
                    Measurements.Clear();

                foreach (var measurement in measurements)
                    Measurements.Add(measurement);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }

        }
    }
}
