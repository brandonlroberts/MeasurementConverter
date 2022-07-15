using MonkeyFinder.Services;

namespace Converter.ViewModels
{
    public partial class MeasurementViewModel : BaseViewModel
    {
        public ObservableCollection<Measurement> WeightMeasurements { get; set; } = new ObservableCollection<Measurement>();
        public ObservableCollection<Measurement> VolumeMeasurements { get; set; } = new ObservableCollection<Measurement>();

        MeasurementService _measurementService;

        public MeasurementViewModel(MeasurementService measurementService)
        {
            Title = "Convert Measurements";
            _measurementService = measurementService;
        }

        [ObservableProperty]
        bool isRefreshing;

        [RelayCommand]
        async Task GetWeightMeasurementsAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var measurements = _measurementService.GetWeightMeasurementList();

                if (WeightMeasurements.Count != 0)
                    WeightMeasurements.Clear();

                foreach (var measurement in measurements)
                    WeightMeasurements.Add(measurement);

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

        [RelayCommand]
        async Task GetVolumeMeasurementsAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var measurements = _measurementService.GetVolumeMeasurementList();

                if (VolumeMeasurements.Count != 0)
                    VolumeMeasurements.Clear();

                foreach (var measurement in measurements)
                    VolumeMeasurements.Add(measurement);

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
