using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherMonitoringAndReportingService.WeatherDetails;

namespace WeatherMonitoringAndReportingService.InputConversion;

public class JSONToWeatherDetailsAdapter: IAdapter
{
    public static WeatherDetailsModel ToWeatherDetailsAdapter(string json)
    {
        return JsonSerializer.Deserialize<WeatherDetailsModel>(json);
    }
}
