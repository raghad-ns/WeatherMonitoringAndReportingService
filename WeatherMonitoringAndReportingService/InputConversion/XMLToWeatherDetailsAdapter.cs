using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WeatherMonitoringAndReportingService.WeatherDetails;

namespace WeatherMonitoringAndReportingService.InputConversion;

public class XMLToWeatherDetailsAdapter : IAdapter
{
    public static WeatherDetailsModel ToWeatherDetailsAdapter(string xml)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(WeatherDetailsModel), new XmlRootAttribute("WeatherData"));
        using (StringReader reader = new StringReader(xml))
        {
            return (WeatherDetailsModel)serializer.Deserialize(reader);
        }
    }
}
