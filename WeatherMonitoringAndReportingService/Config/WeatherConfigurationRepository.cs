using WeatherMonitoringAndReportingService.AppSettings;
using WeatherMonitoringAndReportingService.DataSourceProcessor;

namespace WeatherMonitoringAndReportingService.Config;

public class WeatherConfigurationRepository
{
    private IDataSourceProcessor _dataSourceProcessor;
    private Dictionary<string, WeatherConfigurationModel> _weatherConfigurations;

    public WeatherConfigurationRepository(IDataSourceProcessor dataSourceProcessor) {
        _dataSourceProcessor = dataSourceProcessor;
        _weatherConfigurations = _dataSourceProcessor.ReadFile(AppSettingsInitializer.AppSettingsInstance().ConfigFilePath);
    }

    public void AddBotConfiguration(string name, WeatherConfigurationModel configuration)
    {
        _weatherConfigurations.Add(name, configuration);
        //_dataSourceProcessor.Add(name, configuration);
    }

    public void RemoveBotConfiguration(string name)
    {
        _weatherConfigurations.Remove(name);
        //_dataSourceProcessor.Remove(name);
    }

    public void UpdateBotConfiguration(string name, WeatherConfigurationModel configuration)
    {
        _weatherConfigurations[name] = configuration;
    }

    public WeatherConfigurationModel GetBotConfiguration(string name) { return _weatherConfigurations[name]; }
}
