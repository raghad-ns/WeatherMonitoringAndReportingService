namespace WeatherMonitoringAndReportingService.Config;

public class WeatherConfigurationService: IWeatherConfigurationService
{
    private readonly IWeatherConfigurationRepository _weatherConfigurationRepository;

    public WeatherConfigurationService(IWeatherConfigurationRepository weatherConfigurationRepository)
    {
        _weatherConfigurationRepository = weatherConfigurationRepository;
    }

    public void AddBotConfiguration(string botConfigurationName, WeatherConfigurationModel botConfigurationValue) =>
        _weatherConfigurationRepository.AddBotConfiguration(botConfigurationName, botConfigurationValue);

    public void RemoveBotConfiguration(string name) =>
        _weatherConfigurationRepository.RemoveBotConfiguration(name);

    public void UpdateBotConfiguration(string configurationName, WeatherConfigurationModel configurationValue) =>
        _weatherConfigurationRepository.UpdateBotConfiguration(configurationName, configurationValue);

    public WeatherConfigurationModel GetBotConfiguration(string name) => 
        _weatherConfigurationRepository.GetBotConfiguration(name);
}