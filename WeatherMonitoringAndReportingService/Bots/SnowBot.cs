using WeatherMonitoringAndReportingService.Config;
using WeatherMonitoringAndReportingService.WeatherDetails;

namespace WeatherMonitoringAndReportingService.Bots;

public class SnowBot : IBot
{
    private readonly IWeatherConfigurationService _weatherConfigurationService;
    private readonly string BotName = "SnowBot";

    public SnowBot(IWeatherConfigurationService weatherConfigurationService)
    {
        _weatherConfigurationService = weatherConfigurationService;
    }

    public void UpdateConfiguration(WeatherDetailsModel state)
    {
        var snowConfig = _weatherConfigurationService.GetBotConfiguration(BotName);

        if (state.Temperature < snowConfig.TemperatureThreshold)
        {
            snowConfig.Enabled = true;
            Console.WriteLine($"{BotName} :  activated!");
            Console.WriteLine($"{BotName}: {snowConfig.Message}");
        }
        else snowConfig.Enabled = false;
        _weatherConfigurationService.UpdateBotConfiguration(BotName, snowConfig);
    }
}