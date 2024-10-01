using System.Text.Json;
using WeatherMonitoringAndReportingService.WeatherDetails;

namespace WeatherMonitoringAndReportingService.InputConversion;

public class JSONToWeatherDetailsAdapter: IAdapter
{
    public static WeatherDetailsModel ToWeatherDetailsAdapter(string json)
    {
        return JsonSerializer.Deserialize<WeatherDetailsModel>(json);
    }
}