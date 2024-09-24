using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringAndReportingService.Config;
using WeatherMonitoringAndReportingService.WeatherDetails;

namespace WeatherMonitoringAndReportingService.Bots;

public class SnowBot: IBot
{
    private WeatherConfigurationService _weatherConfigurationService;

    public SnowBot(WeatherConfigurationService weatherConfigurationService)
    {
        _weatherConfigurationService = weatherConfigurationService;
    }

    public void UpdateConfiguration(WeatherDetailsModel state)
    {
        var snowConfig = _weatherConfigurationService.GetBotConfiguration("SnowBot");

        if (state.Temperature < snowConfig.TemperatureThreshold)
        {
            snowConfig.Enabled = true;

            Console.WriteLine("SnowBot activated!");
            Console.WriteLine($"SnowBot: {snowConfig.Message}");
        }
        else snowConfig.Enabled = false;

        _weatherConfigurationService.UpdateBotConfiguration("SnowBot", snowConfig);
    }
}
