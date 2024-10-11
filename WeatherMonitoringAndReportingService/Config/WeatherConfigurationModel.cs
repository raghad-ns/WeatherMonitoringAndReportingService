namespace WeatherMonitoringAndReportingService.Config;

public class WeatherConfigurationModel
{
    public bool Enabled { get; set; }
    public string Message { get; set; }
    public double TemperatureThreshold { get; set; }
    public double HumidityThreshold { get; set; }
}