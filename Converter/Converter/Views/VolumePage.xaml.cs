using MonkeyFinder.Services;

namespace Converter;

public partial class VolumePage : ContentPage
{
    private readonly MeasurementService _measurementService;

    public VolumePage(MeasurementViewModel viewModel, MeasurementService measurementService)
	{
		InitializeComponent();
		viewModel.GetMeasurementsCommand.Execute(this);
		BindingContext = viewModel;
        _measurementService = measurementService;
    }

    void ConvertMeasurement(object sender, EventArgs e)
    {
		try
		{
            var from = fromPicker?.SelectedItem as Measurement;
            var to = toPicker?.SelectedItem as Measurement;
            double result = 0;
            string value = measurementEditor.Text;

            if (double.TryParse(value, out double newValue) && newValue > 0)
            {
                result = _measurementService.GetMeasurementConversions(from, to, newValue);
            }
            else
            {
                Shell.Current.DisplayAlert("Please enter a valid number!", "Number must also be greater than zero.", "OK");
            }            
            measurementResult.Text = $"{result} {to.Name}(s) ";
        }
        catch (NullReferenceException)
        {
            Shell.Current.DisplayAlert("Please complete all the selections!", "", "OK");
        }
        catch (Exception ex)
        {
            Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }

    }

    void ClearMeasurements(object sender, EventArgs e)
    {
            fromPicker.SelectedIndex = -1;
            toPicker.SelectedIndex = -1;
            measurementEditor.Text = "";
            measurementResult.Text = "";
    }
}

