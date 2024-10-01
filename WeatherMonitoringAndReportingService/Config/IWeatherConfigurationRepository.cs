namespace WeatherMonitoringAndReportingService.Config;

public interface IWeatherConfigurationRepository
{
    void AddBotConfiguration(string botConfigurationName, WeatherConfigurationModel botConfigurationValue);
    void RemoveBotConfiguration(string name);
    void UpdateBotConfiguration(string configurationName, WeatherConfigurationModel configurationValue);
    WeatherConfigurationModel GetBotConfiguration(string name);
}