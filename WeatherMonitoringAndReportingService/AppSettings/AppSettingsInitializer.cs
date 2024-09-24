using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService.AppSettings;

internal class AppSettingsInitializer
{
    private static AppSettingsModel? _appSettings;

    private AppSettingsInitializer()
    {
        string appSettingsJson = File.ReadAllText("../../../AppSettings/appsettings.json");
        _appSettings = JsonSerializer.Deserialize<AppSettingsModel>(appSettingsJson);
    }

    public static AppSettingsModel AppSettingsInstance()
    {
        if (_appSettings == null) new AppSettingsInitializer();

        return _appSettings;
    }
}
