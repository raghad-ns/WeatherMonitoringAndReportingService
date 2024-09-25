using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService.Config;

public interface IWeatherConfigurationService
{
    public void AddBotConfiguration(string botConfigurationName, WeatherConfigurationModel botConfigurationValue);
    public void RemoveBotConfiguration(string name);
    public void UpdateBotConfiguration(string configurationName, WeatherConfigurationModel configurationValue);
    public WeatherConfigurationModel GetBotConfiguration(string name);
}
