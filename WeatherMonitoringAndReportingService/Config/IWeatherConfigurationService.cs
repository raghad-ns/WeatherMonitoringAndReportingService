using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService.Config;

public interface IWeatherConfigurationService
{
    void AddBotConfiguration(string botConfigurationName, WeatherConfigurationModel botConfigurationValue);
    void RemoveBotConfiguration(string name);
    void UpdateBotConfiguration(string configurationName, WeatherConfigurationModel configurationValue);
    WeatherConfigurationModel GetBotConfiguration(string name);
}