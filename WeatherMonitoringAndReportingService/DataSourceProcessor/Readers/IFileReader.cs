using WeatherMonitoringAndReportingService.Config;

namespace WeatherMonitoringAndReportingService.DataSourceProcessor.Readers;

public interface IFileReader
{
    Dictionary<string, WeatherConfigurationModel> ReadFile(string? path);
}