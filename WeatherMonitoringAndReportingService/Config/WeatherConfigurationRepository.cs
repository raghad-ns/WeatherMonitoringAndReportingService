using WeatherMonitoringAndReportingService.AppSettings;
using WeatherMonitoringAndReportingService.DataSourceProcessor;

namespace WeatherMonitoringAndReportingService.Config;

public class WeatherConfigurationRepository
{
    private IDataSourceProcessor _dataSourceProcessor;
    private Dictionary<string, WeatherConfigurationModel> _weatherConfigurations;
    private string _configFilePath = AppSettingsInitializer.AppSettingsInstance().ConfigFilePath;

    public WeatherConfigurationRepository(IDataSourceProcessor dataSourceProcessor) {
        _dataSourceProcessor = dataSourceProcessor;
        _weatherConfigurations = _dataSourceProcessor.ReadFile(_configFilePath);
    }

    public void AddBotConfiguration(string name, WeatherConfigurationModel configuration)
    {
        _weatherConfigurations.Add(name, configuration);
        _dataSourceProcessor.Add(name, configuration, _configFilePath);
    }

    public void RemoveBotConfiguration(string name)
    {
        _weatherConfigurations.Remove(name);
        _dataSourceProcessor.Remove(name, _configFilePath);
    }

    public void UpdateBotConfiguration(string name, WeatherConfigurationModel configuration)
    {
        _weatherConfigurations[name] = configuration;
        _dataSourceProcessor.Update(name, configuration, _configFilePath);
    }

    public WeatherConfigurationModel GetBotConfiguration(string name) { return _weatherConfigurations[name]; }
}
