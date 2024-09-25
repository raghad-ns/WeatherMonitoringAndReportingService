using WeatherMonitoringAndReportingService.Config;
using WeatherMonitoringAndReportingService.WeatherDetails;

namespace WeatherMonitoringAndReportingService.Bots;

public class SnowBot: IBot
{
    private readonly IWeatherConfigurationService _weatherConfigurationService;

    public SnowBot(IWeatherConfigurationService weatherConfigurationService)
    {
        _weatherConfigurationService = weatherConfigurationService;
    }

    public void UpdateConfiguration(WeatherDetailsModel state)
    {
        const string BotName = "SnowBot";
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