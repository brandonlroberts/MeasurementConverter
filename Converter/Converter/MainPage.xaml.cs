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
        var from = fromPicker.SelectedItem as Measurement;
        var to = toPicker.SelectedItem as Measurement;
        string myText = measurementEditor.Text;

        measurementResult.Text = $"Convert {myText} {from.Name}s to 1 {to.Name} ";
    }
}

