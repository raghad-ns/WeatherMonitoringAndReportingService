using System.Xml.Serialization;
using WeatherMonitoringAndReportingService.WeatherDetails;

namespace WeatherMonitoringAndReportingService.InputConversion;

public class XMLToWeatherDetailsAdapter : IAdapter
{
    private const string RootAttribute = "WeatherData";

    public static WeatherDetailsModel ToWeatherDetailsAdapter(string xml)
    {
        var serializer = new XmlSerializer(typeof(WeatherDetailsModel), new XmlRootAttribute(RootAttribute));
        using var reader = new StringReader(xml);
        return (WeatherDetailsModel)serializer.Deserialize(reader);
    }
}