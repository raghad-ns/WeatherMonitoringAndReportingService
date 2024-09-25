namespace WeatherMonitoringAndReportingService.Config;

public class WeatherConfigurationService
{
    private WeatherConfigurationRepository _weatherConfigurationRepository;

    public WeatherConfigurationService(WeatherConfigurationRepository weatherConfigurationRepository)
    {
        _weatherConfigurationRepository = weatherConfigurationRepository;
    }

    public void AddBotConfiguration(string botConfigurationName, WeatherConfigurationModel botConfigurationValue) =>
        _weatherConfigurationRepository.AddBotConfiguration(botConfigurationName, botConfigurationValue);

    public void RemoveBotConfiguration(string name) =>
        _weatherConfigurationRepository?.RemoveBotConfiguration(name);

    public void UpdateBotConfiguration(string configurationName, WeatherConfigurationModel configurationValue) =>
        _weatherConfigurationRepository.UpdateBotConfiguration(configurationName, configurationValue);

    public WeatherConfigurationModel GetBotConfiguration(string name)
    {
        return _weatherConfigurationRepository.GetBotConfiguration(name);
    }
}