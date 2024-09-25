using WeatherMonitoringAndReportingService.Config;
using WeatherMonitoringAndReportingService.WeatherDetails;

namespace WeatherMonitoringAndReportingService.Bots;

public class SunBot: IBot
{
    private WeatherConfigurationService _weatherConfigurationService;

    public SunBot(WeatherConfigurationService weatherConfigurationService)
    {
        _weatherConfigurationService = weatherConfigurationService;
    }

    public void UpdateConfiguration(WeatherDetailsModel state)
    {
        var sunConfig = _weatherConfigurationService.GetBotConfiguration("SunBot");

        if (state.Temperature > sunConfig.TemperatureThreshold)
        {
            sunConfig.Enabled = true;
            Console.WriteLine("SunBot activated!");
            Console.WriteLine($"SunBot: {sunConfig.Message}");
        }
        else sunConfig.Enabled = false;

        _weatherConfigurationService.UpdateBotConfiguration("SunBot", sunConfig);
    }
}