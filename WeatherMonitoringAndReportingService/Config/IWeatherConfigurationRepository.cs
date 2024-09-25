namespace WeatherMonitoringAndReportingService.Config;

public interface IWeatherConfigurationRepository
{
    public void AddBotConfiguration(string botConfigurationName, WeatherConfigurationModel botConfigurationValue);
    public void RemoveBotConfiguration(string name);
    public void UpdateBotConfiguration(string configurationName, WeatherConfigurationModel configurationValue);
    public WeatherConfigurationModel GetBotConfiguration(string name);
}