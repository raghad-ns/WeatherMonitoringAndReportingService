using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringAndReportingService.WeatherDetails;

namespace WeatherMonitoringAndReportingService.InputConversion;

public interface IAdapter
{
    public static abstract WeatherDetailsModel ToWeatherDetailsAdapter(string input);
}
