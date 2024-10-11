using WeatherMonitoringAndReportingService.Config;
using WeatherMonitoringAndReportingService.WeatherDetails;

namespace WeatherMonitoringAndReportingService.Bots;

public class SunBot : IBot
{
    private readonly IWeatherConfigurationService _weatherConfigurationService;
    private readonly string BotName = "SunBot";

    public SunBot(IWeatherConfigurationService weatherConfigurationService)
    {
        _weatherConfigurationService = weatherConfigurationService;
    }

    public void UpdateConfiguration(WeatherDetailsModel state)
    {
        var sunConfig = _weatherConfigurationService.GetBotConfiguration(BotName);

        if (state.Temperature > sunConfig.TemperatureThreshold)
        {
            sunConfig.Enabled = true;
            Console.WriteLine($"{BotName} :  activated!");
            Console.WriteLine($"{BotName}: {sunConfig.Message}");
        }
        else sunConfig.Enabled = false;
        _weatherConfigurationService.UpdateBotConfiguration(BotName, sunConfig);
    }
}