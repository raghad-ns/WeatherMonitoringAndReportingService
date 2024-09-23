using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService.WeatherDetails;

public class WeatherDetailsModel
{
    public string Location { get; set; }
    public double Temperature { get; set; }
    public double Humidity { get; set; }
}
