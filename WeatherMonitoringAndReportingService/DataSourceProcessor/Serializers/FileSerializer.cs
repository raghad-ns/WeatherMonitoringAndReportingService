using System.Text.Json;
using WeatherMonitoringAndReportingService.Config;

namespace WeatherMonitoringAndReportingService.DataSourceProcessor.Serializers;

public class FileSerializer : IFileSerializer
{
    private readonly JsonSerializerOptions _jsonSerializerOptions =
        new JsonSerializerOptions { WriteIndented = true };

    string IFileSerializer.Serialize(Dictionary<string, WeatherConfigurationModel> data)
    {
        return JsonSerializer.Serialize(data, _jsonSerializerOptions);
    }
}