using WeatherMonitoringAndReportingService.WeatherDetails;

namespace WeatherMonitoringAndReportingService.Bots;

public interface IBot
{
    public void UpdateConfiguration(WeatherDetailsModel state);
}