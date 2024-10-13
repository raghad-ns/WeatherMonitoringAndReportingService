using WeatherMonitoringAndReportingService.Config;

namespace WeatherMonitoringAndReportingService.DataSourceProcessor.Serializers;

public interface IFileSerializer
{
    string Serialize(Dictionary<string, WeatherConfigurationModel> data);
}