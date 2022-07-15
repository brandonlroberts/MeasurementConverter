using MonkeyFinder.Services;

namespace Converter;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<MeasurementService>();
        builder.Services.AddSingleton<GramConversionService>();
        builder.Services.AddSingleton<OunceConversionService>();
        builder.Services.AddSingleton<MeasurementViewModel>();
        builder.Services.AddSingleton<MainPage>();

        return builder.Build();
	}
}
