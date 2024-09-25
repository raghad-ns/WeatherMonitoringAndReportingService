using WeatherMonitoringAndReportingService.Config;
using WeatherMonitoringAndReportingService.WeatherDetails;

namespace WeatherMonitoringAndReportingService.Bots;

public class RainBot:IBot
{
    private WeatherConfigurationService _weatherConfigurationService;

    public RainBot(WeatherConfigurationService weatherConfigurationService)
    {
        _weatherConfigurationService = weatherConfigurationService;
    }

    public void UpdateConfiguration(WeatherDetailsModel state)
    {
        var rainConfig = _weatherConfigurationService.GetBotConfiguration("RainBot");

        if (state.Humidity > rainConfig.HumidityThreshold)
        {
            rainConfig.Enabled = true;
            Console.WriteLine("RainBot activated!");
            Console.WriteLine($"RainBot: {rainConfig.Message}");

        } 
        else rainConfig.Enabled = false;

        _weatherConfigurationService.UpdateBotConfiguration("RainBot", rainConfig);
    }
}