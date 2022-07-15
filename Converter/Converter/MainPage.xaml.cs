namespace Converter;

public partial class MainPage : ContentPage
{
	public MainPage(MeasurementViewModel viewModel)
	{
		InitializeComponent();
		viewModel.GetMeasurementsCommand.Execute(this);
		BindingContext = viewModel;
	}

    void ConvertMeasurement(object sender, EventArgs e)
    {
		try
		{
            var from = fromPicker?.SelectedItem as Measurement;
            var to = toPicker?.SelectedItem as Measurement;
            string myText = measurementEditor.Text;

            measurementResult.Text = $"Convert {myText} {from.Name}s to 1 {to.Name} ";
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

