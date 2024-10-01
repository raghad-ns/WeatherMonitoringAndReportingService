using WeatherMonitoringAndReportingService.WeatherDetails;

namespace WeatherMonitoringAndReportingService.InputConversion;

public interface IAdapter
{
    public static abstract WeatherDetailsModel ToWeatherDetailsAdapter(string input);
}