using System.Text.Json;

namespace WeatherMonitoringAndReportingService.AppSettings;

internal class AppSettingsInitializer
{
    private static AppSettingsModel? _appSettings;

    private AppSettingsInitializer()
    {
        string appSettingsJson = File.ReadAllText("../../../../WeatherMonitoringAndReportingService/AppSettings/appsettings.json");
        _appSettings = JsonSerializer.Deserialize<AppSettingsModel>(appSettingsJson);
    }

    public static AppSettingsModel AppSettingsInstance()
    {
        if (_appSettings == null) new AppSettingsInitializer();

        return _appSettings;
    }
}