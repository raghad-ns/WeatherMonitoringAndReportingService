using WeatherMonitoringAndReportingService.Config;
using WeatherMonitoringAndReportingService.WeatherDetails;

namespace WeatherMonitoringAndReportingService.Bots;

public class RainBot:IBot
{
    private readonly IWeatherConfigurationService _weatherConfigurationService;

    public RainBot(IWeatherConfigurationService weatherConfigurationService)
    {
        _weatherConfigurationService = weatherConfigurationService;
    }

    public void UpdateConfiguration(WeatherDetailsModel state)
    {
        const string BotName = "RainBot";
        var rainConfig = _weatherConfigurationService.GetBotConfiguration(BotName);

        if (state.Humidity > rainConfig.HumidityThreshold)
        {
            rainConfig.Enabled = true;
            Console.WriteLine($"{BotName} :  activated!");
            Console.WriteLine($"{BotName}: {rainConfig.Message}");

        } 
        else rainConfig.Enabled = false;

        _weatherConfigurationService.UpdateBotConfiguration(BotName, rainConfig);
    }
}