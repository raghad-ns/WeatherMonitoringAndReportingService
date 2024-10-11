using WeatherMonitoringAndReportingService.WeatherDetails;

namespace WeatherMonitoringAndReportingService.Bots;

public interface IBot
{
    void UpdateConfiguration(WeatherDetailsModel state);
}