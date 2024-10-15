using System.Text.Json;
using WeatherMonitoringAndReportingService.AppSettings;
using WeatherMonitoringAndReportingService.Config;

namespace WeatherMonitoringAndReportingService.DataSourceProcessor.Readers;

public class FileReader : IFileReader
{
    public Dictionary<string, WeatherConfigurationModel> ReadFile(string? path)
    {
        string jsonString = File.ReadAllText(path ?? AppSettingsInitializer.AppSettingsInstance().ConfigFilePath);
        var botsSettings = JsonSerializer.Deserialize<Dictionary<string, WeatherConfigurationModel>>(jsonString);

        return botsSettings!;
    }
}